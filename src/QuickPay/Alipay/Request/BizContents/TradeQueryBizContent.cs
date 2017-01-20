// ReSharper disable once CheckNamespace
namespace QuickPay.Alipay.Request
{
    /// <summary>>alipay.trade.query (统一收单线下交易查询)
    /// </summary>
    public class TradeQueryBizContent : BizContent
    {
        /// <summary>订单支付时传入的商户订单号,和支付宝交易号不能同时为空。 trade_no,out_trade_no如果同时存在优先取trade_no
        /// </summary>
        [AlipayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>支付宝交易号，和商户订单号不能同时为空	
        /// </summary>
        [AlipayDataElement("trade_no", false)]
        public string TradeNo { get; set; }

        public TradeQueryBizContent()
        {
            
        }

        public TradeQueryBizContent(string outTradeNo)
        {
            OutTradeNo = outTradeNo;
        }
    }
}
