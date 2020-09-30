using System;
using System.Collections.Generic;

namespace EnterpriseCenterApp.Model
{
    public partial class Offices
    {
        public Offices()
        {
            Employees = new HashSet<Employees>();
        }

        public string Officecode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postalcode { get; set; }
        public string Territory { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
