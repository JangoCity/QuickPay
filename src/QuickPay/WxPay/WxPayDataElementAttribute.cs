using System;

namespace QuickPay.WxPay
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class WxPayDataElementAttribute : Attribute
    {
        /// <summary>是否为必须的参数
        /// </summary>
        public bool IsRequired { get; private set; }
        /// <summary>实际的参数名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>根据条件判断IsRequired是否为True
        /// </summary>
        public string Condition { get;private set; }

        public WxPayDataElementAttribute(string name, bool isRequired = true)
        {
            Name = name;
            IsRequired = isRequired;
        }

        public WxPayDataElementAttribute(string name, string condition)
        {
            Name = name;
            Condition = condition;
        }
    }
}
