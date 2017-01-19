using Newtonsoft.Json;

namespace QuickPay.WxPay.Response
{
    /// <summary>获取AccessToken返回
    /// </summary>
    public class GetAccessTokenResponse : WxPayResponse
    {
        /// <summary>网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>用户刷新access_token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>	只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段
        /// </summary>
        [JsonProperty("unionid")]
        public string Unionid { get; set; }
    }
}
