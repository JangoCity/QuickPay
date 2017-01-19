namespace QuickPay.WxPay.Response
{
    /// <summary>基础响应
    /// </summary>
    public abstract class BaseResponse : WxPayResponse
    {
        /// <summary>是否返回成功
        /// </summary>
        public virtual bool ReturnSuccess
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ReturnCode))
                {
                    return ReturnCode == WxPayConsts.ReturnCode.Success;
                }
                return false;
            }
        }

        /// <summary>业务是否执行成功
        /// </summary>
        public virtual bool ResultSuccess
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ResultCode))
                {
                    return ResultCode == WxPayConsts.ResultCode.Success;
                }
                return false;
            }
        }



        /// <summary>返回状态码,SUCCESS/FAIL
        /// </summary>
        [WxPayDataElement("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>返回信息
        /// </summary>
        [WxPayDataElement("return_msg")]
        public string ReturnMsg { get; set; }

        /// <summary>业务结果,SUCCESS/FAIL
        /// </summary>
        [WxPayDataElement("result_code")]
        public string ResultCode { get; set; }

        /// <summary>对于业务执行的详细描述,比如,OK
        /// </summary>
        [WxPayDataElement("result_msg")]
        public string ResultMsg { get; set; }

        /// <summary>错误代码
        /// </summary>
        [WxPayDataElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>	结果信息描述
        /// </summary>
        [WxPayDataElement("err_code_des")]
        public string ErrCodeDes { get; set; }
    }
}
