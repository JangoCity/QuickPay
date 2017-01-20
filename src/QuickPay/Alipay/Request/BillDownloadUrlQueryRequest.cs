using QuickPay.Alipay.Request.BizContents;
using QuickPay.Alipay.Response;

namespace QuickPay.Alipay.Request
{
    /// <summary>alipay.data.dataservice.bill.downloadurl.query (查询对账单下载地址)
    /// </summary>
    public class BillDownloadUrlQueryRequest : BaseRequest<BillDownloadUrlQueryResponse>
    {
        public override string Method { get; set; } = AlipayConsts.AlipayMethod.BillDownloadUrlQuery;

        /// <summary>token
        /// </summary>
        [AlipayDataElement("app_auth_token", false)]
        public string AppAuthToken { get; set; }

        public BillDownloadUrlQueryRequest()
        {
            
        }

        public BillDownloadUrlQueryRequest(BillDownloadUrlQueryBizContent bizContent)
        {
            BizContent = bizContent;
        }
    }
}
