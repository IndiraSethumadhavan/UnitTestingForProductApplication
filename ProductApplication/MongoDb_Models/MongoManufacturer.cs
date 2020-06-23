using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApplication.MongoDb_Models
{
   public class MongoManufacturer
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public string Place { get; set; }
        public int PhoneNumber { get; set; }
    }
}
