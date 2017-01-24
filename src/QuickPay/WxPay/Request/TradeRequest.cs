using QuickPay.WxPay.Util;

namespace QuickPay.WxPay.Request
{
    /// <summary>交易请求
    /// </summary>
    public abstract class TradeRequest<T> : BaseRequest<T> where T : WxPayResponse
    {
        /// <summary>微信支付分配的商户号
        /// </summary>
        [WxPayDataElement("mch_id")]
        public string MchId { get; protected set; }
        /// <summary>商户系统内部的订单号,32个字符内、可包含字母
        /// </summary>
        [WxPayDataElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        /// </summary>
        public override void SetNecessary(WxPayConfig config)
        {
            base.SetNecessary(config);
            AppId = config.AppId;
            MchId = config.MchId;
            NonceStr = WxPayUtil.GenerateNonceStr();
        }
    }
}
