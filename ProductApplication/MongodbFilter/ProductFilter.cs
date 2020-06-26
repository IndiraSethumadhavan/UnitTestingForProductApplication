using ProductApplication.Models;
using ProductApplication.MongoDb_Models;
using ProductApplication.Repositories;
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carbon.Packaging;

namespace ProductApplication.MongodbFilter
{
    class ProductFilter
    {
        private IMongoDbProductRepository MongoDbProductRepository { get; }
        private IMongoStore MongoDbStoreRepository { get; }

        public ProductFilter(IMongoDbProductRepository productRepository, IMongoStore storeRepository)
        {
            MongoDbProductRepository = productRepository;
            MongoDbStoreRepository = storeRepository;
        }

        public IEnumerable<MongoProduct> SearchProductByName(string name)
        {
            return MongoDbProductRepository.GetAllProducts().Where(p => p.Name.Contains(name));
        }

        public IEnumerable<MongoProduct> ProductsCostingLessThan(decimal price)
        {
            return MongoDbProductRepository.GetAllProducts().Where(p => p.Price < price).Take(10);
        }

        public void ListOfManufacturersWithProductCount()
        {
            var manufacturerList = MongoDbProductRepository.GetAllProducts();
            var groupedManufacturerRecords =
                                              manufacturerList.GroupBy(c => c.ManufacturerDetails.ManufacturerName);

            Console.WriteLine("****List of Manufacturer details*****");

            foreach (var groups in groupedManufacturerRecords)
            {
                Console.WriteLine("ManufacturerName:" + groups.Key + "\n" + "Total no of products:" + groups.Count());
                foreach (var c in groups)
                {
                    Console.WriteLine("\t" + "ProductName:" + c.Name + "," + "Price:" + c.Price);

                }
                Console.WriteLine();
            }

        }


        public void GetStoresBySearch(string searchString)
        {
           IMongoStore storeRepository = new MongoDbStoreRepository();
            IEnumerable<MongoStore> storeList = storeRepository.GetAllStores();
            IEnumerable<MongoStore> storeDetails = from rec in storeList
                                              where rec.StoreName.Contains(searchString)
                                              select rec;
            Console.WriteLine();
            Console.WriteLine("********Matched record by Store Name************");
            foreach (var storeData in storeDetails)
            {
                Console.WriteLine($"---Store : {storeData.StoreName} Details ---");
                foreach (var storeProduct in storeData.ProductDetails)
                {
                    Console.WriteLine($"StoreId : {storeData.Id} StoreName: {storeData.StoreName} ProductName:{storeProduct.Name} Price:{storeProduct.Price}  ProductInStock:{storeProduct.ProductInStock} ManufacturerName:{storeProduct.ManufacturerDetails.ManufacturerName} PhoneNumber:{storeProduct.ManufacturerDetails.PhoneNumber} Place:{storeProduct.ManufacturerDetails.Place}");
                }
            }
            Console.WriteLine();
        }

    }
}





