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

        /// <summary>设置必要参数
        /// </summary>
        public virtual void SetNecessary(WxPayConfig config)
        {
            AppId = config.AppId;
        }
    }
}
