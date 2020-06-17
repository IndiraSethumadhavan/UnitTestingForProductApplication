using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using ProductApplication;
using ProductApplication.Controller;
using MongoDB.Driver;
using ProductApplication.Models;
using ProductApplication.Repositories;
using ProductApplication.MongoDb_Models;

namespace ProductApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            #region JsonFileOperations
            ////Product Management
            //ProductManagement prod = new ProductManagement();
            //prod.ProdManagment();

            ////Store Management
            //StoreManagement store = new StoreManagement();
            //store.StoresManagment();
            #endregion

            #region MongoDbOperations

            IMongoDbProductRepository mongoRep = new MongoDbProductRepository();
            IEnumerable<MongoProduct> productList = mongoRep.GetAllProducts();
            List<MongoProduct> records = new List<MongoProduct>
            {
               new MongoProduct { ProductId = "5eea1bf08ad05d339877dee3", Name = "Milk", Price = 123, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", PhoneNumber = 762892451, Place = "Redbergplasten" } },
               new MongoProduct { ProductId = "6ffa1bf08ad05d339877dee3", Name = "SoyaMilk", Price = 345, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "VVV", PhoneNumber = 762892400, Place = "Hjlmar" } }

        };


            mongoRep.InsertProduct("Products", records);
            //mongoRep.InsertProduct("Products", new MongoProduct(){ ProductId = "5eea1bf08ad05d339877dee3", Name = "Milk", Price = 123, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", PhoneNumber = 762892451, Place = "Redbergplasten" } });


            //mongoRep.InsertProduct("Products",new MongoProduct { ProductId = "5eea1bf08ad05d339877dee3", Name = "Milk", Price = 123, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", PhoneNumber = 762892451, Place = "Redbergplasten" } });
            //mongoRep.InsertProduct("Products", 
            //    new MongoProduct() { ProductId = "5eea1bf08ad05d339877dee3", Name = "Milk", Price = 123, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", PhoneNumber = 762892451, Place = "Redbergplasten" } },

            //new MongoProduct() { ProductId = "5eea1bf08ad05d339877dee3", Name = "SoyaMilk", Price = 345, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "VVV", PhoneNumber = 762892451, Place = "Redbergplasten" } });


            #endregion


        }
    }
}

