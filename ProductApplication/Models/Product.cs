using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ProductApplication.Models
{
     

    public class Product
    {
       
        public string  Name { get; set; }
        public decimal Price { get; set; }
       
        public int ProductId { get; set; }
        public Manufacturer ManufacturerDetails { get; set; }
        public int ProductInStock { get; set; }
    }
}
