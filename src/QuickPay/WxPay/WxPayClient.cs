using System.Threading.Tasks;
using QuickPay.WxPay.Extensions;
using QuickPay.WxPay.Request;
using QuickPay.WxPay.Response;

namespace QuickPay.WxPay
{
    public class WxPayClient : IWxPayClient
    {
        private readonly WxPayConfig _config;

        #region ctor
        public WxPayClient(WxPayConfig config)
        {
            _config = config;
        }
        #endregion

        public async Task<T> ExecuteAsync<T>(IWxPayRequest<T> request) where T : WxPayResponse
        {
            SetNecessary(request);
            return await Task.FromResult(default(T));
        }

        /// <summary>设置必要的参数
        /// </summary>
        private void SetNecessary<T>(IWxPayRequest<T> request) where T : WxPayResponse
        {
            request.SetNecessary(_config);
        }



        /// <summary>获取Code的url
        /// </summary>
        public async Task<GetCodeResponse> GetCodeUrl(GetCodeRequest request)
        {
            //设置必须参数
            request.SetNecessary(_config);
            var data = request.ToWxPayData();
            var url = $"{request.Url}?{data.ToUrl()}";
            return await Task.FromResult(new GetCodeResponse(url));
        }

        /// <summary>根据Code获取AccessToken
        /// </summary>
        public async Task<GetAccessTokenResponse> GetAccessTokenFromCode(GetAccessTokenRequest request)
        {
            //设置必须参数
            request.SetNecessary(_config);
            //构造获取openid及access_token的url
            var data = request.ToWxPayData();
            var url = $"{request.Url}?{data.ToUrl()}{WxPayConsts.WechatRedirect}";

            //var result = await HttpService.Get(url);
            //var resultDict = JsonSerializer.Deserialize<Dictionary<string, object>>(result);
            //object o;
            //resultDict.TryGetValue("openid", out o);
            //if (o == null)
            //{
            //    throw new WxPayException($"未返回有效的openid");
            //}
            //return o.ToString();
            return await Task.FromResult(new GetAccessTokenResponse());
        }
    }
}
