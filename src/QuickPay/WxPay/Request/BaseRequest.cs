namespace QuickPay.WxPay.Request
{
    public abstract class BaseRequest<T> : IWxPayRequest<T> where T : WxPayResponse
    {
        public abstract string Url { get; }

        /**
         * 参数来自WxPayConfig
         */

        /// <summary>微信支付分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        [WxPayDataElement("appid")]
        public string AppId { get; protected set; }

        /// <summary>微信支付分配的商户号
        /// </summary>
        [WxPayDataElement("mch_id")]
        public string MchId { get; protected set; }

        /// <summary>签名类型，默认为MD5，支持HMAC-SHA256和MD5
        /// </summary>
        [WxPayDataElement("sign_type")]
        public string SignType { get; protected set; }

        /// <summary>
        /// </summary>
        public virtual void SetNecessary(WxPayConfig config)
        {
            AppId = config.AppId;
            MchId = config.MchId;
            SignType = config.SignType;
        }

        /// <summary>商户系统内部的订单号,32个字符内、可包含字母
        /// </summary>
        [WxPayDataElement("nonce_str")]
        public string NonceStr { get; set; }
    }
}
