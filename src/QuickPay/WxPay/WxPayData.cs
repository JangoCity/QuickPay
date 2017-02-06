using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace QuickPay.WxPay
{
    public class WxPayData
    {
        private readonly SortedDictionary<string, object> _values = new SortedDictionary<string, object>();

        public WxPayData()
        {
        }

        public WxPayData(string xml)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var root = xmlDoc.DocumentElement;
            if (root != null)
            {
                foreach (XmlNode node in root.ChildNodes)
                {
                    XmlElement xe = (XmlElement) node;
                    _values[xe.Name] = xe.InnerText; //获取xml的键值对到WxPayData内部的数据中
                }
            }
        }

        /// <summary>设置key和value
        /// </summary>
        public void SetValue(string key, object value)
        {
            _values[key] = value;
        }

        /// <summary>根据key获取value
        /// </summary>
        public object GetValue(string key)
        {
            object o;
            _values.TryGetValue(key, out o);
            return o;
        }

        /// <summary>是否已经设置某个值
        /// </summary>
        public bool IsSet(string key)
        {
            object o;
            _values.TryGetValue(key, out o);
            return null != o;
        }

        /// <summary>获取数据
        /// </summary>
        public SortedDictionary<string, object> GetValues()
        {
            return _values;
        }



        /// <summary>将数据转换为xml
        /// </summary>
        public string ToXml()
        {
            if (!_values.Any())
            {
                throw new WxPayException("WxPayData数据为空!");
            }
            var sb = new StringBuilder();
            sb.Append($"<xml>");
            foreach (var kv in _values)
            {
                if (kv.Value == null)
                {
                    throw new WxPayException($"WxPayData内部含有值为null的字段,key:{kv.Key}");
                }
                if (kv.Value is int)
                {
                    sb.Append($"<{kv.Key}>{kv.Value}</{kv.Value}>");
                }
                else if (kv.Value is string)
                {
                    sb.Append($"<{kv.Key}><![CDATA[{kv.Value}]]></{kv.Value}>");
                }
                else
                {
                    throw new WxPayException("WxPayData字段数据类型错误!");
                }
            }
            sb.Append($"</xml>");
            return sb.ToString();
        }

        /// <summary>转换成拼接的Url
        /// </summary>
        public string ToUrl()
        {
            var sb = new StringBuilder();
            foreach (var pair in _values)
            {
                if (pair.Value == null)
                {
                    throw new WxPayException("WxPayData内部含有值为null的字段!");
                }
                if (pair.Key != "sign" && !string.IsNullOrWhiteSpace(pair.Value.ToString()))
                {
                    sb.Append($"{pair.Key}={pair.Value}&");
                }
            }
            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }


        /// <summary>对WxPayData进行签名
        /// </summary>
        public string MakeSign(string key)
        {
            //转url格式
            string str = $"{ToUrl()}&key={key}";
            //MD5加密
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            return sb.ToString().ToUpper();
        }

        /// <summary>签名验证
        /// </summary>
        public bool CheckSign(string key)
        {
            //如果没有设置签名，则跳过检测
            if (!IsSet("sign") || GetValue("sign").ToString() == "")
            {
                throw new WxPayException("WxPayData签名不存在!");
            }
            //获取接收到的签名
            string returnSign = GetValue("sign").ToString();
            //在本地计算新的签名
            string localSign = MakeSign(key);

            if (localSign == returnSign)
            {
                return true;
            }
            return false;
        }
    }
}
