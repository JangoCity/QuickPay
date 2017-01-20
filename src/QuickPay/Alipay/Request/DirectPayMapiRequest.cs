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

        public DirectPayMapiRequest()
        {

        }

        /// <summary>即时到帐
        /// </summary>
        /// <param name="outTradeNo">商户网站唯一订单号</param>
        /// <param name="subject">商品名称</param>
        /// <param name="totalFee">交易金额</param>
        /// <param name="notifyUrl">服务器异步通知页面路径</param>
        /// <param name="returnUrl">页面跳转同步通知页面路径</param>
        public DirectPayMapiRequest(string outTradeNo, string subject, decimal totalFee, string notifyUrl,
            string returnUrl)
        {
            OutTradeNo = outTradeNo;
            Subject = subject;
            TotalFee = totalFee;
            NotifyUrl = notifyUrl;
            ReturnUrl = returnUrl;
        }

        /// <summary>即时到帐
        /// </summary>
        /// <param name="outTradeNo">商户网站唯一订单号</param>
        /// <param name="subject">商品名称</param>
        /// <param name="totalFee">交易金额</param>
        /// <param name="notifyUrl">服务器异步通知页面路径</param>
        /// <param name="returnUrl">页面跳转同步通知页面路径</param>
        /// <param name="antiPhishingKey">防钓鱼时间戳</param>
        /// <param name="exterInvokeIp">客户端IP,用户在创建交易时，该用户当前所使用机器的IP。</param>
        /// <param name="extraCommonParam">公用回传参数</param>
        public DirectPayMapiRequest(string outTradeNo, string subject, decimal totalFee, string notifyUrl,
            string returnUrl, string antiPhishingKey, string exterInvokeIp, string extraCommonParam)
            : this(outTradeNo, subject, totalFee, notifyUrl, returnUrl)
        {
            AntiPhishingKey = antiPhishingKey;
            ExterInvokeIp = exterInvokeIp;
            ExtraCommonParam = extraCommonParam;
        }

        /*******************非必须参数******************/

        /// <summary>支付宝处理完请求后，当前页面自动跳转到商户网站里指定页面的http路径。
        /// </summary>
        [AlipayDataElement("return_url", false)]
        public string ReturnUrl { get; set; }

        /// <summary>卖家支付宝登录账号，格式一般是邮箱或手机号
        /// </summary>
        [AlipayDataElement("seller_email", false)]
        public string SellerEmail { get; set; }

        /// <summary>卖家支付宝账号别名,
        /// </summary>
        [AlipayDataElement("seller_account_name", false)]
        public string SellerAccountName { get; set; }

        /// <summary>商品单价,单位为：RMB Yuan。取值范围为[0.01，100000000.00]，精确到小数点后两位。此参数为单价 规则：price、quantity能代替total_fee。即存在total_fee，就不能存在price和quantity；存在price、quantity，就不能存在total_fee。
        /// </summary>
        [AlipayDataElement("price", false)]
        public decimal Price { get; set; }

        /// <summary>购买数量,price、quantity能代替total_fee。即存在total_fee，就不能存在price和quantity；存在price、quantity，就不能存在total_fee。
        /// </summary>
        [AlipayDataElement("quantity", false)]
        public int Quantity { get; set; }

        /// <summary>对一笔交易的具体描述信息。如果是多种商品，请将商品描述字符串累加传给body。
        /// </summary>
        [AlipayDataElement("body", false)]
        public string Body { get; set; }

        /// <summary>收银台页面上，商品展示的超链接。
        /// </summary>
        [AlipayDataElement("show_url", false)]
        public string ShowUrl { get; set; }

        /// <summary>默认支付方式,取值范围：creditPay（信用支付）directPay（余额支付）如果不设置，默认识别为余额支付。
        /// </summary>
        [AlipayDataElement("paymethod", false)]
        public string Paymethod { get; set; }

        /// <summary>可用渠道,可用的支付渠道，用户只能在指定渠道范围内支付。当有多个渠道时，以“^”分隔。与disable_paymethod互斥。
        /// </summary>
        [AlipayDataElement("enable_paymethod", false)]
        public string EnablePaymethod { get; set; }

        /// <summary>被禁用的支付渠道，用户不可用指定渠道支付。当有多个渠道时，以“^”分隔,与nable_paymethod互斥。
        /// </summary>
        [AlipayDataElement("disable_paymethod", false)]
        public string DisablePaymethod { get; set; }

        /// <summary>防钓鱼时间戳,通过时间戳查询接口获取的加密支付宝系统时间戳,如果已申请开通防钓鱼时间戳验证，则此字段必填。
        /// </summary>
        [AlipayDataElement("anti_phishing_key", false)]
        public string AntiPhishingKey { get; set; }

        /// <summary>用户在创建交易时，该用户当前所使用机器的IP。如果商户申请后台开通防钓鱼IP地址检查选项，此字段必填，校验用。
        /// </summary>
        [AlipayDataElement("exter_invoke_ip", false)]
        public string ExterInvokeIp { get; set; }

        /// <summary>公用回传参数,如果用户请求时传递了该参数，则返回给商户时会回传该参数。
        /// </summary>
        [AlipayDataElement("extra_common_param", false)]
        public string ExtraCommonParam { get; set; }

        /// <summary>超时时间,设置未付款交易的超时时间，一旦超时，该笔交易就会自动被关闭。
        /// 取值范围：1m～15d。m-分钟，h-小时，d-天，1c-当天（1c-当天的情况下，无论交易何时创建，都在0点关闭）。
        /// 该参数数值不接受小数点，如1.5h，可转换为90m。
        /// </summary>
        [AlipayDataElement("it_b_pay", false)]
        public string Itbpay { get; set; }

        /// <summary>快捷登录授权令牌,如果开通了快捷登录产品，则需要填写；如果没有开通，则为空。
        /// </summary>
        [AlipayDataElement("token", false)]
        public string Token { get; set; }

        /// <summary>扫码支付方式,扫码支付的方式，支持前置模式和跳转模式。
        /// 前置模式是将二维码前置到商户的订单确认页的模式。需要商户在自己的页面中以iframe方式请求支付宝页面。具体分为以下4种：
        /// 0：订单码-简约前置模式，对应iframe宽度不能小于600px，高度不能小于300px；
        /// 1：订单码-前置模式，对应iframe宽度不能小于300px，高度不能小于600px；
        /// 3：订单码-迷你前置模式，对应iframe宽度不能小于75px，高度不能小于75px。
        /// 4：订单码-可定义宽度的嵌入式二维码，商户可根据需要设定二维码的大小。
        /// 跳转模式下，用户的扫码界面是由支付宝生成的，不在商户的域名下。2：订单码-跳转模式
        /// </summary>
        [AlipayDataElement("qr_pay_mode", false)]
        public string QrPaymode { get; set; }

        /// <summary>商户自定二维码宽度,商户自定义的二维码宽度。当qr_pay_mode=4时，该参数生效
        /// </summary>
        [AlipayDataElement("qrcode_width", false)]
        public string QrWidth { get; set; }

        /// <summary>是否需要买家实名认证,T表示需要买家实名认证；不传或者传其它值表示不需要买家实名认证。
        /// </summary>
        [AlipayDataElement("need_buyer_realnamed", false)]
        public string NeedBuyerRealnamed { get; set; }

        /// <summary>花呗分期参数,参数格式：hb_fq_seller_percent ^卖家承担付费比例|hb_fq_num ^期数。
        /// hb_fq_num：花呗分期数，比如分3期支付;hb_fq_seller_percent：卖家承担收费比例，比如100代表卖家承担100%。
        /// 两个参数必须一起传入。两个参数用“|”间隔。Key和value之间用“^”间隔。
        /// 具体花呗分期期数和卖家承担收费比例可传入的数值请咨询支付宝。
        /// </summary>
        [AlipayDataElement("hb_fq_param", false)]
        public string HbfqParam { get; set; }

        /// <summary>商品类型,1表示实物类商品0表示虚拟类商品
        /// </summary>
        [AlipayDataElement("goods_type", false)]
        public string GoodsType { get; set; } = AlipayConsts.GoodsType.Material;
    }
}

