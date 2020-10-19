using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseCenterWeb.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
        }

        [Key]
        [Display(Name = "Customer number")]
        public decimal CustomerNumber { get; set; }
        [Display(Name = "Customer name")]
        public string CustomerName { get; set; }
        [Display(Name = "Contact last name")]
        public string ContactLastName { get; set; }
        public string ContactFirstName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [ForeignKey("Employee")]
        public decimal? SalesRepEmployeeNumber { get; set; }
        public decimal? CreditLimit { get; set; }

        public virtual Employee SalesRepEmployeeNumberNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
