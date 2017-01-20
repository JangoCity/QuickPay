namespace QuickPay.Alipay
{
    /// <summary>支付宝支付常量
    /// </summary>
    public class AlipayConsts
    {
        /// <summary>编码方式
        /// </summary>
        public class Charset
        {
            public const string Utf8 = "utf-8";
            public const string Gbk = "gbk";
            public const string Gb2312 = "gb2312";
        }

        /// <summary>签名类型
        /// </summary>
        public class SignType
        {
            public const string Rsa2 = "RSA2";
            public const string Rsa = "RSA";
            public const string Des = "DES";
            public const string Md5 = "MD5";
        }

        /// <summary>Http请求方法
        /// </summary>
        public class HttpMethod
        {
            public const string Get = "GET";
            public const string Post = "POST";
        }

        /// <summary>和支付宝签约的产品Code
        /// </summary>
        public class ProductCode
        {
            /// <summary>App支付
            /// </summary>
            public const string QuickMsecurityPay = "QUICK_MSECURITY_PAY";
        }

        /// <summary>商品类型,0为虚拟,1为实物,虚拟商品不支持花呗
        /// </summary>
        public class GoodsType
        {
            /// <summary>虚拟
            /// </summary>
            public const string Virtual = "0";

            /// <summary>实物
            /// </summary>
            public const string Material = "1";
        }
    }
}
