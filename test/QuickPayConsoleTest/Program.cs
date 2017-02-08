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
            // var request = new AppUnifiedOrderCallRequest("12345");
            //var func = WxPayReflectUtil.GetDataFunc<AppUnifiedOrderCallRequest>();
            //var r = func(request);
            //Console.WriteLine(r.GetValue("prepayid"));
            //var wxPayData=new WxPayData();
            //wxPayData.SetValue("return_code","SUCCESS");
            //wxPayData.SetValue("result_msg", "OK");
            //wxPayData.SetValue("appid","111");
            //var func = WxPayReflectUtil.GetWxPay<QueryOrderResponse>();

            //var r = func(wxPayData);
            //Console.WriteLine(r.AppId);
            var config = new WxPayConfig()
            {
                AppId = "AppIdxxxxxxxxxxx",
                MchId = "mchuuuuuuuu",
                Appsecret = "12312312312312313",
                Key = "333002112132313",
                LocalAddress = "127.0.0.1",
                WebSite = "http://127.0.0.1",
                NotifyUrl = "12323232",
                SignType = WxPayConsts.SignType.Md5
            };
            IWxPayClient client = new WxPayClient(config);
            // var request = new UnifiedOrderRequest("outTradeNo", 300, "hello", "", WxPayConsts.TradeType.App);
            // var response = client.ExecuteAsync(request);
            //
            //if (response.ReturnSuccess && response.ResultSuccess)
            //{
            //    var callRequest=new AppUnifiedOrderCallRequest(response.PrepayId);
            //    var result = client.ParamExecuteAsync(callRequest);
            //}
            var request2 = new AppUnifiedOrderCallRequest("123333");
            var str = client.ParamExecuteAsync(request2, "").Result;
            Console.WriteLine(str);

            Console.ReadKey();
        }
    }
}
