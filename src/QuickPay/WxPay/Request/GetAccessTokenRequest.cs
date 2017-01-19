using QuickPay.WxPay.Response;

namespace QuickPay.WxPay.Request
{
    /// <summary>根据Code获取AccessToken
    /// </summary>
    public class GetAccessTokenRequest : IWxPayRequest<GetAccessTokenResponse>
    {
        public string Url { get; } = "https://api.weixin.qq.com/sns/oauth2/access_token";

        /// <summary>公众号的唯一标识
        /// </summary>
        [WxPayDataElement("appid")]
        public string AppId { get; set; }

        /// <summary>公众号的appsecret
        /// </summary>
        [WxPayDataElement("secret")]
        public string AppSecret { get; set; }

        /// <summary>填写为authorization_code
        /// </summary>
        [WxPayDataElement("grant_type")]
        public string GrantType { get; set; } = "authorization_code";

        /// <summary>前一步返回的Code
        /// </summary>
        [WxPayDataElement("code")]
        public string Code { get; set; }


        public GetAccessTokenRequest()
        {

        }

        public GetAccessTokenRequest(string code)
        {
            Code = code;
        }

        /// <summary>设置必须的参数
        /// </summary>
        public void SetNecessary(WxPayConfig config)
        {
            AppId = config.AppId;
            AppSecret = config.Appsecret;
        }
    }
}
