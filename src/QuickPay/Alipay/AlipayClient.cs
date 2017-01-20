using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickPay.Alipay
{
    public class AlipayClient : IAlipayClient
    {
        private readonly AlipayConfig _config;

        #region ctor
        public AlipayClient(AlipayConfig config)
        {
            _config = config;
        } 
        #endregion
    }
}
