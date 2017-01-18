using System.Threading.Tasks;

namespace QuickPay.WxPay
{
    public interface IWxPayClient
    {
        Task<T> ExecuteAsync<T>(IWxPayRequest<T> request) where T : WxPayResponse;

        /// <summary>根据Code获取OpenId
        /// </summary>
        Task<string> GetOpenidFromCode(string code);


    }
}
