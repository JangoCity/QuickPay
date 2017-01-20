namespace QuickPay.Alipay.Request
{
    /// <summary>支付宝基础请求(主要为新版支付宝)
    /// </summary>
    public abstract class BaseRequest<T> : IAlipayRequest<T> where T : AlipayResponse
    {
        /// <summary>请求网关
        /// </summary>
        public string Gateway { get; } = "https://openapi.alipay.com/gateway.do";

        /*********************来自Config*******************/

        /// <summary>支付宝分配给开发者的应用ID
        /// </summary>
        [AlipayDataElement("appid")]
        public string AppId { get; set; }

        /// <summary>仅支持JSON
        /// </summary>
        [AlipayDataElement("format", false)]
        public string Format { get; set; }

        /// <summary>请求使用的编码格式
        /// </summary>
        [AlipayDataElement("charset")]
        public string Charset { get; set; }

        /// <summary>商户生成签名字符串所使用的签名算法类型，目前支持RSA2和RSA
        /// </summary>
        [AlipayDataElement("sign_type")]
        public string SignType { get; set; }

        /// <summary>版本号
        /// </summary>
        [AlipayDataElement("version")]
        public string Version { get; set; }

        /**********************每个请求重写*******************/

        /// <summary>接口名称,alipay.trade.wap.pay
        /// </summary>
        [AlipayDataElement("method")]
        public string Method { get; set; }

        /// <summary>发送请求的时间，格式"yyyy-MM-dd HH:mm:ss"
        /// </summary>
        [AlipayDataElement("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>回调通知地址
        /// </summary>
        [AlipayDataElement("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>业务请求参数的集合
        /// </summary>
        [AlipayDataElement("biz_content")]
        public BizContent BizContent { get; set; }


        public void SetNecessary(AlipayConfig config)
        {
            AppId = config.AppId;
            Format = config.Format;
            Charset = config.Charset;
            SignType = config.SignType;
            Version = config.Version;
        }
    }
}
