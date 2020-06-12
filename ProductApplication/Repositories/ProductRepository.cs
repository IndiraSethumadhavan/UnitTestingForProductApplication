using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design;
using System.Text.Json;
using CsvHelper.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductApplication.Models;
using ProductApplication.Utilities;


namespace ProductApplication.Repositories
{

    public class ProductRepository : IProductRepository
    {
      
        public void SaveProduct(List<Product> product)
        {

            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var jsonPath = Path.Combine(path, "ProductsDetails.json");
            Utility.SaveToJson<Product>(jsonPath, product);

        }

        public IEnumerable<Product> GetAllProducts()
        {
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var jsonPath = Path.Combine(path, "ProductsDetails.json");
                var productDetails = Utility.LoadFromJson<Product>(jsonPath);
              
                return productDetails;



            }

        }

        public Product GetByProductId(long productId)
        {
            IEnumerable<Product> productList = GetAllProducts();
            Product product = productList.Where(x => x.ProductId == productId).FirstOrDefault();
            return product;



        }

        

        public IEnumerable<Product> GetProductsBySearch(string searchString)
        {
            IEnumerable<Product> productList = GetAllProducts();
            IEnumerable<Product> query = from rec in productList
                                         where rec.Name.Contains(searchString)
                                         select rec;


            return query;


        }

        public IEnumerable<Product> GetProductsLessThanStatedPrice(decimal price)
        {
            IEnumerable<Product> productList = GetAllProducts();

            IEnumerable<Product> query2 = productList.Where(c => c.Price < price)
                                          .Take(10);


            return query2;


        }

        public bool UpdateProduct(Product product)
        {

            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var jsonPath = Path.Combine(path, "ProductsDetails.json");
            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);

                List<Product> list = JsonConvert.DeserializeObject<List<Product>>(json);


                if (list.Where(x => x.ProductId == product.ProductId).Any())
                {
                    Product found = list.Where(x => x.ProductId == product.ProductId).Single();
                    found.Name = "IodisedSalt";
                    found.Price = 100.01m;
                    var updatedJson = JsonConvert.SerializeObject(list);
                    File.WriteAllText(jsonPath, updatedJson);
                    Console.WriteLine("Product is updated successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("ProductId is not found");
                    return false;
                }
            }
            else
            {
                throw new FileNotFoundException($"The file : {jsonPath}. doesn't exist");
            }

           
            
            
        }

        public void RemoveProduct(Product product)
        {


            IEnumerable<Product> productList = GetAllProducts();
           var productListAfterRemoval = productList.Where(c => c.ProductId != product.ProductId).ToList();
            SaveProduct(productListAfterRemoval);


        }
       
    }
    }






        

    

    

