
using ProductApplication.Models;
using MongoDB.Driver;
using ProductApplication.Repositories;
using ProductApplication.Controller;
using ProductApplication.MongoDb_Models;


namespace ProductApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Product Management
            //ProductManagement prod = new ProductManagement();
            //prod.ProdManagment();

            ////Store Management
            //StoreManagement store = new StoreManagement();
            //store.StoresManagment();
            //var _client = new MongoClient("mongodb://localhost:27017");
            //var _database = _client.GetDatabase("Läger");
            //var _collection = _database.GetCollection<Product>("Produkter");
            //_collection.InsertOne(new Product() { Name = "Nachos" });

           
            MongoDbProductManagement prod = new MongoDbProductManagement();
            prod.MongoDbProdManagment();
            MongoDbStoreManagment mongoDbStoreManagment = new MongoDbStoreManagment();
            mongoDbStoreManagment.MongodbStoreManagement();
            


        }
    }
}

