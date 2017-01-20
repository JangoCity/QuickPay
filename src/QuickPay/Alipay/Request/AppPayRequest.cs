using QuickPay.Alipay.Response;

namespace QuickPay.Alipay.Request
{
    /// <summary>App支付下单
    /// </summary>
    public class AppPayRequest:BaseRequest<AppPayResponse>
    {
        public AppPayRequest()
        {
            
        }

        public AppPayRequest(string notifyUrl, AppPayBizContent bizContent)
        {
            NotifyUrl = notifyUrl;
            BizContent = bizContent;
        }
    }
}
