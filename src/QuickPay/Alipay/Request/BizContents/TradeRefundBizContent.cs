// ReSharper disable once CheckNamespace
namespace QuickPay.Alipay.Request
{
    /// <summary>alipay.trade.refund (统一收单交易退款接口)
    /// </summary>
    public class TradeRefundBizContent : BizContent
    {
        /// <summary>订单支付时传入的商户订单号,和支付宝交易号不能同时为空。 trade_no,out_trade_no如果同时存在优先取trade_no
        /// </summary>
        [AlipayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>(Price类型)需要退款的金额，该金额不能大于订单金额,单位为元，支持两位小数
        /// </summary>
        [AlipayDataElement("refund_amount")]
        public decimal RefundAmount { get; set; }

        /// <summary>支付宝交易号，和商户订单号不能同时为空
        /// </summary>
        [AlipayDataElement("trade_no", false)]
        public string TradeNo { get; set; }

        /// <summary>退款的原因说明
        /// </summary>
        [AlipayDataElement("refund_reason", false)]
        public string RefundReason { get; set; }

        /// <summary>标识一次退款请求，同一笔交易多次退款需要保证唯一，如需部分退款，则此参数必传。
        /// </summary>
        [AlipayDataElement("out_request_no", false)]
        public string OutRequestNo { get; set; }

        /// <summary>商户的操作员编号
        /// </summary>
        [AlipayDataElement("operator_id", false)]
        public string OperatorId { get; set; }

        /// <summary>商户的门店编号
        /// </summary>
        [AlipayDataElement("store_id", false)]
        public string StoreId { get; set; }

        /// <summary>商户的终端号
        /// </summary>
        [AlipayDataElement("terminal_id", false)]
        public string TerminalId { get; set; }

        public TradeRefundBizContent()
        {
            
        }

        /// <summary>一笔订单退款一次
        /// </summary>
        public TradeRefundBizContent(string outTradeNo, decimal refundAmount)
        {
            OutTradeNo = outTradeNo;
            RefundAmount = refundAmount;
        }

        /// <summary>一笔订单多次对款,需要保证OutRequestNo唯一
        /// </summary>
        public TradeRefundBizContent(string outTradeNo, decimal refundAmount, string outRequestNo)
            : this(outTradeNo, refundAmount)
        {
            OutRequestNo = outRequestNo;
        }
    }
}
