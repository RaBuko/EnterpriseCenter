using System;
using System.Collections.Generic;

namespace EnterpriseCenterApp.Model
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
            Payments = new HashSet<Payments>();
        }

        public decimal Customernumber { get; set; }
        public string Customername { get; set; }
        public string Contactlastname { get; set; }
        public string Contactfirstname { get; set; }
        public string Phone { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public decimal? Salesrepemployeenumber { get; set; }
        public decimal? Creditlimit { get; set; }

        public virtual Employees SalesrepemployeenumberNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
