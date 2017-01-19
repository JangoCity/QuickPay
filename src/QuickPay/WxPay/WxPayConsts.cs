namespace QuickPay.WxPay
{
    public class WxPayConsts
    {
        /// <summary>微信支付常量
        /// </summary>
        public const string DefaultConfig = "Default";
        /// <summary>签名
        /// </summary>
        public const string Sign = "Sign";
        /// <summary>
        /// </summary>
        public const string WechatRedirect = "#wechat_redirect";
        public class Scope
        {
            public const string Base = "snsapi_base";
            public const string UserInfo = "snsapi_userinfo";
        }

        public class TradeType
        {
            /// <summary>公众号支付
            /// </summary>
            public const string JsApi = "JSAPI";

            /// <summary>Native
            /// </summary>
            public const string Native = "NATIVE";

            /// <summary>App支付
            /// </summary>
            public const string App = "APP";
        }

        public class SignType
        {
            public const string Md5 = "MD5";
        }


    }
}
