﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Felipe.Models
{
    public class Product
    {
        public long? ProductId { get; set; }
        public String Nome { get; set; }

        public long? CategoryId { get; set; }
        public long? SupplierId { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}