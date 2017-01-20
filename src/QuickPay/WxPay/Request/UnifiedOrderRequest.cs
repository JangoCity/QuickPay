using Newtonsoft.Json.Linq;
using QuickPay.WxPay.Response;
namespace QuickPay.WxPay.Request
{
    /// <summary>UnifiedOrderResponse,统一下单
    /// </summary>
    public class UnifiedOrderRequest : BaseRequest<UnifiedOrderResponse>
    {
        /// <summary>统一下单接口地址
        /// </summary>
        public override string Url { get; } = "https://api.mch.weixin.qq.com/pay/unifiedorder";

        /// <summary>商品简单描述，该字段请按照规范传递
        /// </summary>
        [WxPayDataElement("body")]
        public string Body { get; set; }

        /// <summary>商户系统内部订单号，要求32个字符内、且在同一个商户号下唯一
        /// </summary>
        [WxPayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>订单总金额，单位为分
        /// </summary>
        [WxPayDataElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>APP和网页支付提交用户端ip，Native支付填调用微信支付API的机器IP
        /// </summary>
        [WxPayDataElement("spbill_create_ip")]
        public string SpbillCreateIp { get; set; }

        /// <summary>异步接收微信支付结果通知的回调地址，通知url必须为外网可访问的url，不能携带参数
        /// </summary>
        [WxPayDataElement("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>交易类型,取值如下：JSAPI，NATIVE，APP等
        /// </summary>
        [WxPayDataElement("trade_type")]
        public string TradeType { get; set; }

        public UnifiedOrderRequest()
        {
            
        }

        public UnifiedOrderRequest(string outTradeNo, int totalFee, string body, string nonceStr, string spbillCreateIp,
            string tradeType)
        {
            OutTradeNo = outTradeNo;
            TotalFee = totalFee;
            Body = body;
            NonceStr = nonceStr;
            SpbillCreateIp = spbillCreateIp;
            TradeType = tradeType;
        }

        /********************非必须参数********************/
        /// <summary>自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"
        /// </summary>
        [WxPayDataElement("device_info", false)]
        public string DeviceInfo { get; set; }

        /// <summary>商品详细列表，使用Json格式，传输签名前请务必使用CDATA标签将JSON文本串保护起来
        /// </summary>
        [WxPayDataElement("detail", false)]
        public string Detail { get; set; }

        /// <summary>附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用。
        /// </summary>
        [WxPayDataElement("attach", false)]
        public string Attach { get; set; }

        /// <summary>符合ISO 4217标准的三位字母代码，默认人民币：CNY
        /// </summary>
        [WxPayDataElement("fee_type", false)]
        public string FeeType { get; set; }

        /// <summary>订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010
        /// </summary>
        [WxPayDataElement("time_start", false)]
        public string TimeStart { get; set; }

        /// <summary>
        /// 订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010 
        /// 注意：最短失效时间间隔必须大于5分钟
        /// </summary>
        [WxPayDataElement("time_expire", false)]
        public string TimeExpire { get; set; }

        /// <summary>商品标记，使用代金券或立减优惠功能时需要的参数
        /// </summary>
        [WxPayDataElement("goods_tag", false)]
        public string GoodsTag { get; set; }

        /// <summary>商品ID,trade_type=NATIVE时（即扫码支付），此参数必传。此参数为二维码中包含的商品ID，商户自行定义
        /// </summary>
        [WxPayDataElement("product_id", false)]
        public string ProductId { get; set; }

        /// <summary>上传此参数no_credit--可限制用户不能使用信用卡支付
        /// </summary>
        [WxPayDataElement("limit_pay", false)]
        public string LimitPay { get; set; }

        /// <summary>trade_type=JSAPI时（即公众号支付），此参数必传，此参数为微信用户在商户对应appid下的唯一标识
        /// </summary>
        [WxPayDataElement("openid", false)]
        public string OpenId { get; set; }

    }
}
