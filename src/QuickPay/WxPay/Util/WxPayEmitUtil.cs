using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection.Emit;
using QuickPay.Common;

namespace QuickPay.WxPay.Util
{
    public class WxPayEmitUtil
    {
        /// <summary>将Request转换为Data的委托集合
        /// </summary>
        private static readonly IDictionary<Type, Delegate> RequestToDataDict =
            new ConcurrentDictionary<Type, Delegate>();

        /// <summary>将Data转换为Response的委托集合
        /// </summary>
        private static readonly IDictionary<Type, Delegate> DataToResponseDict =
            new ConcurrentDictionary<Type, Delegate>();

        /// <summary>将请求转换成WxPayData
        /// </summary>
        public static Func<T, WxPayData> GetWxPayDataFunc<T>() where T : IWxPayRequest
        {
            //目标类型
            var type = typeof(WxPayData);
            var properties = ReflectUtil.GetProperties(typeof(T));
            DynamicMethod dynamicMethod = new DynamicMethod("ObjectToDictionary", type,
                new Type[] {typeof(T)}, typeof(object), true)
            {
                InitLocals = true
            };
            ILGenerator il = dynamicMethod.GetILGenerator();
            //结束标签
            Label endLabel = il.DefineLabel();
            //定义变量 var user=new User();他为第0个变量
            LocalBuilder obj = il.DeclareLocal(type);
            foreach (var property in properties)
            {

            }
            return default(Func<T, WxPayData>);
        }

    }
}
