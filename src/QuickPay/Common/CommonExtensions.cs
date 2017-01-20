using System.Collections.Generic;

namespace QuickPay.Common
{
    /// <summary>公共的一些扩展
    /// </summary>
    public static class CommonExtensions
    {
        /// <summary>将Sorted集合转换为Json
        /// </summary>
        public static string ToJson(this SortedDictionary<string, string> sortedDictionary)
        {
            return JsonSerializer.Serialize(sortedDictionary);
        }
    }
}
