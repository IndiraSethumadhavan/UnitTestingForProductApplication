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
            

            mongoRep.InsertProduct("Products",new MongoProduct { ProductId= "5eea1bf08ad05d339877dee3", Name="Milk",Price=123,ProductInStock=12});
            #endregion


        }
    }
}

