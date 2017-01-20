namespace QuickPay.Alipay.Request.BizContents
{
    /// <summary>alipay.data.dataservice.bill.downloadurl.query (查询对账单下载地址)
    /// </summary>
    public class BillDownloadUrlQueryBizContent : BizContent
    {
        /// <summary>账单类型，商户通过接口或商户经开放平台授权后其所属服务商通过接口可以获取以下账单类型：trade、signcustomer；trade指商户基于支付宝交易收单的业务账单；signcustomer是指基于商户支付宝余额收入及支出等资金变动的帐务账单；
        /// </summary>
        [AlipayDataElement("bill_type")]
        public string BillType { get; set; }

        /// <summary>账单时间：日账单格式为yyyy-MM-dd，月账单格式为yyyy-MM。
        /// </summary>
        [AlipayDataElement("bill_date")]
        public string BillDate { get; set; }

        public BillDownloadUrlQueryBizContent()
        {
            
        }

        public BillDownloadUrlQueryBizContent(string billType, string billDate)
        {
            BillType = billType;
            BillDate = billDate;
        }
    }
}
