using System;
using System.Collections.Generic;

namespace EnterpriseCenterApp.Model
{
    public partial class Payments
    {
        public decimal Customernumber { get; set; }
        public string Checknumber { get; set; }
        public DateTime Paymentdate { get; set; }
        public decimal Amount { get; set; }

        public virtual Customers CustomernumberNavigation { get; set; }
    }
}
