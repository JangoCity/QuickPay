using System.IO;
using QuickPay.Common;

namespace QuickPay.WxPay
{
    /// <summary>用于加载微信支付配置
    /// </summary>
    public class WxPayConfigLoader
    {
        /// <summary>从文件中加载微信支付的配置
        /// </summary>
        public WxPayConfig LoadFromPath(string path)
        {
            var xmlString = File.ReadAllText(path);
            var unilayerXml = new UnilayerXml(xmlString);
            var config = new WxPayConfig();
            foreach (var kv in unilayerXml.GetValues())
            {

            }
            return config;
        }
    }
}
