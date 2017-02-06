namespace QuickPay.Alipay
{
    public interface IAlipay
    {
        
    }

    /// <summary>支付支付请求
    /// </summary>
    public interface IAlipayRequest<T> : IAlipay where T : AlipayResponse
    {
        /// <summary>请求网关
        /// </summary>
        string Gateway { get; }

        /// <summary>设置来自AlipayConfig的必须参数
        /// </summary>
        void SetNecessary(AlipayConfig config);
    }
}
