using QuickPay.Alipay.Request.BizContents;
using QuickPay.Alipay.Response;

namespace QuickPay.Alipay.Request
{
    /// <summary>alipay.trade.fastpay.refund.query (统一收单交易退款查询)
    /// </summary>
    public class TradeRefundQueryRequest : BaseRequest<TradeRefundQueryResponse>
    {
        public override string Method { get; set; } = AlipayConsts.AlipayMethod.TradeRefundQuery;

        /// <summary>token
        /// </summary>
        [AlipayDataElement("app_auth_token", false)]
        public string AppAuthToken { get; set; }

        public TradeRefundQueryRequest()
        {
            
        }

        public TradeRefundQueryRequest(TradeRefundQueryBizContent bizContent)
        {
            BizContent = bizContent;
        }


    }
}
