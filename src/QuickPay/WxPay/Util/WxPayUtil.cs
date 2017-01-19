using System.Linq;
using System.Reflection;
using QuickPay.Common;

namespace QuickPay.WxPay.Util
{
    public class WxPayUtil
    {
        /// <summary>验证请求的参数
        /// </summary>
        public static bool VerifyRequestData<T>(IWxPayRequest<T> request) where T : WxPayResponse
        {
            //获取属性中名称不为Sign的
            var properties = request.GetType().GetTypeInfo()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name != WxPayConsts.Sign);
            //获取需要进行验证的参数
            var requireds = properties.Where(x => x.GetCustomAttribute<WxPayDataElementAttribute>().IsRequired);
            foreach (var property in requireds)
            {
                var value = property.GetValue(request);
                if (value == null)
                {
                    throw new WxPayException($"参数{property.Name}不能为空");
                }
            }

            //获取当前对象的值
            return true;
        }

        /// <summary>微信签名
        /// </summary>
        public static string Sign(WxPayData wxPayData, string key)
        {
            var url = wxPayData.ToUrl();
            var stringSignTemp = $"{url}&key={key}";
            return Md5Encryptor.GetMd5(stringSignTemp).ToUpper();
        }

    }
}
