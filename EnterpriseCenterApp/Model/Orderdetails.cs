using System;
using System.Collections.Generic;

namespace EnterpriseCenterApp.Model
{
    public partial class Orderdetails
    {
        public decimal Ordernumber { get; set; }
        public string Productcode { get; set; }
        public decimal Quantityordered { get; set; }
        public decimal Priceeach { get; set; }
        public decimal Orderlinenumber { get; set; }

        public virtual Orders OrdernumberNavigation { get; set; }
        public virtual Products ProductcodeNavigation { get; set; }
    }
}
