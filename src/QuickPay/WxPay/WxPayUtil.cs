using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QuickPay.WxPay
{
    public class WxPayUtil
    {
        /// <summary>验证请求的参数
        /// </summary>
        public bool VerifyRequestData<T>(IWxPayRequest<T> request) where T : WxPayResponse
        {
            //获取属性中名称不为Sign的
            var properties = request.GetType().GetTypeInfo()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name != WxPayConsts.Sign);
            //获取需要进行验证的参数
            var requireds = properties.Where(x =>
            {
                var attribute = x.GetCustomAttribute<WxPayDataElementAttribute>();
                if (attribute != null)
                {
                    if (string.IsNullOrWhiteSpace(attribute.Condition) && attribute.IsRequired)
                    {
                        return true;
                    }
                    if (!string.IsNullOrWhiteSpace(attribute.Condition))
                    {
                        
                    }
                }
                //True需要进行验证,False则不需要进行验证
                return false;
            });
            return true;
        }


    }
}
