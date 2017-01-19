using System;
using QuickPay.WxPay.Response;

namespace QuickPay.WxPay.Request
{
    public class GetCodeRequest : IWxPayRequest<GetCodeResponse>
    {
        public string Url { get; } = "https://open.weixin.qq.com/connect/oauth2/authorize";

        /// <summary>公众号的唯一标识
        /// </summary>
        [WxPayDataElement("appid")]
        public string AppId { get; set; }

        /// <summary>授权后重定向的回调链接地址，请使用urlencode对链接进行处理
        /// </summary>
        [WxPayDataElement("redirect_uri")]
        public string RedirectUri { get; set; }

        /// <summary>返回类型，请填写code
        /// </summary>
        [WxPayDataElement("response_type")]
        public string ResponseType { get; set; } = "code";

        /// <summary>应用授权作用域，snsapi_base （不弹出授权页面，直接跳转，只能获取用户openid），snsapi_userinfo （弹出授权页面，可通过openid拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息）
        /// </summary>
        [WxPayDataElement("scope")]
        public string Scope { get; set; }

        /// <summary>重定向后会带上state参数，开发者可以填写a-zA-Z0-9的参数值，最多128字节
        /// </summary>
        [WxPayDataElement("state")]
        public string State { get; set; }

        public string WechatRedirect { get; set; }

        public GetCodeRequest(string redirectUri, string scope)
        {
            RedirectUri = redirectUri;
            Scope = scope;
        }

        public GetCodeRequest()
        {
            
        }
        public void SetNecessary(WxPayConfig config)
        {
            AppId = config.AppId;
        }
    }
}
