using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Felipe.Models
{
    public class Supplier
    {
        public long SupplierId { get; set; }
        public String Nome { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}