using QuickPay.Alipay.Response;

namespace QuickPay.Alipay.Request
{
    /// <summary>alipay.trade.query (统一收单线下交易查询)
    /// </summary>
    public class TradeQueryRequest : BaseRequest<TradeQueryResponse>
    {
        public override string Method { get; set; } = AlipayConsts.AlipayMethod.TradeQuery;

        /// <summary>token
        /// </summary>
        [AlipayDataElement("app_auth_token", false)]
        public string AppAuthToken { get; set; }

        public TradeQueryRequest()
        {
        }

        public TradeQueryRequest(TradeQueryBizContent bizContent)
        {
            BizContent = bizContent;
        }
    }
}
