namespace QuickPay.WxPay.Response
{
    /// <summary>UnifiedOrderRequest,统一下单返回结果
    /// </summary>
    public class UnifiedOrderResponse : BaseResponse
    {
        /********************以下字段在return_code为SUCCESS的时候有返回********************/

        /// <summary>微信分配的公众账号ID
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
    }
}
