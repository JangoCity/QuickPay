using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickPay.Common.Requests
{
    /// <summary>Http请求服务
    /// </summary>
    public class HttpService
    {
        private static readonly HttpClient Client;

        static HttpService()
        {
            var handler = CreateHandler();
            Client = new HttpClient(handler);
            Client.DefaultRequestHeaders.Connection.Add("Keep-Alive");
        }

#if NET45
        private static WebRequestHandler CreateHandler()
        {
            var handler = new WebRequestHandler
            {
                AllowAutoRedirect = false,
                MaxAutomaticRedirections = 3,
                ServerCertificateValidationCallback = (a, b, c, d) => true
            };

            return handler;
        }
#else
        private static HttpClientHandler CreateHandler()
        {
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false,
                MaxAutomaticRedirections = 3,
                ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            };
            return handler;
        }
#endif

        /// <summary>异步执行请求
        /// </summary>
        public static async Task<Response> ExecuteAsync(RequestBuilder builder)
        {
            var options = builder.GetOptions();
            var message = RequestUtil.BuildRequestMessage(options);
            var response = await Client.SendAsync(message);
            return await RequestUtil.ParseResponse(response);
        }

        /// <summary>Post提交数据
        /// </summary>
        public static async Task<Response> PostAsync(string url, PostType postType, string postString)
        {
            var builder = RequestBuilder.Instance(url, HttpMethods.Post).SetPost(postType, postString);
            return await ExecuteAsync(builder);
        }

        /// <summary>Get提交数据
        /// </summary>
        public static async Task<Response> GetAsync(string url,
            Dictionary<string, string> sParam = null)
        {
            var builder = RequestBuilder.Instance(url, HttpMethods.Get).SetParams(sParam);
            return await ExecuteAsync(builder);
        }

        /// <summary>Http请求方法,Get,Post
        /// </summary>
        public class HttpMethods
        {
            public const string Get = "GET";
            public const string Post = "POST";
        }
    }
}
