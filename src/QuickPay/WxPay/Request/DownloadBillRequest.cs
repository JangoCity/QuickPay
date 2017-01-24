using QuickPay.WxPay.Response;

namespace QuickPay.WxPay.Request
{
    /// <summary>下载账单请求
    /// </summary>
    public class DownloadBillRequest : TradeRequest<DownloadBillResponse>
    {
        public override string Url { get; } = "https://api.mch.weixin.qq.com/pay/downloadbill";

        /// <summary>对账单日期,下载对账单的日期，格式：20140603
        /// </summary>
        [WxPayDataElement("bill_date")]
        public string BillDate { get; set; }

        /// <summary>账单类型,ALL，返回当日所有订单信息，默认值SUCCESS，返回当日成功支付的订单REFUND，返回当日退款订单
        /// </summary>
        [WxPayDataElement("bill_type")]
        public string BillType { get; set; }

        public DownloadBillRequest()
        {
            
        }

        public DownloadBillRequest(string billDate, string billType)
        {
            BillDate = billDate;
            BillType = billType;
        }

        /********************非必须参数*****************/

        /// <summary>压缩账单,非必传参数，固定值：GZIP，返回格式为.gzip的压缩包账单。不传则默认为数据流形式。
        /// </summary>
        [WxPayDataElement("tar_type", false)]
        public string TarType { get; set; }

        [WxPayDataElement("device_info", false)]
        public string DeviceInfo { get; set; }
    }
}
