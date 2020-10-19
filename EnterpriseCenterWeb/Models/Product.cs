using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseCenterWeb.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        [ForeignKey("ProductLine")]
        public string ProductLineName { get; set; }
        public string ProductScale { get; set; }
        public string ProductVendor { get; set; }
        public string ProductDescription { get; set; }
        public decimal QuantityInStock { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal Msrp { get; set; }

        public virtual ProductLine ProductlineNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
