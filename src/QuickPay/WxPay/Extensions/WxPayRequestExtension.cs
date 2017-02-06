using QuickPay.Common;
using QuickPay.WxPay.Util;

namespace QuickPay.WxPay.Extensions
{
    public static class WxPayRequestExtension
    {
        /// <summary>转换为WxPayData
        /// </summary>
        public static WxPayData ToWxPayData(this IWxPay wxPay)
        {
            return WxPayReflectUtil.ToWxPayData(wxPay);
        }
        /// <summary>将WxPayData转换成Response
        /// </summary>
        public static IWxPay ToWxPay<T>(WxPayData wxPayData) where T : IWxPay
        {
            return WxPayReflectUtil.ToWxPay<T>(wxPayData);
        }

        /// <summary>将WxPayData转换为Json,主要取出里面的集合,生成Json
        /// </summary>
        public static string ToJson(this WxPayData wxPayData)
        {
            return JsonSerializer.Serialize(wxPayData.GetValues());
        }
    }
}
