namespace QuickPay.WxPay.Notify
{
    /// <summary>微信支付统一下单通知
    /// </summary>
    public class UnifiedOrderNotify : WxPayNotify
    {
        /// <summary>微信开放平台审核通过的应用APPID
        /// </summary>
        [WxPayDataElement("appid")]
        public string AppId { get; set; }

        /// <summary>微信支付分配的商户号
        /// </summary>
        [WxPayDataElement("mch_id")]
        public string MchId { get; set; }

        /// <summary>随机字符串，不长于32位
        /// </summary>
        [WxPayDataElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>签名
        /// </summary>
        [WxPayDataElement("sign")]
        public string Sign { get; set; }

        /// <summary>用户在商户appid下的唯一标识
        /// </summary>
        [WxPayDataElement("openid")]
        public string OpenId { get; set; }

        /// <summary>交易类型
        /// </summary>
        [WxPayDataElement("trade_type")]
        public string TradeType { get; set; }

        /// <summary>银行类型，采用字符串类型的银行标识
        /// </summary>
        [WxPayDataElement("bank_type")]
        public string BankType { get; set; }

        /// <summary>订单总金额，单位为分
        /// </summary>
        [WxPayDataElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>现金支付金额订单现金支付金额
        /// </summary>
        [WxPayDataElement("cash_fee")]
        public int CashFee { get; set; }

        /// <summary>微信支付订单号(微信生成的)
        /// </summary>
        [WxPayDataElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>商户系统的订单号，与请求一致。
        /// </summary>
        [WxPayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>支付完成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010
        /// </summary>
        [WxPayDataElement("time_end")]
        public string TimeEnd { get; set; }

        /******************************************/

        /// <summary>微信支付分配的终端设备号
        /// </summary>
        [WxPayDataElement("device_info", false)]
        public string DeviceInfo { get; set; }

        /// <summary>用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
        /// </summary>
        [WxPayDataElement("is_subscribe", false)]
        public string IsSubscribe { get; set; }

        /// <summary>货币类型，符合ISO4217标准的三位字母代码
        /// </summary>
        [WxPayDataElement("fee_type", false)]
        public string FeeType { get; set; }

        /// <summary>货币类型，符合ISO4217标准的三位字母代码
        /// </summary>
        [WxPayDataElement("cash_fee_type", false)]
        public string CashFeeType { get; set; }

        /// <summary>代金券或立减优惠金额 《=订单总金额，订单总金额-代金券或立减优惠金额=现金支付金额
        /// </summary>
        [WxPayDataElement("coupon_fee", false)]
        public int CouponFee { get; set; }

        /// <summary>代金券或立减优惠使用数量
        /// </summary>
        [WxPayDataElement("coupon_count", false)]
        public int CouponCount { get; set; }

        /// <summary> 代金券或立减优惠ID,$n为下标，从0开始编号
        /// </summary>
        [WxPayDataElement("coupon_id_$n", false)]
        public string CouponId { get; set; }

        /// <summary>商家数据包，原样返回
        /// </summary>
        [WxPayDataElement("attach", false)]
        public string Attach { get; set; }
    }
}
