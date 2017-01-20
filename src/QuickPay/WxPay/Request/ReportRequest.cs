using QuickPay.WxPay.Response;

namespace QuickPay.WxPay.Request
{
    /// <summary>交易保障测速上报请求
    /// </summary>
    public class ReportRequest : BaseRequest<ReportResponse>
    {
        public override string Url { get; } = "https://api.mch.weixin.qq.com/payitil/report";

        /// <summary>接口URL,报对应的接口的完整URL，类似： https://api.mch.weixin.qq.com/pay/unifiedorder 对于刷卡支付，为更好的和商户共同分析一次业务行为的整体耗时情况，对于两种接入模式，请都在门店侧对一次刷卡支付进行一次单独的整体上报，上报URL指定为：https://api.mch.weixin.qq.com/pay/micropay/total
        /// </summary>
        [WxPayDataElement("interface_url")]
        public string InterfaceUrl { get; set; }

        /// <summary>接口耗时,接口耗时情况，单位为毫秒
        /// </summary>
        [WxPayDataElement("execute_time_")]
        public int ExecuteTime { get; set; }

        /// <summary>返回状态码,SUCCESS/FAIL此字段是通信标识，非交易标识，交易是否成功需要查看trade_state来判断
        /// </summary>
        [WxPayDataElement("return_code")]
        public string ReturnCode { get; set; }


        /// <summary>业务结果,SUCCESS/FAIL
        /// </summary>
        [WxPayDataElement("result_code")]
        public string ResultCode { get; set; }

        /// <summary>发起接口调用时的机器IP 
        /// </summary>
        [WxPayDataElement("user_ip")]
        public string UserIp { get; set; }

        public ReportRequest()
        {
            
        }

        public ReportRequest(string interfaceUrl, int executeTime, string returnCode, string resultCode, string userIp)
        {
            InterfaceUrl = interfaceUrl;
            ExecuteTime = executeTime;
            ReturnCode = returnCode;
            ResultCode = resultCode;
            UserIp = userIp;
        }

        /******************非必须参数***************/

        /// <summary>返回信息,返回信息，如非空，为错误原因签名失败参数格式校验错误
        /// </summary>
        [WxPayDataElement("return_msg")]
        public string ReturnMsg { get; set; }
        /// <summary>错误代码ORDERNOTEXIST—订单不存在SYSTEMERROR—系统错误
        /// </summary>
        [WxPayDataElement("err_code", false)]
        public string ErrCode { get; set; }

        /// <summary>错误代码描述
        /// </summary>
        [WxPayDataElement("err_code_des", false)]
        public string ErrCodeDes { get; set; }

        /// <summary>商户系统内部的订单号,商户可以在上报时提供相关商户订单号方便微信支付更好的提高服务质量
        /// </summary>
        [WxPayDataElement("out_trade_no", false)]
        public string OutTradeNo { get; set; }

        /// <summary>系统时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010
        /// </summary>
        [WxPayDataElement("time", false)]
        public string Time { get; set; }
    }
}
