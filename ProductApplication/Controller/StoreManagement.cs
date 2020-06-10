using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductApplication.Models;
using ProductApplication.Repositories;

namespace ProductApplication.Controller
{
    public class StoreManagement
    {
        StoreRepository storeRepository;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        public void StoresManagment()
        {
            try
            {

                CreateStore();

                GetAllStoresDetails();

                storeRepository = new StoreRepository();
                storeRepository.GetByStoreId(4356);

                GetStoresBySearch("Lid");

                UpdateStore();

                RemoveStore();

                AddProductInStore();

                RemoveProductInStore();

                ProductInStock();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Remove Store
        /// </summary>
        private void RemoveStore()
        {
            storeRepository = new StoreRepository();
            Store store2 = new Store() { StoreId = 4356, StoreName = "IKEA" };
            storeRepository.RemoveStore(store2);
            Console.WriteLine("Store item is removed successfully");
            Console.WriteLine();
        }

        /// <summary>
        /// Update store
        /// </summary>
        private void UpdateStore()
        {
            storeRepository = new StoreRepository();
            Store store1 = new Store() { StoreId = 2333, StoreName = "HemKop" };
            storeRepository.UpdateStore(store1);
            Console.WriteLine("Store Name is updated successfully");
            Console.WriteLine();
        }

        /// <summary>
        /// Product In Stock
        /// </summary>
        private void ProductInStock()
        {
            storeRepository = new StoreRepository();
            Console.WriteLine("******Product which is in stock available********");
            Product product8 = new Product() { Name = "Muffins", Price = 78.95m, ProductId = 760, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SEE", Place = "Qvidingsgatan", PhoneNumber = 764500000 } };
            storeRepository.ProductInStock(product8);
            
        }

        /// <summary>
        /// Remove Product from store
        /// </summary>
        private void RemoveProductInStore()
        {
            storeRepository = new StoreRepository();
            ProductRepository productRepository = new ProductRepository();
            Product product6 = productRepository.GetByProductId(307);
            storeRepository.RemoveProductInStore(product6, 9999);
            Console.WriteLine("Product is removed successfully from store");
            Console.WriteLine();
        }

        /// <summary>
        /// Add Product In Store
        /// </summary>
        private void AddProductInStore()
        {
            storeRepository = new StoreRepository();
            ProductRepository productRepository = new ProductRepository();

            
            Product muffinsProduct = productRepository.GetByProductId(760);

            
            muffinsProduct.ProductInStock = 15;
            storeRepository.AddProductInStore(muffinsProduct, 7455);
            muffinsProduct.ProductInStock = 10;
            storeRepository.AddProductInStore(muffinsProduct, 8696);
            muffinsProduct.ProductInStock = 0;
            storeRepository.AddProductInStore(muffinsProduct, 9999);
            Console.WriteLine("Product is added successfully to store");
            Console.WriteLine();
        }

        /// <summary>
        /// Get Stores By Search
        /// </summary>
        /// <param name="searchString"></param>
        private void GetStoresBySearch(string searchString)
        {
            storeRepository = new StoreRepository();
            var obj1 = storeRepository.GetStoresBySearch(searchString);

            Console.WriteLine();
            Console.WriteLine("******Matched record by StoreName*******");

            foreach (Store record in obj1)
            {
                foreach (var storeProducts in record.ProductDetails)
                {
                    Console.WriteLine($"StoreId : {record.StoreId} StoreName: {record.StoreName} ProductName:{storeProducts.Name} Price:{storeProducts.Price} ProductId:{storeProducts.ProductId}ProductInStock:{storeProducts.ProductInStock} ManufacturerName:{storeProducts.ManufacturerDetails.ManufacturerName} PhoneNumber:{storeProducts.ManufacturerDetails.PhoneNumber} Place:{storeProducts.ManufacturerDetails.Place}");

                }

            }
            Console.WriteLine();
        }


        /// <summary>
        /// To get all the store details
        /// </summary>
        private void GetAllStoresDetails()
        {
            storeRepository = new StoreRepository();
            IEnumerable<Store> storeDetails = storeRepository.GetAllStores();
            Console.WriteLine("********Store  details************");
            foreach (var storeData in storeDetails)
            {
                Console.WriteLine($"---Store : {storeData.StoreName} Details ---");
                foreach (var storeProduct in storeData.ProductDetails)
                {
                    Console.WriteLine($"StoreId : {storeData.StoreId} StoreName: {storeData.StoreName} ProductName:{storeProduct.Name} Price:{storeProduct.Price} ProductId:{storeProduct.ProductId} ProductInStock:{storeProduct.ProductInStock} ManufacturerName:{storeProduct.ManufacturerDetails.ManufacturerName} PhoneNumber:{storeProduct.ManufacturerDetails.PhoneNumber} Place:{storeProduct.ManufacturerDetails.Place}");
                }
            }
        }

        /// <summary>
        /// Create Store
        /// </summary>
        public void CreateStore()
        {
            var jsonPath = Path.Combine(path, "StoresDetails.json");
            if (File.Exists(jsonPath))
            {
                File.Delete(jsonPath);

            }
            ProductRepository rep1 = new ProductRepository();
            IEnumerable<Product> productRecords = rep1.GetAllProducts();
            
            var records = new List<Store>
            {

                new Store() { StoreId = 1234, StoreName = "Lidl", ProductDetails =productRecords.Take(5).ToList<Product>() },
                new Store() { StoreId = 4356, StoreName = "IKEA", ProductDetails =productRecords.TakeLast(8).ToList<Product>() },
                new Store() { StoreId = 5657, StoreName = "ICA", ProductDetails =productRecords.Take(10).ToList<Product>() },
                new Store() { StoreId = 8696, StoreName = "COOP", ProductDetails =productRecords.Take(14).ToList<Product>() },
                new Store() { StoreId = 7455, StoreName = "Willys", ProductDetails =productRecords.Take(16).ToList<Product>() },
                new Store() { StoreId = 2333, StoreName = "HemKop", ProductDetails =productRecords.Take(18).ToList<Product>() },
                new Store() { StoreId = 9999, StoreName = "Pressbyran", ProductDetails =productRecords.Take(2).ToList<Product>() }
                
            };
            IStoreRepository storeRepository = new StoreRepository();
            storeRepository.SaveStore(records);
            Console.WriteLine("**********Stores created successfully*********");
            Console.WriteLine();
        }
    }
}
