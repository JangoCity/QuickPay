using System.Threading.Tasks;
using QuickPay.Common;
using QuickPay.WxPay.Extensions;
using QuickPay.WxPay.Request;
using QuickPay.WxPay.Response;
using QuickPay.WxPay.Util;

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

        /// <summary>异步执行请求
        /// </summary>
        public async Task<T> ExecuteAsync<T>(IWxPayRequest<T> request) where T : WxPayResponse
        {
            SetNecessary(request);
            return await Task.FromResult(default(T));
        }

        /// <summary>生成页面执行参数
        /// </summary>
        public async Task<string> PageExecuteAsync<T>(IWxPayRequest<T> request,
            string signField = WxPayConsts.SignField.PaySign)
            where T : WxPayResponse
        {
            //不包含签名,并且不包含null值
            var wxPayData = request.ToWxPayData();
            //签名
            var sign = WxPayUtil.Sign(wxPayData, _config.Key);
            wxPayData.SetValue(signField, sign);
            var json = JsonSerializer.Serialize(wxPayData);
            return await Task.FromResult(json);
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
            var json = await HttpService.Get(url);
            var accessToken = JsonSerializer.Deserialize<GetAccessTokenResponse>(json);
            return await Task.FromResult(accessToken);
        }
    }
}
