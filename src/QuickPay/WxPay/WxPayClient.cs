using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            request.AppId = _config.AppId;
            request.MchId = _config.MchId;
            request.SignType = _config.SignType;
        }

    }
}
