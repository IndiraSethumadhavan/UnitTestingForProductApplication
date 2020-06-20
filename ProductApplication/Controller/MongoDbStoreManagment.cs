using ProductApplication.MongoDb_Models;
using ProductApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductApplication.Controller
{
   public class MongoDbStoreManagment
    {
        public void MongodbStoreManagement()
        {
            Console.WriteLine("\n\t*****Store MongoDb Implementation*****\n");
            InsertStore();
            RemoveStore(new MongoStore());
            UpdateStore(new MongoStore(){ });
            GetAllStores();
            GetByStoreId("5eee16963dc7fb28acaaf2d4");
        }
        public void InsertStore()
        {
            var mongoStore = new MongoDbStoreRepository();
            var Products = new MongoDbProductRepository();
            var store = new MongoStore() { StoreName = "COop", ProductDetails = Products.GetAllProducts().ToList() };
            mongoStore.InsertStore(store);
        }
        public string RemoveStore(MongoStore store)
        {
            var mongoDbStoreRepository = new MongoDbStoreRepository();
            string Result = mongoDbStoreRepository.RemoveStore(store);
            Console.WriteLine(Result);
            Console.WriteLine();
            return Result;
        }
        public string UpdateStore(MongoStore store)
        {
            var mongoDbStoreRepository = new MongoDbStoreRepository();
            string result = mongoDbStoreRepository.UpdateStore(store);
            Console.WriteLine(result);
            Console.WriteLine();
            return result;
        }

        public void GetAllStores()
        {
            var mongoDbStoreRepository = new  MongoDbStoreRepository();
            IEnumerable<MongoStore> StoreList = mongoDbStoreRepository.GetAllStores();
            Console.WriteLine("\n\t********Stores details************\n");
            foreach (var store in StoreList)
            {
                Console.WriteLine(store);
            }
        }

        public void GetByStoreId(string storeId)
        {
            var mongoDbStoreRepository = new MongoDbStoreRepository();
            MongoStore store = mongoDbStoreRepository.GetByStoreId(storeId);
            if (store != null)
            {
                Console.WriteLine();
                Console.WriteLine("******Matched record by StoreId*****");
                Console.WriteLine(store);
            }
            else
                Console.WriteLine("No matched records found for the productID:{0}:" + storeId);
        }
    }
}
