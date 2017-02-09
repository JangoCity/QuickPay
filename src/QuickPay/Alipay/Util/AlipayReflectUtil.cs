using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using QuickPay.Common;

namespace QuickPay.Alipay.Util
{
    public class AlipayReflectUtil
    {
        private static readonly IDictionary<Type, Delegate> AlipayToDataDict =
         new ConcurrentDictionary<Type, Delegate>();

        private static readonly IDictionary<Type, Delegate> DataToAlipayDict =
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
        public static AlipayData ToAlipayData(IAlipay alipay)
        {
            Delegate method;
            var type = alipay.GetType();
            if (!AlipayToDataDict.TryGetValue(type, out method))
            {
                method = GetDataFunc(type);
                AlipayToDataDict.Add(type, method);
            }
            var func = method as Func<object, AlipayData>;
            return func?.Invoke(alipay);
        }

        /// <summary> 将IWxPay转换为WxPayData的委托
        /// </summary>
        public static Func<object, AlipayData> GetDataFunc(Type sourceType)
        {
            //数据源类型,IWxPayRequest实现类或子类
            var targetType = typeof(AlipayData);
            // 定义参数,传递进来的UserInfo
            var parameterExpr = Expression.Parameter(typeof(object), "o");
            var bodyExprs = new List<Expression>();
            //code:var wxPayData=new WxPayData();
            var alipayDataExpr = Expression.Variable(targetType, "alipayData");
            var newAlipayDataExpr = Expression.New(targetType);
            var assignAlipayDataExpr = Expression.Assign(alipayDataExpr, newAlipayDataExpr);
            bodyExprs.Add(assignAlipayDataExpr);

            //code:var alipay=(Request)o;
            var alipayExpr = Expression.Variable(sourceType, "alipay");
            var castAlipayExpr = Expression.Convert(parameterExpr, sourceType);
            var assignAlipayExpr = Expression.Assign(alipayExpr, castAlipayExpr);
            bodyExprs.Add(assignAlipayExpr);

            //获取IWxPayRequest中所有的属性
            var properties = ReflectUtil.GetProperties(sourceType);
            foreach (var property in properties)
            {
                //获取该属性的Attribute
                var attribute = property.GetCustomAttribute<AlipayDataElementAttribute>();
                if (attribute != null)
                {
                    //code:var id=(object)request.Id;
                    //某属性的WxPayData中的Name值
                    var nameExpr = Expression.Constant(attribute.Name);
                    //(object)request.Id 默认转换为object
                    var castValueExpr = Expression.Convert(Expression.Property(alipayExpr, property), typeof(object));
                    //code:wxPayData.SetValue("xxx",(object)request.Id)
                    var setValueExpr = Expression.Call(alipayDataExpr,
                        targetType.GetTypeInfo().GetMethod("SetValue", new Type[] { typeof(string), typeof(object) }),
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
            bodyExprs.Add(alipayDataExpr);
            var methodBodyExpr = Expression.Block(targetType, new[] { alipayDataExpr, alipayExpr }, bodyExprs);
            // code: entity => { ... }
            var lambdaExpr = Expression.Lambda<Func<object, AlipayData>>(methodBodyExpr, parameterExpr);
            var func = lambdaExpr.Compile();
            return func;
        }

        private static string GetConvertMethod(Type type)
        {
            return ConvertMethodNames[type];
        }

        /// <summary>将WxPayData转换成IAlipay的委托
        /// </summary>
        public static Func<AlipayData, T> GetAlipay<T>() where T : IAlipay
        {
            var sourceType = typeof(AlipayData);
            var targetType = typeof(T);
            // 定义参数,传递进来的AlipayData
            var parameterExpr = Expression.Parameter(sourceType, "alipayData");
            var bodyExprs = new List<Expression>();
            //code:var response=new Response();
            var alipayExpr = Expression.Variable(targetType, "alipay");
            var newAlipayExpr = Expression.New(targetType);
            var assignAlipayExpr = Expression.Assign(alipayExpr, newAlipayExpr);
            bodyExprs.Add(assignAlipayExpr);
            //获取Response的全部属性
            var properties = ReflectUtil.GetProperties(targetType);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<AlipayDataElementAttribute>();
                if (attribute != null)
                {
                    var nameExpr = Expression.Constant(attribute.Name);
                    //code : wxPayData.GetValue("name");
                    var getValueExpr = Expression.Call(parameterExpr,
                        sourceType.GetTypeInfo().GetMethod("GetValue", new[] { typeof(string) }), nameExpr);
                    //code: response.Name=alipayData.GetValue("name");
                    var fieldExpr = Expression.Property(alipayExpr, property);
                    var convertValueExpr = Expression.Call(null,
                        typeof(Convert).GetTypeInfo()
                            .GetMethod(GetConvertMethod(property.PropertyType), new[] { typeof(object) }), getValueExpr);
                    var assignFieldExpr = Expression.Assign(fieldExpr, convertValueExpr);
                    //code: if(wxPayData.GetValue("") != null){ ... }
                    var ifNotNullExpr = Expression.IfThen(
                        Expression.NotEqual(getValueExpr, Expression.Constant(null)),
                        assignFieldExpr);
                    bodyExprs.Add(ifNotNullExpr);
                }
            }
            //此处需要注意,这里添加的相当于返回值
            bodyExprs.Add(alipayExpr);
            var methodBodyExpr = Expression.Block(targetType, new[] { alipayExpr }, bodyExprs);
            // code: entity => { ... }
            var lambdaExpr = Expression.Lambda<Func<AlipayData, T>>(methodBodyExpr, parameterExpr);
            var func = lambdaExpr.Compile();
            return func;
        }

        /// <summary>将AlipayData转换成IAlipay
        /// </summary>
        public static T ToAlipay<T>(AlipayData alipayData) where T : IAlipay
        {
            Delegate method;
            if (!DataToAlipayDict.TryGetValue(typeof(T), out method))
            {
                method = GetAlipay<T>();
                DataToAlipayDict.Add(typeof(T), method);
            }
            var func = method as Func<AlipayData, T>;
            if (func != null)
            {
                return func.Invoke(alipayData);
            }
            return default(T);
        }
    }
}
