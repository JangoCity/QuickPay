using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickPay.WxPay.Request;
using QuickPay.WxPay.Util;

namespace QuickPayConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var request = new AppUnifiedOrderCallRequest("12345", "1234567890", "20122455");
            var func = WxPayReflectUtil.GetWxPayDataFunc<AppUnifiedOrderCallRequest>();
            var r = func(request);
            Console.WriteLine(r.GetValue("prepayid"));
            Console.ReadKey();
        }
    }
}
