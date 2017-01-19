using System.Reflection;

namespace QuickPay.WxPay.Extensions
{
    public static class WxPayRequestExtension
    {
        /// <summary>转换为WxPayData
        /// </summary>
        public static WxPayData ToWxPayData<T>(this IWxPayRequest<T> request) where T : WxPayResponse
        {
            var payData = new WxPayData();
            //查询出实体中包含WxPayDataElementAttribute标签的属性
            var properties = request.GetType().GetTypeInfo().GetProperties(BindingFlags.CreateInstance | BindingFlags.Public);
            foreach (var property in properties)
            {
                //获取该属性的Attribute
                var attribute = property.GetCustomAttribute<WxPayDataElementAttribute>();
                if (attribute != null)
                {
                    var value = property.GetValue(request);
                    if (value != null)
                    {
                        payData.SetValue(attribute.Name, value);
                    }
                }
            }
            return payData;
        }
    }
}
