namespace QuickPay.Alipay
{
    /// <summary>支付宝支付配置文件
    /// </summary>
    public class AlipayConfig
    {
        /// <summary>支付宝分配给开发者的应用ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>仅支持JSON
        /// </summary>
        public string Format { get; set; } = "JSON";

        /// <summary>请求使用的编码格式，如utf-8,gbk,gb2312等
        /// </summary>
        public string Charset { get; set; } = AlipayConsts.Charset.Utf8;

        /// <summary>支付宝公钥
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>支付宝私钥
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>商户生成签名字符串所使用的签名算法类型，目前支持RSA2和RSA，推荐使用RSA2
        /// </summary>
        public string SignType { get; set; } = AlipayConsts.SignType.Rsa2;
        /// <summary>版本号
        /// </summary>
        public string Version { get; set; } = "1.0";

        /// <summary>收款支付宝用户ID。 如果该值为空，则默认为商户签约账号对应的支付宝用户ID
        /// </summary>
        public string SellerId { get; set; }

        /// <summary>合作伙伴身份（PID），以2088开头的16位纯数字(旧版的支付宝接口会使用)
        /// </summary>
        public string Pid { get; set; }

        /// <summary>旧版接口Mapi的签名方式
        /// </summary>
        public string MSignType { get; set; } = AlipayConsts.SignType.Rsa;

        /// <summary>旧版接口Mapi的编码方式
        /// </summary>
        public string MCharset { get; set; } = AlipayConsts.Charset.Utf8;

        /// <summary>mapi公钥(旧版手机网站支付,即时到帐,批量付款到支付宝等接口公钥)
        /// </summary>
        public string MPublicKey { get; set; }

        /// <summary>mapi私钥(旧版手机网站支付,即时到帐,批量付款到支付宝等接口私钥)
        /// </summary>
        public string MPrivateKey { get; set; }

    }
}
