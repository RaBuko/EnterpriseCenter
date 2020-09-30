using System;
using System.Collections.Generic;

namespace EnterpriseCenterApp.Model
{
    public partial class Productlines
    {
        public Productlines()
        {
            Products = new HashSet<Products>();
        }

        public string Productline { get; set; }
        public string Textdescription { get; set; }
        public string Htmldescription { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
