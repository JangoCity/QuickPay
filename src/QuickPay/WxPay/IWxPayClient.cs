using System.Threading.Tasks;
using QuickPay.WxPay.Request;
using QuickPay.WxPay.Response;

namespace QuickPay.WxPay
{
    public interface IWxPayClient
    {
        Task<T> ExecuteAsync<T>(IWxPayRequest<T> request) where T : WxPayResponse;


        /// <summary>获取Code的url
        /// </summary>
        Task<GetCodeResponse> GetCodeUrl(GetCodeRequest request);

        /// <summary>根据Code获取OpenId
        /// </summary>
        Task<GetAccessTokenResponse> GetAccessTokenFromCode(GetAccessTokenRequest request);
    }
}
