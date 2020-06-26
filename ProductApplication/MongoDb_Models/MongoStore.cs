using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductApplication.MongoDb_Models
{
   public class MongoStore
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public int PinCode { get; set; }
        public List<MongoProduct> ProductDetails { get; set; } = new List<MongoProduct>();

        public MongoStore() { }
        
    }
    
}
