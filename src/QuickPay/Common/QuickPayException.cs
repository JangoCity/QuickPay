using System;

namespace QuickPay.Common
{
    public class QuickPayException : Exception
    {
        public QuickPayException(string msg) : base(msg)
        {

        }
    }
}
