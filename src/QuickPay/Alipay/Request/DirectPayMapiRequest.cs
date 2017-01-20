using QuickPay.Alipay.Response;

namespace QuickPay.Alipay.Request
{
    /// <summary>create_direct_pay_by_user,即时到账交易接口
    /// </summary>
    public class DirectPayMapiRequest : MapiRequest<DirectPayMapiResponse>
    {
        public override string Service { get; } = AlipayConsts.Service.DirectPay;

        /********************必须参数*****************/

        /// <summary>支付宝合作商户网站唯一订单号。
        /// </summary>
        [AlipayDataElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>商品的标题/交易标题/订单标题/订单关键字等。该参数最长为128个汉字。
        /// </summary>
        [AlipayDataElement("subject")]
        public string Subject { get; set; }

        /// <summary>支付类型,只支持取值为1（商品购买）。
        /// </summary>
        [AlipayDataElement("payment_type")]
        public string PaymentType { get; set; } = "1";

        /// <summary>交易金额,该笔订单的资金总额，单位为RMB-Yuan。取值范围为[0.01，100000000.00]，精确到小数点后两位。
        /// </summary>
        [AlipayDataElement("total_fee")]
        public decimal TotalFee { get; set; }

        /// <summary>卖家支付宝用户号,以2088开头的纯16位数字,当签约账号就是收款账号时，请务必使用参数seller_id，即seller_id的值与partner的值相同。三个参数的优先级别是：seller_id>seller_account_name>seller_email。
        /// </summary>
        [AlipayDataElement("seller_id")]
        public string SellerId { get; set; }

        /// <summary>服务器异步通知页面路径,支付宝服务器主动通知商户网站里指定的页面http路径。
        /// </summary>
        [AlipayDataElement("notify_url")]
        public string NotifyUrl { get; set; }

        public override void SetNecessary(AlipayConfig config)
        {
            base.SetNecessary(config);
            SellerId = config.SellerId;
            SellerEmail = config.SellerAccountName;
            SellerAccountName = config.SellerAccountName;
        }

        /*******************非必须参数******************/

        /// <summary>支付宝处理完请求后，当前页面自动跳转到商户网站里指定页面的http路径。
        /// </summary>
        [AlipayDataElement("return_url", false)]
        public string ReturnUrl { get; set; }

        /// <summary>卖家支付宝登录账号，格式一般是邮箱或手机号
        /// </summary>
        [AlipayDataElement("seller_email",false)]
        public string SellerEmail { get; set; }

        /// <summary>卖家支付宝账号别名,
        /// </summary>
        [AlipayDataElement("seller_account_name",false)]
        public string SellerAccountName { get; set; }

        /// <summary>商品单价,单位为：RMB Yuan。取值范围为[0.01，100000000.00]，精确到小数点后两位。此参数为单价 规则：price、quantity能代替total_fee。即存在total_fee，就不能存在price和quantity；存在price、quantity，就不能存在total_fee。
        /// </summary>
        [AlipayDataElement("price",false)]
        public decimal Price { get; set; }

        /// <summary>购买数量,price、quantity能代替total_fee。即存在total_fee，就不能存在price和quantity；存在price、quantity，就不能存在total_fee。
        /// </summary>
        [AlipayDataElement("quantity",false)]
        public int Quantity { get; set; }

        /// <summary>对一笔交易的具体描述信息。如果是多种商品，请将商品描述字符串累加传给body。
        /// </summary>
        [AlipayDataElement("body",false)]
        public string Body { get; set; }

        /// <summary>收银台页面上，商品展示的超链接。
        /// </summary>
        [AlipayDataElement("show_url",false)]
        public string ShowUrl { get; set; }
        /// <summary>默认支付方式,取值范围：creditPay（信用支付）directPay（余额支付）如果不设置，默认识别为余额支付。
        /// </summary>
        [AlipayDataElement("paymethod",false)]
        public string Paymethod { get; set; }
    }
}
