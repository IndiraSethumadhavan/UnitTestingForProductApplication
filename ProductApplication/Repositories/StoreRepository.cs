using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProductApplication.Models;
using ProductApplication.Utilities;

namespace ProductApplication.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        public void RemoveStore(Store store)
        {
            IEnumerable<Store> storeList = GetAllStores();
            var storeListAfterRemoval = storeList.Where(c => c.StoreId != store.StoreId).ToList();
            SaveStore(storeListAfterRemoval);
        }

        public void SaveStore(List<Store> store)
        {
            var jsonPath = Path.Combine(path, "StoreDetails.json");
            Utility.SaveToJson<Store>(jsonPath, store);
        }

        public void UpdateStore(Store stores)
        {
            var jsonPath = Path.Combine(path, "StoreDetails.json");

            var json = File.ReadAllText(jsonPath);

            List<Store> list = JsonConvert.DeserializeObject<List<Store>>(json);

            Store found = list.Where(x => x.StoreId == stores.StoreId).Single();
            found.StoreName = "Netto";
            var updatedJson = JsonConvert.SerializeObject(list);
            File.WriteAllText(jsonPath, updatedJson);
        }


        public IEnumerable<Store> GetAllStores()
        {
            {
                var jsonPath = Path.Combine(path, "StoreDetails.json");
                var storeDetails = Utility.LoadFromJson<Store>(jsonPath);

                return storeDetails;
            }

        }

        public Store GetByStoreId(long StoreId)
        {
            IEnumerable<Store> storeList = GetAllStores();
            Store store = storeList.Where(x => x.StoreId == StoreId).FirstOrDefault();
            if (store != null)
            {
                Console.WriteLine("\n");
                Console.WriteLine("******Matched record by StoreId*****");
                foreach (var item in store.ProductDetails)
                {
                    Console.WriteLine("StoreID:" + store.StoreId + "," + "StoreName:" + store.StoreName + "," + "ProductName:" + item.Name + "," + "Price:" + item.Price + "," + "ProductInStock:" + item.ProductInStock + "," + "ProductId:" + item.ProductId + "," + "ManufacturerName:" + item.ManufacturerDetails.ManufacturerName + "," + "PhoneNumber:" + item.ManufacturerDetails.PhoneNumber + "," + "Place:" + item.ManufacturerDetails.Place);
                }

            }
            else
                Console.WriteLine("No matched records found for the storeID:{0}", StoreId);

            return store;
        }


        public IEnumerable<Store> GetStoresBySearch(string searchString)
        {
            IEnumerable<Store> storeList = GetAllStores();
            IEnumerable<Store> query = from rec in storeList
                                       where rec.StoreName.Contains(searchString)
                                       select rec;


            return query;
        }

        public void AddProductInStore(Product product, long storeId)
        {
            var jsonPath = Path.Combine(path, "StoreDetails.json");

            var json = File.ReadAllText(jsonPath);


            List<Store> list = JsonConvert.DeserializeObject<List<Store>>(json);
            Store found1 = list.Where(x => x.StoreId == storeId).Single();
            found1.ProductDetails.Add(product);
            var updatedJson = JsonConvert.SerializeObject(list);
            File.WriteAllText(jsonPath, updatedJson);
        }

        public void RemoveProductInStore(Product product, long storeId)
        {
            var jsonPath = Path.Combine(path, "StoreDetails.json");

            var json = File.ReadAllText(jsonPath);

            
            List<Store> storeList = JsonConvert.DeserializeObject<List<Store>>(json);

            storeList.ForEach(c => c.ProductDetails.RemoveAll(s => s.ProductId == product.ProductId));

            var updatedJson = JsonConvert.SerializeObject(storeList);
            File.WriteAllText(jsonPath, updatedJson);
        }


        public void ProductInStock(Product product)
        {
            var jsonPath = Path.Combine(path, "StoreDetails.json");

            var json = File.ReadAllText(jsonPath);

            //Product product8 = new Product();
            List<Store> storeList = JsonConvert.DeserializeObject<List<Store>>(json);
            //var storeLst = storeList.AsQueryable();
            List<Store> result = new List<Store>();
            foreach (var storeItem in storeList)
            {
                if(storeItem.ProductDetails.Where(p=>p.ProductId== product.ProductId && p.ProductInStock >0).Any())
                {
                    
                    Product productInStock = storeItem.ProductDetails.Where(p => p.ProductId == product.ProductId && p.ProductInStock > 0).FirstOrDefault();
                     Console.WriteLine("Store ID :"+storeItem.StoreId + " Store Name :" + storeItem.StoreName + " Product Name :"+ productInStock.Name + " Product Price:" +productInStock.Price + " Product Id:"+ productInStock.ProductId + " Product InStock :" +productInStock.ProductInStock + " Manufacturer Name :" +productInStock.ManufacturerDetails.ManufacturerName);
                                        

                }
                
            }
        }
    }
}

