using QuickPay.WxPay.Response;
using QuickPay.WxPay.Util;

namespace QuickPay.WxPay.Request
{
    /// <summary>JsApi调起支付请求
    /// </summary>
    public class JsApiUnifiedOrderCallRequest : BaseRequest<JsApiUnifiedOrderCallResponse>
    {
        public override string Url { get; } = "";

        /// <summary>当前的时间，其他详见时间戳规则
        /// </summary>
        [WxPayDataElement("timeStamp")]
        public string TimeStamp { get; set; }

        /// <summary>随机字符串，不长于32位
        /// </summary>
        [WxPayDataElement("nonceStr")]
        public string NonceStr { get; set; }

        /// <summary>统一下单接口返回的prepay_id参数值，提交格式如：prepay_id=***
        /// </summary>
        [WxPayDataElement("package")]
        public string Package => !string.IsNullOrWhiteSpace(PrepayId) ? $"{WxPayConsts.PrepayId}={PrepayId}" : "";

        /// <summary>预订单Id
        /// </summary>
        public string PrepayId { get; set; }

        public override void SetNecessary(WxPayConfig config)
        {
            base.SetNecessary(config);
            NonceStr = WxPayUtil.GenerateNonceStr();
            TimeStamp = WxPayUtil.GenerateTimeStamp();
        }

        public JsApiUnifiedOrderCallRequest()
        {

        }

        public JsApiUnifiedOrderCallRequest(string prepayId)
        {
            PrepayId = prepayId;
        }
    }
}
