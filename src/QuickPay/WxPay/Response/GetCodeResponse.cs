namespace QuickPay.WxPay.Response
{
    public class GetCodeResponse : WxPayResponse
    {
        public string Url { get; set; }

        public GetCodeResponse()
        {

        }

        public GetCodeResponse(string url)
        {
            Url = url;
        }
    }
}
