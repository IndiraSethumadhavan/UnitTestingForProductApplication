using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Inlämning4
{
    public class FileRepositoryStore : IRepositorySore
    {
        //PROPERTIES
        public HashSet<Store> StoresList = new HashSet<Store>();
        // DEFAULT CONSTRUCTOR
        public FileRepositoryStore()
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var programPath = Path.Combine(path, "Inlämning4");
                if (Directory.Exists(programPath))
                {
                    var jsonPath = Path.Combine(programPath, "Stores.json");
                    if (File.Exists(jsonPath))
                    {
                        var records = LoadFromJson<Store>(jsonPath);
                        StoresList = records.ToHashSet();
                    }
                }
            }
            catch (Exception msg)
            {

                msg.Message.Dump();
            }
        }

        //GET STORES 
        public IEnumerable<Store> GetStores()
        {
            return StoresList;
        }

        //PRINT STORES INFORMATION 
        public void PrintStoresInformation()
        {
            foreach (var store in StoresList)
            {
                store.Dump("\n\n");
            }
        }

        //PRINT STORES INFORMATION AND PRODUCTS
        public void PrintStoresInformationAndProducts()
        {
            foreach (var store in StoresList)
            {
                store.Dump("\n\n");

                foreach (var product in store.Products)
                {
                    product.Dump("\n");
                }
                System.Threading.Thread.Sleep(1000);
            }
        }

        //CREATE A STORE
        public void CreateStore(string name, int ID)
        {
            var store = new Store(name, ID);
            StoresList.Add(store);
            Console.WriteLine($"{store.Name} has been cretaed and added to the list");
        }

        //DELETE A STORE
        public void DeleteStore(int ID)
        {
            var stores = StoresList.Where(s => s.StoreId == ID);
            if (stores != null)
            {
                foreach (var store in stores)
                {
                    StoresList.Remove(store);
                    $"{store.Name} removed".Dump();
                }
            }
            else
            {
                $"The store: {ID} not found ".Dump();
            }
        }
        //GET STORE IN LIST
        public Store GetStore(int storeId)
        {
            var Store = StoresList.FirstOrDefault(s => s.StoreId == storeId);
            if (Store != null)
            {
                $"The store: {Store.Name} was found".Dump();

                return Store;
            }
            else
            {
                $"The store whit the id: {storeId} Not found".Dump();
                return null;
            }

        }
        //UPDATE A STORE
        public void UpdateStore(int StoreToChange, string NewName, int Newid)
        {
            var store = StoresList.FirstOrDefault(s => s.StoreId == StoreToChange);
            if (store != null)
            {
                store.Name = NewName;
                store.StoreId = Newid;
                $"The store : {store.Name} was changed".Dump();
            }
            else
            {
                $"The store ID: {StoreToChange} Not found".Dump();
            }
        }
        //GET PRODUCTS OF A STORE
        public List<Product> GetProducts(Store store)
        {
            if (store.Products.Count() > 0)
            {
                return store.Products;
            }
            else
            {
                "The products List is empty".Dump();
                return null;
            }

        }
        //UPDATE A PRODUCT IN A STORE
        public void UpdateProductInStore(int storeId, int productId, int newPrice, int newId, string newName)
        {
            var Store = StoresList.FirstOrDefault(s => s.StoreId == storeId);
            if (Store != null)
            {
                var product = Store.Products.FirstOrDefault(p => p.ProductId == productId);

                if (product != null)
                {
                    product.Price = newPrice;
                    product.ProductId = newId;
                    product.Name = newName;
                    $"The {product.Name} was updated".Dump();
                }
                else
                {
                    $"The Store id : {productId} was not found".Dump();
                }
            }
            else
            {
                $"The product id : {storeId} was not found".Dump();
            }
        }

        //DELETE A PRODUCT FROM A STORE
        public void DeleteProductFromStore(int storeId, int productId)
        {
            var store = StoresList.FirstOrDefault(s => s.StoreId == storeId);
            if (store != null)
            {
                var product = store.Products.FirstOrDefault(p => p.ProductId == productId);

                if (product != null)
                {
                    store.Products.Remove(product);
                    "Product Removed".Dump();
                }
                else
                {
                    $"The {productId} not found".Dump();
                }

            }
            else
            {
                $"The {storeId} not found".Dump();
            }
        }
        //ADD A PRODUCT TO A STORE
        public void AddProductToAstore(int storeId, Product product)
        {
            var store = StoresList.FirstOrDefault(s => s.StoreId == storeId);
            store.Products.Add(product);

        }
        //SEARCH FOR A PRODUCT WHIT NAME OR PART OF IT  WHIT HELP OF JAROWINKLERDISTANCE CLASS
        public void SearchProduct(string strng)
        {
            foreach (var store in StoresList)
            {
                var stringDist = new JaroWinklerDistance();
                foreach (var product in store.Products)
                {
                    var distance = stringDist.GetDistance(product.Name, strng);
                    if (distance > 0.5)
                    {
                        product.Name.Dump();
                    }
                }
            }
        }
        //SEARCH PRODUCT PER PRICE
        public void SearchProductsPerPrice(double price)
        {
            var ProdList = new List<Product>();
            foreach (var store in StoresList)
            {
                foreach (var product in store.Products.Where(p => p.Price < price))
                {
                    ProdList.Add(product);
                }
            }
            //Grouping products by id so we don´t get repited products to show
            var products = ProdList.GroupBy(elem => elem.ProductId).Select(group => group.First()).Take(10);
            Console.WriteLine($"\tThe Following Products costs less than: {price}");
            foreach (var product in products)
            {
                product.Name.Dump();
            }
            System.Threading.Thread.Sleep(1000);
        }
        //SEARCH WICH STORE HAS A PRODUCT
        public void WichStoreHasTheProduct(JaroWinklerDistance stringDistance, string product)
        {
            var ProductFound = false;
            foreach (var store in StoresList)
            {
                ProductFound = false;
                Console.WriteLine($"\n\tThe Store: {store.Name} Have:\n");
                foreach (var Product in store.Products)
                {
                    var distance = stringDistance.GetDistance(Product.Name, product);
                    if (distance > 0.7)
                    {
                        ProductFound = true;
                        Console.WriteLine($"\n\t{Product.Name}\n");
                    }
                }
                if (!ProductFound)
                {
                    "\tNO MATCHES".Dump();
                }
            }


        }
        // SAVE TO JSON FILE
        public void Dispose()
        {
            //Save into a Json file
            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programPath = Path.Combine(path, "Inlämning4");
            var jsonPath = Path.Combine(programPath, "Stores.json");
            SaveTojson(jsonPath, StoresList);
        }
        //LOAD FROM JSON
        public static IEnumerable<Store> LoadFromJson<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);

            var records = JsonSerializer.Deserialize<List<Store>>(jsonString);
            return records.ToList();
        }

        //SAVE TO JSON
        public static void SaveTojson<T>(string filePath, IEnumerable<T> records)
        {
            var jsonString = JsonSerializer.SerializeToUtf8Bytes(records);
            File.WriteAllBytes(filePath, jsonString);
        }
    }
}
