using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using QuickPay.Common;

namespace QuickPay.WxPay.Util
{
    public class WxPayReflectUtil
    {
        private static readonly IDictionary<Type, Delegate> RequestToWxPayDataDict =
            new ConcurrentDictionary<Type, Delegate>();

        private static readonly IDictionary<Type, object> DefaultValueDict = new ConcurrentDictionary<Type, object>()
        {
            [typeof(int)] = default(int),
            [typeof(decimal)] = default(decimal),
            [typeof(DateTime)] = default(DateTime),
            [typeof(long)] = default(long),
            [typeof(double)] = default(double),
            [typeof(string)] = default(string),
        };

        /// <summary>将微信请求转换为WxPayData
        /// </summary>
        public static WxPayData ToWxPayData<T>(T request) where T : IWxPayRequest
        {
            Delegate method;
            if (!RequestToWxPayDataDict.TryGetValue(typeof(T), out method))
            {
                method = GetWxPayDataFunc<T>();
                RequestToWxPayDataDict.Add(typeof(T), method);
            }
            var func = method as Func<T, WxPayData>;
            return func?.Invoke(request);
        }


        public static Func<T, WxPayData> GetWxPayDataFunc<T>() where T : IWxPayRequest
        {
            //数据源类型,IWxPayRequest实现类或子类
            var sourceType = typeof(T);
            var targetType = typeof(WxPayData);
            // 定义参数,传递进来的UserInfo
            var parameterExpr = Expression.Parameter(sourceType, "request");
            var bodyExprs = new List<Expression>();
            //code:var wxPayData=new WxPayData();
            var wxPayDataExpr = Expression.Variable(targetType, "wxPayData");
            var newWxPayDataExpr = Expression.New(targetType);
            var assignWxPayDataExpr = Expression.Assign(wxPayDataExpr, newWxPayDataExpr);
            bodyExprs.Add(assignWxPayDataExpr);
            //获取IWxPayRequest中所有的属性
            var properties = ReflectUtil.GetProperties(sourceType);
            foreach (var property in properties)
            {
                //获取该属性的Attribute
                var attribute = property.GetCustomAttribute<WxPayDataElementAttribute>();
                if (attribute != null)
                {
                    //code:var id=(object)request.Id;
                    //某属性的WxPayData中的Name值
                    var nameExpr = Expression.Constant(attribute.Name);
                    //(object)request.Id 默认转换为object
                    var castValueExpr = Expression.Convert(Expression.Property(parameterExpr, property), typeof(object));
                    //code:wxPayData.SetValue("xxx",(object)request.Id)
                    var setValueExpr = Expression.Call(wxPayDataExpr,
                        targetType.GetTypeInfo().GetMethod("SetValue", new Type[] {typeof(string), typeof(object)}),
                        nameExpr, castValueExpr);
            
                    var ifNotNullExpr = Expression.IfThen(
                        //code: if(id!=null)
                        Expression.NotEqual(castValueExpr, Expression.Constant(null)),
                        //code: if(id!=0)
                        Expression.IfThen(
                            Expression.NotEqual(castValueExpr,
                            Expression.Constant(DefaultValueDict[property.PropertyType])),
                            setValueExpr));
                    bodyExprs.Add(ifNotNullExpr);
                }
            }
            //此处需要注意,这里添加的相当于返回值
            bodyExprs.Add(wxPayDataExpr);
            var methodBodyExpr = Expression.Block(targetType, new[] {wxPayDataExpr}, bodyExprs);
            // code: entity => { ... }
            var lambdaExpr = Expression.Lambda<Func<T, WxPayData>>(methodBodyExpr, parameterExpr);
            var func = lambdaExpr.Compile();
            return func;
        }






    }
}
