namespace QuickPay.WxPay.Response
{
    /// <summary>退款返回
    /// </summary>
    public class RefundResponse : BaseResponse
    {
        /// <summary>微信分配的公众账号ID
        /// </summary>
        [WxPayDataElement("appid")]
        public string AppId { get; set; }

        /// <summary>微信支付分配的商户号
        /// </summary>
        [WxPayDataElement("mch_id")]
        public string MchId { get; set; }

        /// <summary>微信支付分配的终端设备号，与下单一致
        /// </summary>
        [WxPayDataElement("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>随机字符串，不长于32位
        /// </summary>
        [WxPayDataElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>微信订单号
        /// </summary>
        [WxPayDataElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>商户系统内部的订单号
        /// </summary>
        [WxPayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>商户退款单号
        /// </summary>
        [WxPayDataElement("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>微信退款单号
        /// </summary>
        [WxPayDataElement("refund_id")]
        public string RefundId { get; set; }

        /// <summary>退款渠道, ORIGINAL—原路退款 BALANCE—退回到余额
        /// </summary>
        [WxPayDataElement("refund_channel")]
        public string RefundChannel { get; set; }

        /// <summary>退款总金额,单位为分,可以做部分退款
        /// </summary>
        [WxPayDataElement("refund_fee")]
        public int RefundFee { get; set; }

        /// <summary>应结退款金额,去掉非充值代金券退款金额后的退款金额，退款金额=申请退款金额-非充值代金券退款金额，退款金额 《=申请退款金额
        /// </summary>
        [WxPayDataElement("settlement_refund_fee")]
        public int SettlementRefundFee { get; set; }

        /// <summary>订单总金额，单位为分，只能为整数
        /// </summary>
        [WxPayDataElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>应结订单金额,去掉非充值代金券金额后的订单总金额，应结订单金额=订单金额-非充值代金券金额，应结订单金额《=订单金额。
        /// </summary>
        [WxPayDataElement("settlement_total_fee")]
        public int SettlementTotalFee { get; set; }

        /// <summary>订单金额货币类型，符合ISO 4217标准的三位字母代码
        /// </summary>
        [WxPayDataElement("fee_type")]
        public string FeeType { get; set; }

        /// <summary>现金支付金额，单位为分，只能为整数
        /// </summary>
        [WxPayDataElement("cash_fee")]
        public int CashFee { get; set; }
        /// <summary>现金支付币种,货币类型，符合ISO 4217标准的三位字母代码
        /// </summary>
        [WxPayDataElement("cash_fee_type")]
        public string CashFeeType { get; set; }

    }
}
