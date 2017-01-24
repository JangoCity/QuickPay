using QuickPay.WxPay.Response;

namespace QuickPay.WxPay.Request
{
    /// <summary>查询订单请求
    /// </summary>
    public class QueryOrderRequest : TradeRequest<QueryOrderResponse>
    {
        /// <summary>请求地址
        /// </summary>
        public override string Url { get; } = "https://api.mch.weixin.qq.com/pay/orderquery";

        /// <summary>微信的订单号，优先使用
        /// </summary>
        [WxPayDataElement("transaction_id", false)]
        public string TransactionId { get; set; }

        /// <summary>商户系统内部的订单号，当没提供transaction_id时需要传这个。
        /// </summary>
        [WxPayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        public QueryOrderRequest()
        {

        }

        public QueryOrderRequest(string outTradeNo)
        {
            OutTradeNo = outTradeNo;
        }
    }
}
