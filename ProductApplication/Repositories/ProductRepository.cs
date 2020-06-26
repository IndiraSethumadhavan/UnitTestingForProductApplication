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


        public string UpdateProduct(Product product)
        {

            string result = string.Empty;
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
                    //Console.WriteLine("Product is updated successfully");
                    result = "Product Name and Price are updated successfully";
                }
                else if (product.ProductId < 0)
                {
                    throw new Exception("ProductID should be a positive number");
                }
                else if (product.ProductId == 0)
                {
                    result = "Please provide the valid ProductId";
                }
                else
                {
                    result = "Product id not exist";
                }

            }

            return result;

        }

        public string RemoveProduct(Product product)
        {

            string result = string.Empty;
            IEnumerable<Product> productList = GetAllProducts();
            if(productList.Where(c => c.ProductId == product.ProductId).Any())
            {
                var productListAfterRemoval = productList.Where(c => c.ProductId != product.ProductId).ToList();
                SaveProduct(productListAfterRemoval);
                result = "Product item is removed successfully";
            }

            else if(product.ProductId < 0)
            {
                throw new Exception ("ProductID should be a positive number");
            }
            else if(product.ProductId == 0)
            {
                return "Please provide the valid ProductId";
            }
            else
            {
               result= "Product id not exist";
            }
            return result;

        }
       
    }
    }






        

    

    

