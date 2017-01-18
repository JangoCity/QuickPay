using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickPay.Common;
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

        public async Task<T> ExecuteAsync<T>(IWxPayRequest<T> request) where T : WxPayResponse
        {
            SetNecessary(request);
            return await Task.FromResult(default(T));
        }

        /// <summary>设置必要的参数
        /// </summary>
        private void SetNecessary<T>(IWxPayRequest<T> request) where T : WxPayResponse
        {

        }




        /// <summary>根据Code获取OpenId
        /// </summary>
        public async Task<string> GetOpenidFromCode(string code)
        {
            //构造获取openid及access_token的url
            WxPayData data = new WxPayData();
            data.SetValue("appid", _config.AppId);
            data.SetValue("secret", _config.Appsecret);
            data.SetValue("code", code);
            data.SetValue("grant_type", "authorization_code");
            var url = $"{_config.AccessTokenUrl}?{data.ToUrl()}";
            var result = await WxPayHttpService.Get(url);
            var resultDict = JsonSerializer.Deserialize<Dictionary<string, object>>(result);
            object o;
            resultDict.TryGetValue("openid", out o);
            if (o == null)
            {
                throw new WxPayException($"未返回有效的openid");
            }
            return o.ToString();
        }
    }
}
