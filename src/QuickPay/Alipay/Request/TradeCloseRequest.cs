using QuickPay.Alipay.Response;

namespace QuickPay.Alipay.Request
{
    /// <summary>alipay.trade.close (统一收单交易关闭接口)
    /// </summary>
    public class TradeCloseRequest : BaseRequest<TradeCloseResponse>
    {
        public override string Method { get; set; } = AlipayConsts.AlipayMethod.TradeClose;

        /// <summary>回调通知地址
        /// </summary>
        [AlipayDataElement("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>token
        /// </summary>
        [AlipayDataElement("app_auth_token", false)]
        public string AppAuthToken { get; set; }

        public TradeCloseRequest()
        {
        }

        public TradeCloseRequest(TradeCloseBizContent bizContent,string notifyUrl)
        {
            NotifyUrl = notifyUrl;
            BizContent = bizContent;
        }
    }
}
