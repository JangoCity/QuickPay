using QuickPay.WxPay.Response;

namespace QuickPay.WxPay.Request
{
    /// <summary>UnifiedOrderResponse,统一下单
    /// </summary>
    public class UnifiedOrderRequest : BaseWxRequest<UnifiedOrderResponse>
    {
        public UnifiedOrderRequest()
        {
            Url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        }

    }
}
