using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickPay.WxPay.Response;

namespace QuickPay.WxPay.Request
{
    /// <summary>查询退款请求
    /// </summary>
    public class RefundQueryRequest : BaseRequest<RefundQueryResponse>
    {
        /// <summary>查询退款api地址
        /// </summary>
        public override string Url { get; } = "https://api.mch.weixin.qq.com/pay/refundquery";

        /// <summary>微信的订单号，优先使用
        /// </summary>
        [WxPayDataElement("transaction_id", false)]
        public string TransactionId { get; set; }

        /// <summary>商户系统内部的订单号，当没提供transaction_id时需要传这个。
        /// </summary>
        [WxPayDataElement("out_trade_no", false)]
        public string OutTradeNo { get; set; }

        /// <summary>退款单号
        /// </summary>
        [WxPayDataElement("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>微信生成的退款单号，在申请退款接口有返回
        /// </summary>
        [WxPayDataElement("refund_id")]
        public string RefundId { get; set; }

        public RefundQueryRequest()
        {
            
        }

        public RefundQueryRequest(string outRefundNo, string nonceStr)
        {
            OutRefundNo = outRefundNo;
            NonceStr = nonceStr;
        }
    }
}
