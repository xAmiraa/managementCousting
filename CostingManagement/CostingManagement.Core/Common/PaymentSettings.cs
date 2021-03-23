using System;
using System.Collections.Generic;
using System.Text;

namespace CostingManagement.Core.Common
{
    public class PaymentSettings
    {
        public string SecretKey { get; set; }
        public string PublishableKey { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
    }
}
