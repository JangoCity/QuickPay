using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using QuickPay.Common;

namespace QuickPay.WxPay.Util
{
    public class WxPayReflectUtil
    {
        private static readonly IDictionary<Type, Delegate> WxPayToDataDict =
            new ConcurrentDictionary<Type, Delegate>();

        private static readonly IDictionary<Type, Delegate> DataToWxPayDict =
            new ConcurrentDictionary<Type, Delegate>();

        private static readonly IDictionary<Type, object> DefaultValueDict = new ConcurrentDictionary<Type, object>()
        {
            [typeof(short)] = default(short),
            [typeof(int)] = default(int),
            [typeof(decimal)] = default(decimal),
            [typeof(DateTime)] = default(DateTime),
            [typeof(long)] = default(long),
            [typeof(double)] = default(double),
            [typeof(string)] = default(string),
        };

        private static readonly IDictionary<Type, string> ConvertMethodNames = new ConcurrentDictionary<Type, string>()
        {
            [typeof(short)] = "ToInt16",
            [typeof(int)] = "ToInt32",
            [typeof(long)] = "ToInt64",
            [typeof(double)] = "ToDouble",
            [typeof(decimal)] = "ToDecimal",
            [typeof(DateTime)] = "ToDateTime",
            [typeof(string)] = "ToString",
            [typeof(byte)] = "ToByte",
            [typeof(bool)] = "ToBoolean"
        };

        /// <summary>将微信请求转换为WxPayData
        /// </summary>
        public static WxPayData ToWxPayData<T>(T request) where T : IWxPay
        {
            Delegate method;
            if (!WxPayToDataDict.TryGetValue(typeof(T), out method))
            {
                method = GetDataFunc<T>();
                WxPayToDataDict.Add(typeof(T), method);
            }
            var func = method as Func<T, WxPayData>;
            return func?.Invoke(request);
        }

        /// <summary> 将IWxPay转换为WxPayData的委托
        /// </summary>
        public static Func<T, WxPayData> GetDataFunc<T>() where T : IWxPay
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

        private static string GetConvertMethod(Type type)
        {
            return ConvertMethodNames[type];
        }

        /// <summary>将WxPayData转换成IWxPay的委托
        /// </summary>
        public static Func<WxPayData, T> GetWxPay<T>() where T : IWxPay
        {
            var sourceType = typeof(WxPayData);
            var targetType = typeof(T);
            // 定义参数,传递进来的UserInfo
            var parameterExpr = Expression.Parameter(sourceType, "x");
            var bodyExprs = new List<Expression>();
            //code:var response=new Response();
            var wxResponseExpr = Expression.Variable(targetType, "response");
            var newWxResponseExpr = Expression.New(targetType);
            var assignWxPayDataExpr = Expression.Assign(wxResponseExpr, newWxResponseExpr);
            bodyExprs.Add(assignWxPayDataExpr);
            //获取Response的全部属性
            var properties = ReflectUtil.GetProperties(targetType);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<WxPayDataElementAttribute>();
                if (attribute != null)
                {
                    var nameExpr = Expression.Constant(attribute.Name);
                    //code : wxPayData.GetValue("name");
                    var getValueExpr = Expression.Call(parameterExpr,
                        sourceType.GetTypeInfo().GetMethod("GetValue", new[] {typeof(string)}), nameExpr);
                    //code: response.Name=wxPayData.GetValue("name");
                    var fieldExpr = Expression.Property(wxResponseExpr, property);
                    var convertValueExpr = Expression.Call(null,
                        typeof(Convert).GetTypeInfo()
                            .GetMethod(GetConvertMethod(property.PropertyType), new[] {typeof(object)}), getValueExpr);
                    var assignFieldExpr = Expression.Assign(fieldExpr, convertValueExpr);
                    //code: if(wxPayData.GetValue("") != null){ ... }
                    var ifNotNullExpr = Expression.IfThen(
                        Expression.NotEqual(getValueExpr, Expression.Constant(null)),
                        assignFieldExpr);
                    bodyExprs.Add(ifNotNullExpr);
                }
            }
            //此处需要注意,这里添加的相当于返回值
            bodyExprs.Add(wxResponseExpr);
            var methodBodyExpr = Expression.Block(targetType, new[] {wxResponseExpr}, bodyExprs);
            // code: entity => { ... }
            var lambdaExpr = Expression.Lambda<Func<WxPayData, T>>(methodBodyExpr, parameterExpr);
            var func = lambdaExpr.Compile();
            return func;
        }

        /// <summary>将WxPayData转换成WxPayResponse
        /// </summary>
        public static T ToWxPay<T>(WxPayData wxPayData) where T : IWxPay
        {
            Delegate method;
            if (!DataToWxPayDict.TryGetValue(typeof(T), out method))
            {
                method = GetWxPay<T>();
                DataToWxPayDict.Add(typeof(T), method);
            }
            var func = method as Func<WxPayData, T>;
            if (func != null)
            {
                return func.Invoke(wxPayData);
            }
            return default(T);
        }



    }
}
