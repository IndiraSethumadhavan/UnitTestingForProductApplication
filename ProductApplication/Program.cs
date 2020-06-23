
using ProductApplication.Models;
using MongoDB.Driver;
using ProductApplication.Repositories;
using ProductApplication.Controller;
using ProductApplication.MongoDb_Models;
using MongoDB.Bson;


namespace ProductApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region JsonFileOperations
            //Product Management
            ProductManagement prod = new ProductManagement();
            prod.ProdManagment();

            //Store Management
            StoreManagement store = new StoreManagement();
            store.StoresManagment();
            #endregion

            #region MongoDbOperations
            //MongoDbProductManagement
            MongoDbProductManagement product = new MongoDbProductManagement();
            product.MongoDbProdManagment();

            MongoDbStoreManagment mongoDbStoreManagment = new MongoDbStoreManagment();
            mongoDbStoreManagment.MongodbStoreManagement();
            #endregion


        }
    }
}

