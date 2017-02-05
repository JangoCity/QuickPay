using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickPay.WxPay;
using QuickPay.WxPay.Request;
using QuickPay.WxPay.Response;
using QuickPay.WxPay.Util;

namespace QuickPayConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var request = new AppUnifiedOrderCallRequest("12345", "1234567890", "20122455");
            //var func = WxPayReflectUtil.GetWxPayDataFunc<AppUnifiedOrderCallRequest>();
            //var r = func(request);
            //Console.WriteLine(r.GetValue("prepayid"));
            var wxPayData=new WxPayData();
            wxPayData.SetValue("return_code","SUCCESS");
            wxPayData.SetValue("result_msg", "OK");
            wxPayData.SetValue("appid","111");
            var func = WxPayReflectUtil.GetWxPayResponse<QueryOrderResponse>();

            var r = func(wxPayData);
            Console.WriteLine(r.AppId);
            Console.ReadKey();
        }
    }
}
