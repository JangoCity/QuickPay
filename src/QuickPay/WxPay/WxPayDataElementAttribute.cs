using System;

namespace QuickPay.WxPay
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class WxPayDataElementAttribute : Attribute
    {
        /// <summary>是否为必须的参数
        /// </summary>
        public bool IsRequired { get; private set; }

        public string Name { get; private set; }

        public WxPayDataElementAttribute(string name, bool isRequired = true)
        {
            Name = name;
            IsRequired = isRequired;
        }
    }
}
