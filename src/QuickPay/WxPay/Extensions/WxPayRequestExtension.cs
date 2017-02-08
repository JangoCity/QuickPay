using QuickPay.Common;

namespace QuickPay.WxPay.Extensions
{
    public static class WxPayRequestExtension
    {
        /// <summary>将WxPayData转换为Json,主要取出里面的集合,生成Json
        /// </summary>
        public static string ToJson(this WxPayData wxPayData)
        {
            return JsonSerializer.Serialize(wxPayData.GetValues());
        }
    }
}
