namespace QuickPay.WxPay.Request
{
    public abstract class BaseRequest<T> : IWxPayRequest<T> where T : WxPayResponse
    {
        public abstract string Url { get; }

        /**
         * 参数来自Config
         * 
         */

        [WxPayDataElement("appid")]
        public string AppId { get; protected set; }

        [WxPayDataElement("mch_id")]
        public string MchId { get; protected set; }

        public void SetNecessary(string appId, string mchId)
        {
            AppId = appId;
            MchId = mchId;
        }

        /**
         * 必须参数
         * 
         */

        /// <summary>商户系统内部的订单号,32个字符内、可包含字母
        /// </summary>
        [WxPayDataElement("nonce_str")]
        public abstract string NonceStr { get; set; }

    }
}
