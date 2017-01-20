using QuickPay.Alipay.Response;

namespace QuickPay.Alipay.Request
{
    /// <summary>alipay.trade.refund (统一收单交易退款接口)
    /// </summary>
    public class TradeRefundRequest : BaseRequest<TradeRefundResponse>
    {
        public override string Method { get; set; } = AlipayConsts.AlipayMethod.TradeRefund;

        /// <summary>token
        /// </summary>
        [AlipayDataElement("app_auth_token", false)]
        public string AppAuthToken { get; set; }

        public TradeRefundRequest()
        {
        }

        public TradeRefundRequest(TradeRefundBizContent bizContent)
        {
            BizContent = bizContent;
        }
    }
}
