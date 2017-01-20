using System.Reflection;
using QuickPay.Alipay.Request;

namespace QuickPay.Alipay.Extensions
{
    public static class AlipayRequestExtension
    {

        /// <summary>将BizContent转换为AlipayData
        /// </summary>
        public static AlipayData ToAlipayData(this BizContent bizContent)
        {
            var alipayData=new AlipayData();
            //查询出实体中包含WxPayDataElementAttribute标签的属性
            var properties =
                bizContent.GetType().GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                //获取该属性的Attribute
                var attribute = property.GetCustomAttribute<AlipayDataElementAttribute>();
                if (attribute != null)
                {
                    var value = property.GetValue(bizContent);
                    if (value != null)
                    {
                        alipayData.SetValue(attribute.Name, value);
                    }
                }
            }
            return alipayData;
        }

        /// <summary>将BizContent转换为Json
        /// </summary>
        public static string ToJson(this BizContent bizContent)
        {
            return bizContent.ToAlipayData().ToJson();
        }
    }
}
