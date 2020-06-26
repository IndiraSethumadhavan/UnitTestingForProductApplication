using ProductApplication.Models;
using ProductApplication.MongoDb_Models;
using ProductApplication.MongodbFilter;
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
            RemoveStore(new MongoStore() { StoreName = "HemKop" });
            var productList = new List<MongoProduct>()
            {
            new MongoProduct (){ Name = "Salt", Price = 34.57m, ProductInStock = 8, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SSS", PhoneNumber = 762892347, Place = "Chalmers" } },
            new MongoProduct () { Name = "Muffins", Price = 50.37m, ProductInStock = 16, ManufacturerDetails = new Manufacturer() { ManufacturerName = "AWE", PhoneNumber = 762892856, Place = "Hjlmar" } }

              };
            UpdateStore(new MongoStore() { Id = "5ef5c31458ed8642580d7cc3", StoreName = "Pressbyran", StoreAddress = "777 Chalmers" ,PinCode=2222,ProductDetails=productList });

            GetAllStores();
            GetByStoreId("5ef5c31458ed8642580d7cbf");

            //StoreFilter
            IMongoDbProductRepository productRepository = new MongoDbProductRepository();
            IMongoStore storeRepository = new MongoDbStoreRepository();
            ProductFilter storeFilter = new ProductFilter(productRepository, storeRepository);

            //searchBy Store
            storeFilter.GetStoresBySearch("Lidl");
        }
        public void InsertStore()
        {
            
            IMongoStore mongoStore = new MongoDbStoreRepository();
            IMongoDbProductRepository mongoProduct = new MongoDbProductRepository();
            //mongoStore.DropCollection();
            mongoStore.InsertStore(new MongoStore() { StoreName = "Lidl",StoreAddress="111 Backebol Norra",PinCode =1234, ProductDetails = mongoProduct.GetAllProducts().Take(5).ToList<MongoProduct>() });
            mongoStore.InsertStore(new MongoStore() { StoreName = "COOP", StoreAddress = "223 Elisedal",PinCode= 4567, ProductDetails = mongoProduct.GetAllProducts().TakeLast(8).ToList<MongoProduct>() });
            mongoStore.InsertStore(new MongoStore() { StoreName = "ICA", StoreAddress = "345 Korsvagen",PinCode=8907, ProductDetails = mongoProduct.GetAllProducts().Take(10).ToList<MongoProduct>() });
            mongoStore.InsertStore(new MongoStore() { StoreName = "Willys", StoreAddress = "234 Wavrinskyplats",PinCode=9356, ProductDetails = mongoProduct.GetAllProducts().Take(13).ToList<MongoProduct>() });
            mongoStore.InsertStore(new MongoStore() { StoreName = "HemKop", StoreAddress = "435 Kapelplatsen",PinCode=8976, ProductDetails = mongoProduct.GetAllProducts().Take(8).ToList<MongoProduct>() });
            mongoStore.InsertStore(new MongoStore() { StoreName = "Pressbyran", StoreAddress = "444 Hjalmar ",PinCode=2345, ProductDetails = mongoProduct.GetAllProducts().TakeLast(2).ToList<MongoProduct>() });
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
                Console.WriteLine($"---Store : {store.StoreName} Details ---");
                foreach (var productDetails in store.ProductDetails)
                {

                    Console.WriteLine($"StoreId :{store.Id} StoreName: {store.StoreName} StoreAddress:{store.StoreAddress} ProductName: {productDetails.Name} Price:{productDetails.Price} ProductInStock:{productDetails.ProductInStock} ManufacturerName:{productDetails.ManufacturerDetails.ManufacturerName} PhoneNumber:{productDetails.ManufacturerDetails.PhoneNumber} Place:{productDetails.ManufacturerDetails.Place}");

                }
                
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

                foreach(var productDetails in store.ProductDetails)
                {
                    Console.WriteLine($"StoreId :{store.Id} StoreName: {store.StoreName} ProductName: {productDetails.Name} Price:{productDetails.Price} ProductInStock:{productDetails.ProductInStock} ManufacturerName:{productDetails.ManufacturerDetails.ManufacturerName} PhoneNumber:{productDetails.ManufacturerDetails.PhoneNumber} Place:{productDetails.ManufacturerDetails.Place}");

                }
            }
            else
                Console.WriteLine("No matched records found for the productID:{0}:" + storeId);
        }
    }
}
