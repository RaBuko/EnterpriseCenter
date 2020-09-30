using System;
using System.Collections.Generic;

namespace EnterpriseCenterApp.Model
{
    public partial class Products
    {
        public Products()
        {
            Orderdetails = new HashSet<Orderdetails>();
        }

        public string Productcode { get; set; }
        public string Productname { get; set; }
        public string Productline { get; set; }
        public string Productscale { get; set; }
        public string Productvendor { get; set; }
        public string Productdescription { get; set; }
        public decimal Quantityinstock { get; set; }
        public decimal Buyprice { get; set; }
        public decimal Msrp { get; set; }

        public virtual Productlines ProductlineNavigation { get; set; }
        public virtual ICollection<Orderdetails> Orderdetails { get; set; }
    }
}
