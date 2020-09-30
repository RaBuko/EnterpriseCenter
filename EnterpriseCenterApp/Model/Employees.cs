using System;
using System.Collections.Generic;

namespace EnterpriseCenterApp.Model
{
    public partial class Employees
    {
        public Employees()
        {
            Customers = new HashSet<Customers>();
            InverseReportstoNavigation = new HashSet<Employees>();
        }

        public decimal Employeenumber { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public string Officecode { get; set; }
        public decimal? Reportsto { get; set; }
        public string Jobtitle { get; set; }

        public virtual Offices OfficecodeNavigation { get; set; }
        public virtual Employees ReportstoNavigation { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Employees> InverseReportstoNavigation { get; set; }
    }
}
