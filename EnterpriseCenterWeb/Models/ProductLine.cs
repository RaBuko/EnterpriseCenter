using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseCenterWeb.Models
{
    [Table("ProductLine")]
    public partial class ProductLine
    {
        public ProductLine()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public string ProductLineName { get; set; }
        public string TextDescription { get; set; }
        public string HtmlDescription { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
