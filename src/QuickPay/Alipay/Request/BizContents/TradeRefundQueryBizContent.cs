using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPay.Alipay.Request.BizContents
{
    /// <summary>alipay.trade.fastpay.refund.query (统一收单交易退款查询)
    /// </summary>
    public class TradeRefundQueryBizContent : BizContent
    {
        /// <summary>订单支付时传入的商户订单号,和支付宝交易号不能同时为空。 trade_no,out_trade_no如果同时存在优先取trade_no
        /// </summary>
        [AlipayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>支付宝交易号，和商户订单号不能同时为空	
        /// </summary>
        [AlipayDataElement("trade_no", false)]
        public string TradeNo { get; set; }

        /// <summary>请求退款接口时，传入的退款请求号，如果在退款请求时未传入，则该值为创建交易时的外部交易号
        /// </summary>
        [AlipayDataElement("out_request_no")]
        public string OutRequestNo { get; set; }

        public TradeRefundQueryBizContent()
        {
            
        }

        /// <summary>一笔订单一次退款,退款时未传入交易编号
        /// </summary>
        public TradeRefundQueryBizContent(string outTradeNo) : this(outTradeNo, outTradeNo)
        {

        }

        /// <summary>一笔订单一次退款,退款时无论是否纯如交易编号,该api是最合理的
        /// </summary>
        /// <param name="outTradeNo">订单支付时传入的商户订单号</param>
        /// <param name="outRequestNo">请求退款接口时,传入的退款请求号</param>
        public TradeRefundQueryBizContent(string outTradeNo, string outRequestNo)
        {
            OutTradeNo = outTradeNo;
            OutRequestNo = outRequestNo;
        }
    }
}
