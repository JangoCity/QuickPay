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

        /// <summary>支付宝新版本接口名称
        /// </summary>
        public class AlipayMethod
        {
            /// <summary>App支付
            /// </summary>
            public const string AppPay = "alipay.trade.app.pay";

            /// <summary>统一收单线下交易查询
            /// </summary>
            public const string TradeQuery = "alipay.trade.query";

            /// <summary>统一收单交易关闭接口
            /// </summary>
            public const string TradeClose = "alipay.trade.close";

            /// <summary>统一收单交易退款接口
            /// </summary>
            public const string TradeRefund = "alipay.trade.refund";

            /// <summary>统一收单交易退款查询
            /// </summary>
            public const string TradeRefundQuery = "alipay.trade.fastpay.refund.query";

            /// <summary>查询对账单下载地址
            /// </summary>
            public const string BillDownloadUrlQuery = "alipay.data.dataservice.bill.downloadurl.query";

        }

        /// <summary>账单类型
        /// </summary>
        public class BillType
        {
            /// <summary>trade指商户基于支付宝交易收单的业务账单
            /// </summary>
            public const string Trade = "trade";

            /// <summary>signcustomer是指基于商户支付宝余额收入及支出等资金变动的帐务账单
            /// </summary>
            public const string Signcustomer = "signcustomer";
        }

        /// <summary>旧版支付宝接口名称
        /// </summary>
        public class Service
        {
            /// <summary>即时到账交易接口
            /// </summary>
            public const string DirectPay = "create_direct_pay_by_user";

            /// <summary>即时到账有密退款接口
            /// </summary>
            public const string RefundFastpay = "refund_fastpay_by_platform_pwd";

            /// <summary>批量付款到支付宝账户有密接口
            /// </summary>
            public const string BatchTrans = "batch_trans_notify";
        }

        public class DefaultPaymethod
        {
            /// <summary>信用卡支付
            /// </summary>
            public const string CreditPay = "creditPay";

            /// <summary>余额支付
            /// </summary>
            public const string DirectPay = "directPay";

            /// <summary>银行支付
            /// </summary>
            public const string BankPay = "bankPay";

            /// <summary>
            /// </summary>
            public const string Cartoon = "cartoon";

            /// <summary>现金
            /// </summary>
            public const string Cash = "cash";
        }
    }
}

