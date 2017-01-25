using System;
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
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.Name != WxPayConsts.SignField.Sign);
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

        /// <summary>生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
        /// </summary>
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>生成随机串，随机串包含字母或数字
        /// </summary>
        public static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }






    }
}
