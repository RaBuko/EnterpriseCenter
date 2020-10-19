using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseCenterWeb.Models
{
    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [ForeignKey("Order")]
        public decimal OrderNumber { get; set; }
        [Key]
        [ForeignKey("Product")]
        public string ProductCode { get; set; }
        public decimal QuantityOrdered { get; set; }
        public decimal PriceEach { get; set; }
        public decimal OrderLineNumber { get; set; }

        public virtual Order OrderNumberNavigation { get; set; }
        public virtual Product ProductCodeNavigation { get; set; }
    }
}
