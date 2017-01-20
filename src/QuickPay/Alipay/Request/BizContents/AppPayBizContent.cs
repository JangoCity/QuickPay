 // ReSharper disable once CheckNamespace
namespace QuickPay.Alipay.Request
{
    /// <summary>支付宝App支付业务参数
    /// </summary>
    public class AppPayBizContent : BizContent
    {
        /****************必须参数***************/

        /// <summary>商品的标题/交易标题/订单标题/订单关键字等
        /// </summary>
        [AlipayDataElement("subject")]
        public string Subject { get; set; }

        /// <summary>商户网站唯一订单号
        /// </summary>
        [AlipayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]
        /// </summary>
        [AlipayDataElement("total_amount")]
        public string TotalAmount { get; set; }

        /// <summary>销售产品码，商家和支付宝签约的产品码，为固定值QUICK_MSECURITY_PAY
        /// </summary>
        [AlipayDataElement("product_code")]
        public string ProductCode { get; set; } = AlipayConsts.ProductCode.QuickMsecurityPay;

        public AppPayBizContent()
        {
            
        }

        public AppPayBizContent(string subject, string outTradeNo, string totalAmount)
        {
            Subject = subject;
            OutTradeNo = outTradeNo;
            TotalAmount = totalAmount;
        }

        /*******************非必须参数******************/

        /// <summary>对一笔交易的具体描述信息。如果是多种商品，请将商品描述字符串累加传给body
        /// </summary>
        [AlipayDataElement("body", false)]
        public string Body { get; set; }

        /// <summary>该笔订单允许的最晚付款时间，逾期将关闭交易。取值范围：1m～15d。m-分钟，h-小时，d-天，1c-当天（1c-当天的情况下，无论交易何时创建，都在0点关闭）。 该参数数值不接受小数点， 如 1.5h，可转换为 90m。
        /// </summary>
        [AlipayDataElement("timeout_express", false)]
        public string TimeoutExpress { get; set; }

        /// <summary>收款支付宝用户ID。 如果该值为空，则默认为商户签约账号对应的支付宝用户ID
        /// </summary>
        [AlipayDataElement("seller_id", false)]
        public string SellerId { get; set; }

        /// <summary>商品主类型：0—虚拟类商品，1—实物类商品 注：虚拟类商品不支持使用花呗渠道
        /// </summary>
        [AlipayDataElement("goods_type", false)]
        public string GoodsType { get; set; }

        /// <summary>公用回传参数，如果请求时传递了该参数，则返回给商户时会回传该参数。支付宝会在异步通知时将该参数原样返回。本参数必须进行UrlEncode之后才可以发送给支付宝
        /// </summary>
        [AlipayDataElement("passback_params", false)]
        public string PassbackParams { get; set; }

        /// <summary>优惠参数注：仅与支付宝协商后可用
        /// </summary>
        [AlipayDataElement("promo_params", false)]
        public string PromoParams { get; set; }

        /// <summary>业务扩展参数
        /// </summary>
        [AlipayDataElement("extend_params", false)]
        public string ExtendParams { get; set; }

        /// <summary>可用渠道，用户只能在指定渠道范围内支付 当有多个渠道时用“,”分隔注：与disable_pay_channels互斥
        /// </summary>
        [AlipayDataElement("enable_pay_channels", false)]
        public string EnablePayChannels { get; set; }

        /// <summary>禁用渠道，用户不可用指定渠道支付当有多个渠道时用“,”分隔 注：与enable_pay_channels互斥
        /// </summary>
        [AlipayDataElement("disable_pay_channels", false)]
        public string DisablePayChannels { get; set; }

        /// <summary>商户门店编号
        /// </summary>
        [AlipayDataElement("store_id", false)]
        public string StoreId { get; set; }
    }
}
