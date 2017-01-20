using QuickPay.Alipay.Response;

namespace QuickPay.Alipay.Request
{
    /// <summary>批量付款到支付宝账户有密接口
    /// </summary>
    public class BatchTransMapiRequest : MapiRequest<BatchTransMapiResponse>
    {
        public override string Service { get; } = AlipayConsts.Service.BatchTrans;

        /// <summary>服务器异步通知页面路径,支付宝服务器主动通知商户网站里指定的页面http路径。
        /// </summary>
        [AlipayDataElement("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>付款详细数据,付款的详细数据，最多支持1000笔。
        /// 格式为：流水号1^收款方账号1^收款账号姓名1^付款金额1^备注说明1|流水号2^收款方账号2^收款账号姓名2^付款金额2^备注说明2。
        /// 每条记录以“|”间隔。流水号不能超过64字节，收款方账号小于100字节，备注不能超过200字节。当付款方为企业账户，且转账金额达到（大于等于）50000元，备注不能为空。
        /// </summary>
        [AlipayDataElement("detail_data")]
        public string DetailData { get; set; }

        /// <summary>批量付款批次号,11～32位的数字或字母或数字与字母的组合，且区分大小写。
        /// 注意：批量付款批次号用作业务幂等性控制的依据，一旦提交受理，请勿直接更改批次号再次上传。
        /// </summary>
        [AlipayDataElement("batch_no")]
        public string BatchNo { get; set; }
        /// <summary>批量付款笔数（最少1笔，最多1000笔）。
        /// </summary>
        [AlipayDataElement("batch_num")]
        public string BatchNum { get; set; }

        /// <summary>付款总金额,格式：10.01，精确到分
        /// </summary>
        [AlipayDataElement("batch_fee")]
        public string BatchFee { get; set; }
        /// <summary>支付时间（必须为当前日期）。格式：YYYYMMDD。
        /// </summary>
        [AlipayDataElement("pay_date")]
        public string PayDate { get; set; }

        public BatchTransMapiRequest()
        {

        }

        /// <summary>批量付款到支付宝账户有密接口
        /// </summary>
        /// <param name="batchNo">批量付款批次号</param>
        /// <param name="batchNum">付款总笔数</param>
        /// <param name="batchFee">付款总金额</param>
        /// <param name="detailData">付款详细数据</param>
        /// <param name="payData">支付日期</param>
        /// <param name="notifyUrl">服务器异步通知地址</param>
        public BatchTransMapiRequest(string batchNo, string batchNum, string batchFee, string detailData, string payData,
            string notifyUrl)
        {
            BatchNo = batchNo;
            BatchNum = batchNum;
            BatchFee = batchFee;
            DetailData = detailData;
            PayDate = payData;
            NotifyUrl = notifyUrl;
        }


        /// <summary>批量付款到支付宝账户有密接口
        /// </summary>
        /// <param name="batchNo">批量付款批次号</param>
        /// <param name="batchNum">付款总笔数</param>
        /// <param name="batchFee">付款总金额</param>
        /// <param name="detailData">付款详细数据</param>
        /// <param name="payData">支付日期</param>
        /// <param name="notifyUrl">服务器异步通知地址</param>
        /// <param name="extendParam">业务扩展参数</param>
        public BatchTransMapiRequest(string batchNo, string batchNum, string batchFee, string detailData, string payData,
            string notifyUrl, string extendParam) : this(batchNo, batchNum, batchFee, detailData, payData, notifyUrl)
        {
            ExtendParam = extendParam;
        }

        /********************Config中获得******************/

        /// <summary>付款账号名,付款方的支付宝账户名
        /// </summary>
        [AlipayDataElement("account_name")]
        public string AccountName { get; set; }

        /// <summary>付款账号,付款方的支付宝账号，支持邮箱和手机号2种格式
        /// </summary>
        [AlipayDataElement("email")]
        public string Email { get; set; }

        /******************非必须******************/
        /// <summary>付款账号别名,同email参数，可以使用该参数名代替email输入参数；优先级大于email。
        /// </summary>
        [AlipayDataElement("buyer_account_name",false)]
        public string BuyerAccountName { get; set; }

        /// <summary>业务扩展参数
        /// </summary>
        [AlipayDataElement("extend_param",false)]
        public string ExtendParam { get; set; }

        public override void SetNecessary(AlipayConfig config)
        {
            base.SetNecessary(config);
            AccountName = config.SellerEmail;
            Email = config.SellerEmail;
            BuyerAccountName = config.SellerAccountName;
        }
    }
}
