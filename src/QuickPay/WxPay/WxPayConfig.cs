namespace QuickPay.WxPay
{
    /// <summary>微信支付配置
    /// </summary>
    public class WxPayConfig
    {
        /// <summary>微信支付分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        public string AppId { get; set; }

        /// <summary>微信支付分配的商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>加密的Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>密码
        /// </summary>
        public string Appsecret { get; set; }

        /// <summary>本地IP地址
        /// </summary>
        public string LocalAddress { get; set; }

        /// <summary>本地的网址
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>Url地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>签名类型
        /// </summary>
        public string SignType { get; set; } = WxPayConsts.SignType.Md5;

        /// <summary>SSL证书
        /// </summary>
        public string SslPassword { get; set; }
 
    }
}
