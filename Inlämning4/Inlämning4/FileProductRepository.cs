using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Inlämning4
{
    public class FileProductRepository : IRepositoryProduct
    {
        //PROPERTIES
        public List<Product> ProductsList = new List<Product>();
        //CONSTRUCTOR
        public FileProductRepository()
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var programPath = Path.Combine(path, "Inlämning4");
                if (Directory.Exists(programPath))
                {
                    var jsonPath = Path.Combine(programPath, "Products.json");
                    if (File.Exists(jsonPath))
                    {
                        var records = LoadFromJson<Product>(jsonPath);
                        if (records != null)
                        {
                            ProductsList = records.ToList();
                        }
                    }

                }
            }
            catch (Exception msg)
            {
                msg.Message.Dump();
            }
        }
        //GET PRODUCTS
        public List<Product> GetProducts()
        {
            return ProductsList;
        }
        // PRINT PRODUCTS INFORMATION
        public void PrintProductsInformation()
        {
            foreach (var product in ProductsList)
            {
                product.Dump("\n\t");
            }
        }
        //CREATE A PRODUCT
        public void CreateProduct(string name, Double price, int ID, Manufacturer manufacturer)
        {
            var product = new Product(name, price, ID, manufacturer);
            ProductsList.Add(product);
            Console.WriteLine($"\n\t{product.Name} has been cretaed and added to the list\n\t".ToUpper());
            System.Threading.Thread.Sleep(1000);
        }
        //DELETE A PRODUCT
        public void DeleteProduct(int productId)
        {
            var product = ProductsList.Where(p => p.ProductId == productId);
            if (product != null)
            {
                foreach (var Product in product)
                {
                    ProductsList.Remove(Product);
                    Console.WriteLine($"{Product.Name} Was removed from the List");
                }
            }
            else
            {
                Console.WriteLine($"The id : {productId} not found");
            }
        }

        //GET A PRODUCT
        public  Product GetProduct(int productId)
        {
            var product = ProductsList.Find(p => p.ProductId == productId);
            if (product != null)
            {
                Console.WriteLine($"The Product: {product.Name} Found");
                return product;
            }
            else
            {
                Console.WriteLine($"The Following ID : {productId} was not Found");
                return null;
            }
        }
        //UPDATE PRODUCT
        public void UpdateProduct(int ProductToUpdate, string name, string manufacturer, int Newid, double Newprice)
        {
            var product = ProductsList.Where(p => p.ProductId == ProductToUpdate);
            if (product != null)
            {
                foreach (var Product in product)
                {
                    Product.Name = name;
                    Product.Manufacturer.Name = manufacturer;
                    Product.Price = Newprice;
                    Product.ProductId = Newid;
                    Console.WriteLine($"{Product.Name} was updated");
                }
            }
            else
            {
                Console.WriteLine($"{ProductToUpdate} Not Found");
            }
        }
        //SHOW ALL THE MANUFACTURERS AND THEIR PRODUCTS
        public void StockOfProducts()
        {
            var manufacurers = ProductsList.GroupBy(p => p.Manufacturer.Name);
            foreach (var manufacurer in manufacurers)
            {
                Console.WriteLine($"\n\t Manufacturer : {manufacurer.Key}");
                var products = manufacurer.GroupBy(p => p.Name);
                manufacurer.Count().Dump($"\t{manufacurer.Key} Has this amount of products:");
                foreach (var product in products)
                {
                    product.Key.Dump("\n\t"); product.Count().Dump("\t");
                }
            }
        }
        //SEARCH FOR A PRODUCT IN STOCK
        public void FindAproduct(JaroWinklerDistance stringDistance, string productName)
        {
            var ProductFound = false;
            foreach (var product in ProductsList)
            {
                var distance = stringDistance.GetDistance(product.Name, productName);
                if (distance > 0.6)
                {
                    ProductFound = true;
                    Console.WriteLine($"\n\t{product.Name}\n");
                }
            }
            if (!ProductFound)
            {
                "\n\tNO MATCHES\n".Dump();
            }
        }
        //SAVE TO JSON FILE DISPOSE
        public void Dispose()
        {
            //Save to json file
            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programPath = Path.Combine(path, "Inlämning4");
            var jsonPath = Path.Combine(programPath, "Products.json");
            SaveTojson(jsonPath, ProductsList);
        }

        //LOAD FROM JSON
        public static IEnumerable<Product> LoadFromJson<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);

            var records = JsonSerializer.Deserialize<List<Product>>(jsonString);
            return records.ToList();
        }
        //SAVE TO JSON FILE METHOD
        public static void SaveTojson<T>(string filePath, IEnumerable<T> records)
        {
            var jsonString = JsonSerializer.SerializeToUtf8Bytes(records);
            File.WriteAllBytes(filePath, jsonString);
        }
    }
}
