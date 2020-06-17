using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using ProductApplication.Models;
using ProductApplication.MongoDb_Models;

namespace ProductApplication.Repositories
{
    public class MongoDbProductRepository : IMongoDbProductRepository
    {


        private MongoClient client;
            private IMongoDatabase database;
            private IMongoCollection<MongoProduct> collection;
 
        public MongoDbProductRepository()
        {

             client = new MongoClient("mongodb://localhost:27017");
             database = client.GetDatabase("Warehouse");
             collection = database.GetCollection<MongoProduct>("Products");


        }

        public IEnumerable<MongoProduct> GetAllProducts()
        {
            var allProducts = collection.Find(Builders<MongoProduct>.Filter.Empty);
            return allProducts.ToEnumerable();
        }

        

        public MongoProduct GetByProductId(string productId)
        {
            throw new NotImplementedException();
        }

        public void InsertProduct(string tableName, MongoProduct product)
        {
              var collection = database.GetCollection<MongoProduct>(tableName);
            collection.InsertOne(product);
        }

        public string RemoveProduct(MongoProduct product)
        {
            throw new NotImplementedException();
        }

        

        public void SaveProduct(List<MongoProduct> products)
        {
            throw new NotImplementedException();
        }

        

        public string UpdateProduct(MongoProduct product)
        {
            throw new NotImplementedException();
        }

       

        
    }
}
