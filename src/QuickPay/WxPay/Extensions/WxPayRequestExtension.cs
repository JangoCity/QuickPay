using System.Reflection;
using QuickPay.Common;

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

        /// <summary>将WxPayData转换为Json,主要取出里面的集合,生成Json
        /// </summary>
        public static string ToJson(this WxPayData wxPayData)
        {
            return JsonSerializer.Serialize(wxPayData.GetValues());
        }

        /// <summary>将WxPayData转换成Response
        /// </summary>
        public static WxPayResponse ToResponse<T>(WxPayData wxPayData) where T : WxPayResponse
        {
            var t = System.Activator.CreateInstance(typeof(T));
            //获取全部属性
            var properties = t.GetType().GetTypeInfo().GetProperties(BindingFlags.CreateInstance | BindingFlags.Public);
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<WxPayDataElementAttribute>();
                if (attribute != null)
                {
                    //得到WxPayData中该Key的值
                    var value = wxPayData.GetValue(attribute.Name);
                    if (value != null)
                    {
                        property.SetValue(t, value);
                    }
                }
            }
            return t as T;
        }
    }
}
