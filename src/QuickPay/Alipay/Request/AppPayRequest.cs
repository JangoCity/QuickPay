using QuickPay.Alipay.Response;

namespace QuickPay.Alipay.Request
{
    /// <summary>alipay.trade.app.pay,App支付下单
    /// </summary>
    public class AppPayRequest : BaseRequest<AppPayResponse>
    {
        public override string Method { get; set; } = AlipayConsts.AlipayMethod.AppPay;

        /// <summary>回调通知地址
        /// </summary>
        [AlipayDataElement("notify_url")]
        public string NotifyUrl { get; set; }

        public AppPayRequest()
        {

        }

        public AppPayRequest(AppPayBizContent bizContent,string notifyUrl)
        {
            NotifyUrl = notifyUrl;
            BizContent = bizContent;
        }
    }
}
