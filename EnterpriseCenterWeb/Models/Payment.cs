using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseCenterWeb.Models
{
    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        [ForeignKey("Customer")]
        public decimal CustomerNumber { get; set; }
        [Key]
        public string CheckNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public virtual Customer CustomerNumberNavigation { get; set; }
    }
}
