using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Felipe.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String Nome { get; set; } 

        public virtual ICollection<Product> Products { get; set; }
    }
}