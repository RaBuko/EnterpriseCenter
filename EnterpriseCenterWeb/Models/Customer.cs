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
        [Display(Name = "Contact name")]
        public string ContactFirstName { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Address")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address")]
        public string AddressLine2 { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [ForeignKey("Employee")]
        public decimal? SalesRepEmployeeNumber { get; set; }
        [Display(Name = "Credit limit")]
        public decimal? CreditLimit { get; set; }

        public virtual Employee SalesRepEmployeeNumberNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
