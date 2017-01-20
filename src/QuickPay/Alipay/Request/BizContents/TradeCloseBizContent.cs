// ReSharper disable once CheckNamespace
namespace QuickPay.Alipay.Request
{
    /// <summary>alipay.trade.close (统一收单交易关闭接口)
    /// </summary>
    public class TradeCloseBizContent : BizContent
    {
        /// <summary>订单支付时传入的商户订单号,和支付宝交易号不能同时为空。 trade_no,out_trade_no如果同时存在优先取trade_no
        /// </summary>
        [AlipayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>该交易在支付宝系统中的交易流水号。最短 16 位，最长 64 位。和out_trade_no不能同时为空，如果同时传了 out_trade_no和 trade_no，则以 trade_no为准。
        /// </summary>
        [AlipayDataElement("trade_no", false)]
        public string TradeNo { get; set; }

        /// <summary>卖家端自定义的的操作员 ID
        /// </summary>
        [AlipayDataElement("operator_id",false)]
        public string OperatorId { get; set; }

        public TradeCloseBizContent()
        {
            
        }

        public TradeCloseBizContent(string outTradeNo)
        {
            OutTradeNo = outTradeNo;
        }
    }
}
