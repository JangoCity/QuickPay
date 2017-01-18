namespace QuickPay.WxPay
{
    public interface IWxPayRequest<T> where T : WxPayResponse
    {
        /// <summary>当前Request请求的Url地址
        /// </summary>
        string Url { get; }

        /// <summary>微信支付分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        string AppId { get; }

        /// <summary>微信支付分配的商户号
        /// </summary>
        string MchId { get; }

        /// <summary>随机字符串
        /// </summary>
        string NonceStr { get; }
    }
}
