using QuickPay.Common;
using QuickPay.WxPay.Util;

namespace QuickPay.WxPay.Extensions
{
    public static class WxPayRequestExtension
    {
        /// <summary>转换为WxPayData
        /// </summary>
        public static WxPayData ToWxPayData<T>(this IWxPayRequest<T> request) where T : WxPayResponse
        {
            return WxPayReflectUtil.ToWxPayData(request);
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
            return WxPayReflectUtil.ToWxPayResponse<T>(wxPayData);
        }
    }
}
