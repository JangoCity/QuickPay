using QuickPay.Alipay.Response;

namespace QuickPay.Alipay.Request
{
    /// <summary>refund_fastpay_by_platform_pwd,即时到账有密退款接口
    /// </summary>
    public class RefundFastpayMapiRequest:MapiRequest<RefundFastpayMapiResponse>
    {
        public override string Service { get; } = AlipayConsts.Service.RefundFastpay;

        /// <summary>服务器异步通知页面路径,支付宝服务器主动通知商户网站里指定的页面http路径。
        /// </summary>
        [AlipayDataElement("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>卖家用户ID,seller_user_id是以2088开头的纯16位数字,
        /// 登录时,seller_email和seller_user_id两者必填一个。如果两者都填，以seller_user_id为准。
        /// </summary>
        [AlipayDataElement("seller_user_id")]
        public string SellerUserId { get; set; }

        /// <summary>退款请求时间,退款请求的当前时间。格式为：yyyy-MM-dd HH:mm:ss。
        /// </summary>
        [AlipayDataElement("refund_date")]
        public string RefundDate { get; set; }

        /// <summary>退款批次号.每进行一次即时到账批量退款，都需要提供一个批次号.
        /// 通过该批次号可以查询这一批次的退款交易记录，对于每一个合作伙伴，传递的每一个批次号都必须保证唯一性。
        /// 格式为：退款日期（8位）+流水号（3～24位）。
        /// 不可重复，且退款日期必须是当天日期。流水号可以接受数字或英文字符，建议使用数字，但不可接受“000”。
        /// </summary>
        [AlipayDataElement("batch_no")]
        public string BatchNo { get; set; }

        /// <summary>总笔数
        /// 即参数detail_data的值中，“#”字符出现的数量加1，最大支持1000笔（即“#”字符出现的最大数量为999个）。
        /// </summary>
        [AlipayDataElement("batch_num")]
        public string BatchNum { get; set; }

        /// <summary>单笔数据集,退款请求的明细数据。
        /// *******单笔数据集参数说明:
        /// 1.单笔数据集格式为：第一笔交易退款数据集#第二笔交易退款数据集#第三笔交易退款数据集…#第N笔交易退款数据集；
        /// 2.交易退款数据集的格式为：原付款支付宝交易号^退款总金额^退款理由,不支持退分润功能
        /// *******单笔数据集（detail_data）注意事项:
        /// 1.detail_data中的退款笔数总和要等于参数batch_num的值；
        /// 2.“退款理由”长度不能大于256字节，“退款理由”中不能有“^”、“|”、“$”、“#”等影响detail_data格式的特殊字符；
        /// 3.detail_data中退款总金额不能大于交易总金额；
        /// 4.一笔交易可以多次退款，退款次数最多不能超过99次，需要遵守多次退款的总金额不超过该笔交易付款金额的原则。
        /// </summary>
        [AlipayDataElement("detail_data")]
        public string DetailData { get; set; }


        /// <summary>卖家支付宝账号,seller_email是支付宝登录账号，格式一般是邮箱或手机号
        /// </summary>
        [AlipayDataElement("seller_email",false)]
        public string SellerEmail { get; set; }

        public RefundFastpayMapiRequest()
        {
            
        }

        /// <summary>即时到账有密退款接口
        /// </summary>
        /// <param name="refundDate">退款时间</param>
        /// <param name="batchNo">退款批次号,格式为：退款日期（8位）+流水号（3～24位）</param>
        /// <param name="batchNum">总笔数,#”字符出现的数量加1，最大支持1000笔（即“#”字符出现的最大数量为999个）</param>
        /// <param name="detailData">单笔数据集,格式如:2014040311001004370000361525^5.00^协商退款</param>
        public RefundFastpayMapiRequest(string refundDate, string batchNo, string batchNum, string detailData)
        {
            RefundDate = refundDate;
            BatchNo = batchNo;
            BatchNum = batchNum;
            DetailData = detailData;
        }

        public override void SetNecessary(AlipayConfig config)
        {
            base.SetNecessary(config);
            SellerUserId = config.SellerId;
            SellerEmail = config.SellerEmail;
        }
    }
}
