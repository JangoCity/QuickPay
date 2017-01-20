using System;

namespace QuickPay.Alipay
{
    public class AlipayException : Exception
    {
        public AlipayException(string msg) : base(msg)
        {

        }
    }
}
