namespace QuickPay.Alipay.Request
{
    public abstract class MapiRequest<T> : IAlipayRequest<T> where T : AlipayResponse
    {
        public string Gateway { get; } = "https://mapi.alipay.com/gateway.do";

        /// <summary>接口名称,不可空,
        /// </summary>
        [AlipayDataElement("service")]
        public abstract string Service { get; set; }

        /// <summary>签约的支付宝账号对应的支付宝唯一用户号。以2088开头的16位纯数字组成。
        /// </summary>
        [AlipayDataElement("partner")]
        public string Partner { get; set; }

        /// <summary>编码方式
        /// </summary>
        [AlipayDataElement("_input_charset")]
        public string Charset { get; set; }

        /// <summary>签名方式,DSA、RSA、MD5三个值可选，必须大写
        /// </summary>
        [AlipayDataElement("sign_type")]
        public string SignType { get; set; }

        /// <summary>通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>设置请求的必须参数
        /// </summary>
        public void SetNecessary(AlipayConfig config)
        {
            Partner = config.Pid;
            Charset = config.MCharset;
            SignType = config.MSignType;
        }
    }
}
