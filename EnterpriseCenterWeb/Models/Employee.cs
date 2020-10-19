using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseCenterWeb.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Customers = new HashSet<Customer>();
            InverseReportsToNavigation = new HashSet<Employee>();
        }
        [Key]
        public decimal EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        [ForeignKey("Office")]
        public string OfficeCode { get; set; }
        [ForeignKey("Employee")]
        public decimal? ReportsTo { get; set; }
        public string JobTitle { get; set; }

        public virtual Office OfficeCodeNavigation { get; set; }
        public virtual Employee ReportsToNavigation { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; }
    }
}
