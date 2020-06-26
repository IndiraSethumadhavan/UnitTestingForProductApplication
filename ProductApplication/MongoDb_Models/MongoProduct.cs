using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProductApplication.Models;


namespace ProductApplication.MongoDb_Models
{
    
    public class MongoProduct
    {
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Manufacturer ManufacturerDetails { get; set; }
        public int ProductInStock { get; set; }
        
    }
}

