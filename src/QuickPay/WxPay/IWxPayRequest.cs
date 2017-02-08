namespace QuickPay.WxPay
{

    public interface IWxPay
    {

    }
    public interface IWxPayRequest<T> : IWxPay where T : WxPayResponse
    {
        /// <summary>当前Request请求的Url地址
        /// </summary>
        string Url { get; }
        /// <summary>设置来自WxPayConfig的必须参数
        /// </summary>
        void SetNecessary(WxPayConfig config);
    }
}
