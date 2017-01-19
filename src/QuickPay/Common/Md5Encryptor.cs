using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QuickPay.Common
{
    /// <summary>Md5加密
    /// </summary>
    public class Md5Encryptor
    {
        /// <summary>加密字节
        /// </summary>
        public static string GetMd5(byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(data).Aggregate("", (current, b) => current + b.ToString("x"));
            }
        }

        /// <summary>加密字符串
        /// </summary>
        public static string GetMd5(string data, string encode = "utf-8")
        {
            return GetMd5(Encoding.GetEncoding(encode).GetBytes(data));
        }
    }
}
