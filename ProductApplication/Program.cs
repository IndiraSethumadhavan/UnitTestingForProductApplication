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
using MongoDB.Bson;

namespace ProductApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            #region JsonFileOperations
            ////Product Management
            ProductManagement prod = new ProductManagement();
            prod.ProdManagment();

            ////Store Management
            StoreManagement store = new StoreManagement();
            store.StoresManagment();
            #endregion

            #region MongoDbOperations
            //MongoDbProductManagement
            MongoDbProductManagement product = new MongoDbProductManagement();
            product.MongoDbProdManagment();
            #endregion


        }
    }
}

