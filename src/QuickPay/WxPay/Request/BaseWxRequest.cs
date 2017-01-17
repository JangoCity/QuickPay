namespace QuickPay.WxPay.Request
{
    public abstract class BaseWxRequest<T> : IWxPayRequest<T> where T : WxPayResponse
    {
        /*
         * 下列参数,在同一个Config下都是相同的
         * 
         */

        [WxPayDataElement("appid")]
        public string AppId { get; set; }

        [WxPayDataElement("mch_id")]
        public string MchId { get; set; }

        [WxPayDataElement("sign_type")]
        public string SignType { get; set; }

        /*
         * 下列参数,每个请求都需要,但是每个请求都会不同
         * 
         */
        public string Url { get; set; }

        /// <summary>随机字符串，长度要求在32位以内
        /// </summary>
        [WxPayDataElement("nonce_str")]
        public string Noncestr { get; set; }
 
    }
}
