using System.Threading.Tasks;

namespace QuickPay.WxPay
{
    public interface IWxPayClient
    {
        Task<T> ExecuteAsync<T>(IWxPayRequest<T> request) where T : WxPayResponse;
    }
}
