namespace QuickPay.WxPay
{
    public interface IWxPayRequest<T> where T : WxPayResponse
    {
        /// <summary>请求的Url地址
        /// </summary>
        string Url { get; set; }

        /// <summary>微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        string AppId { get; set; }

        /// <summary>微信支付分配的商户号
        /// </summary>
        string MchId { get; set; }

        /// <summary>随机字符串，不长于32位
        /// </summary>
        string Noncestr { get; set; }

        /// <summary>签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        string SignType { get; set; }

    }
}
