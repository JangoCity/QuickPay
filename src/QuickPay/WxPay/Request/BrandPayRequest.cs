using Newtonsoft.Json;
using QuickPay.WxPay.Response;

namespace QuickPay.WxPay.Request
{
    public class BrandPayRequest : IWxPayRequest<BrandPayResponse>
    {
        [JsonIgnore]
        public string Url { get; } = "";

        /// <summary>商户注册具有支付权限的公众号成功后即可获得
        /// </summary>
        [WxPayDataElement("appid")]
        public string AppId { get; set; }

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

        /// <summary>签名算法，暂支持MD5
        /// </summary>
        [WxPayDataElement("signType")]
        public string SignType { get; set; } = WxPayConsts.SignType.Md5;

        public void SetNecessary(WxPayConfig config)
        {
            AppId = config.AppId;
        }
    }
}
