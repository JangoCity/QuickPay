namespace QuickPay.WxPay.Response
{
    /// <summary>查询订单返回
    /// </summary>
    public class QueryOrderResponse : TradeResponse
    {
        /// <summary>微信分配的公众账号ID
        /// </summary>
        [WxPayDataElement("appid")]
        public string AppId { get; set; }

        /// <summary>微信支付分配的商户号
        /// </summary>
        [WxPayDataElement("mch_id")]
        public string MchId { get; set; }

        /// <summary>商户号
        /// </summary>
        [WxPayDataElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>签名
        /// </summary>
        [WxPayDataElement("sign")]
        public string Sign { get; set; }

    }
}

