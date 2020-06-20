using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using ProductApplication;
using ProductApplication.Controller;
using ProductApplication.Models;
using MongoDB.Driver;

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
            var _client = new MongoClient("mongodb://localhost:27017");
            var _database = _client.GetDatabase("Läger");
            var _collection = _database.GetCollection<Product>("Produkter");
            _collection.InsertOne(new Product() {Name= "Nachos"});
        }
    }
}

