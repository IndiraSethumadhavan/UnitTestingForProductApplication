using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductApplication.Models
{
     

    public class Product
    {
        public object IsValid;

        public string  Name { get; set; }
        public decimal Price { get; set; }
        public long ProductId { get; set; }
        
        public Manufacturer ManufacturerDetails { get; set; }

        public int ProductInStock { get; set; }

    }
}
