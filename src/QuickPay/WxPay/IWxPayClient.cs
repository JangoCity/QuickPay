using System.Threading.Tasks;
using QuickPay.WxPay.Request;
using QuickPay.WxPay.Response;

namespace QuickPay.WxPay
{
    public interface IWxPayClient
    {
        /// <summary>异步执行请求
        /// </summary>
        Task<T> ExecuteAsync<T>(IWxPayRequest<T> request)
            where T : WxPayResponse;


        /// <summary>生成页面执行参数
        /// </summary>
        Task<string> ParamExecuteAsync<T>(IWxPayRequest<T> request,
            string signField = WxPayConsts.SignField.PaySign)
            where T : WxPayResponse;
 
        /// <summary>获取Code的url
        /// </summary>
        Task<GetCodeResponse> GetCodeUrl(GetCodeRequest request);

        /// <summary>根据Code获取AccessToken
        /// </summary>
        Task<GetAccessTokenResponse> GetAccessTokenFromCode(GetAccessTokenRequest request);

        /// <summary>根据当前系统时间加随机序列来生成订单号
        /// </summary>
        string GenerateOutTradeNo();

        /// <summary>获取加密的Key
        /// </summary>
        string GetSignKey();
    }
}
