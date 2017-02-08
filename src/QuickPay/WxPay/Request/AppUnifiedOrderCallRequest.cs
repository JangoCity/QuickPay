using System;
using QuickPay.WxPay.Response;
using QuickPay.WxPay.Util;

namespace QuickPay.WxPay.Request
{
    /// <summary>App统一下单之后调起支付
    /// </summary>
    public class AppUnifiedOrderCallRequest: BaseRequest<AppUnifiedOrderCallResponse>
    {
        public override string Url { get; } = "";

        /// <summary>微信支付分配的商户号
        /// </summary>
        [WxPayDataElement("partnerid")]
        public string PartnerId { get; set; }

        /// <summary>微信返回的支付交易会话ID(统一下单之后返回的)
        /// </summary>
        [WxPayDataElement("prepayid")]
        public string PrepayId { get; set; }

        /// <summary>暂填写固定值Sign=WXPay
        /// </summary>
        [WxPayDataElement("package")]
        public string Package { get; set; } = "Sign=WXPay";

        /// <summary>随机字符串，不长于32位
        /// </summary>
        [WxPayDataElement("noncestr")]
        public string NonceStr { get; set; }

        /// <summary>时间戳
        /// </summary>
        [WxPayDataElement("timestamp")]
        public string TimeStamp { get; set; }

        public override void SetNecessary(WxPayConfig config)
        {
            base.SetNecessary(config);
            PartnerId = config.MchId;
        }

        public AppUnifiedOrderCallRequest()
        {
            
        }

        public AppUnifiedOrderCallRequest(string prepayId)
        {
            PrepayId = prepayId;
            TimeStamp = WxPayUtil.GenerateTimeStamp();
            NonceStr = WxPayUtil.GenerateNonceStr();
        }
    }
}
