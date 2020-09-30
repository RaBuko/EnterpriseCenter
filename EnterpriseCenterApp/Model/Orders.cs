using System;
using System.Collections.Generic;

namespace EnterpriseCenterApp.Model
{
    public partial class Orders
    {
        public Orders()
        {
            Orderdetails = new HashSet<Orderdetails>();
        }

        public decimal Ordernumber { get; set; }
        public DateTime Orderdate { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public decimal Customernumber { get; set; }

        public virtual Customers CustomernumberNavigation { get; set; }
        public virtual ICollection<Orderdetails> Orderdetails { get; set; }
    }
}
