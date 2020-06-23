using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using MongoDB.Bson;
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
            database = client.GetDatabase("Läger");
            collection = database.GetCollection<MongoProduct>("Products");


        }

        public IEnumerable<MongoProduct> GetAllProducts()
        {
            var allProducts = collection.Find(Builders<MongoProduct>.Filter.Empty);
            
           
            return allProducts.ToEnumerable();
        }



        public MongoProduct GetByProductId(string productId)
        {
            
            MongoProduct record = collection.Find(Builders<MongoProduct>.Filter.Eq(x => x.Id, productId)).FirstOrDefault();

            return record;
        }


        public void InsertProduct(MongoProduct product)
        {
            
            var foundItems = collection.Find<MongoProduct>(x => x.Name == product.Name).Any();
            if(!foundItems)
                collection.InsertOne(product);
        }


        //public void DropCollection()
        //{
        //    database.DropCollection("Products");
            
        //}



        public string RemoveProduct(MongoProduct product)
        {

            collection.DeleteOne(s => s.Name == product.Name);
            return "Product is removed successfully :" + product.Name;
        }



        public void SaveProduct(List<MongoProduct> products)
        {
            throw new NotImplementedException();
        }

        public string UpdateProduct(MongoProduct product)
        {

            collection.ReplaceOne(p => p.Name == product.Name, product);
            


            return "Product Price and Manufacturer details is updated successfully";
        }
    }
}
