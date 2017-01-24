using QuickPay.WxPay.Response;

namespace QuickPay.WxPay.Request
{
    /// <summary>退款,一笔订单可能有多次退款,每次退款都需要唯一的编号
    /// </summary>
    public class RefundRequest : TradeRequest<RefundResponse>
    {
        /// <summary>退款地址
        /// </summary>
        public override string Url { get; } = "https://api.mch.weixin.qq.com/secapi/pay/refund";

        /// <summary>商户侧传给微信的订单号
        /// </summary>
        [WxPayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>微信生成的订单号，在支付通知中有返回,与out_trade_no二选一
        /// </summary>
        [WxPayDataElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>商户系统内部的退款单号，商户系统内部唯一，同一退款单号多次请求只退一笔
        /// </summary>
        [WxPayDataElement("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>订单总金额，单位为分，只能为整数
        /// </summary>
        [WxPayDataElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>退款总金额，订单总金额，单位为分，只能为整数
        /// </summary>
        [WxPayDataElement("refund_fee")]
        public int RefundFee { get; set; }

        /// <summary>操作员帐号, 默认为商户号
        /// </summary>
        [WxPayDataElement("op_user_id")]
        public string OpUserId { get; set; }

        public RefundRequest()
        {
            
        }

        public RefundRequest(string outTradeNo, string outRefundNo, int totalFee, int refundFee)
        {
            OutRefundNo = outTradeNo;
            OutRefundNo = outRefundNo;
            TotalFee = totalFee;
            RefundFee = refundFee;
        }

        public override void SetNecessary(WxPayConfig config)
        {
            base.SetNecessary(config);
            OpUserId = config.MchId;
        }

        /************************可选参数**********************/

        /// <summary>终端设备号
        /// </summary>
        [WxPayDataElement("device_info", false)]
        public string DeviceInfo { get; set; }

        /// <summary>货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY
        /// </summary>
        [WxPayDataElement("refund_fee_type",false)]
        public string RefundFeeType { get; set; } = WxPayConsts.FeeType.Cny;

        /// <summary>仅针对老资金流商户使用 REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款（默认使用未结算资金退款）REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款
        /// </summary>
        [WxPayDataElement("refund_account",false)]
        public string RefundAccount { get; set; } = WxPayConsts.RefundAccount.Unsettled;
    }
}
