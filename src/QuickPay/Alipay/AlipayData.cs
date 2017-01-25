using System.Collections.Generic;
using System.Text;
using QuickPay.Common;

namespace QuickPay.Alipay
{
    /// <summary>支付宝支付数据
    /// </summary>
    public class AlipayData
    {
        private readonly SortedDictionary<string, object> _values = new SortedDictionary<string, object>();

        public AlipayData()
        {
        }

        public AlipayData(string json)
        {
           
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

        /// <summary>将数据转换为Json
        /// </summary>
        public string ToJson()
        {
            return JsonSerializer.Serialize(_values);
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
                    throw new AlipayException("AlipayData内部含有值为null的字段!");
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


    }
}
