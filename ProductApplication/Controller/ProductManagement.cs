using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using ProductApplication.Models;
using ProductApplication;
using System.Windows.Markup;
using System.Text.Json;
using ProductApplication.Repositories;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;



namespace ProductApplication.Controller
{
    public class ProductManagement
    {
        ProductRepository productRepository;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        /// <summary>
        /// Product management
        /// </summary>
        public void ProdManagment()
        {
            try
            {
                CreateProduct();

                GetAllProducts();

                GetByProductId(307);

                GetProductsBySearch("Col");

                GetProductsLessThanStatedPrice(100.01m);

                UpdateProduct();

                RemoveProduct();

                GetAllManufacturerDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Remove Product
        /// </summary>
        private void RemoveProduct()
        {
            productRepository = new ProductRepository();
            Product product2 = new Product() { Name = "Milk", Price = 42.89m, ProductId = 101, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "TRT", Place = "Hjlmar", PhoneNumber = 764075849 } };
            productRepository.RemoveProduct(product2);
            
            Console.WriteLine("Product item is removed successfully");
            Console.WriteLine();
        }

        /// <summary>
        /// Update Product
        /// </summary>
        private void UpdateProduct()
        {
            productRepository = new ProductRepository();
            Product product1 = new Product() { Name = "Salt", Price = 199.95m, ProductId = 654, ProductInStock = 11, ManufacturerDetails = new Manufacturer() { ManufacturerName = "EEE", Place = "Hjlmar", PhoneNumber = 764586231 } };
            productRepository.UpdateProduct(product1);
            Console.WriteLine("Product Name and Price are updated successfully");
            Console.WriteLine();
        }

        /// <summary>
        /// ReadProduct Products that cost less than the stated price, show a maximum of 10 products
        /// </summary>
        /// <param name="price"></param>
        private void GetProductsLessThanStatedPrice(decimal price)
        {
            productRepository = new ProductRepository();
            var obj2 = productRepository.GetProductsLessThanStatedPrice(price);
            Console.WriteLine("\n");
            Console.WriteLine("*************Matched 10 records by ProductPrice**********");
            foreach (Product record in obj2)
            {
                Console.WriteLine($"Name : {record.Name},  Price: {record.Price},  ProductId:{record.ProductId} , ManufacturerName : {record.ManufacturerDetails.ManufacturerName},  Place : {record.ManufacturerDetails.Place},  PhoneNumber : {record.ManufacturerDetails.PhoneNumber}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// ReadProduct by part of the product name.
        /// </summary>
        /// <param name="searchString"></param>
        private void GetProductsBySearch(string searchString)
        {
            productRepository = new ProductRepository();
            var obj1 = productRepository.GetProductsBySearch(searchString);
            foreach (Product record in obj1)
            {
                Console.WriteLine();
                Console.WriteLine("******Matched record by ProductName*******");
                Console.WriteLine($"Name : {record.Name} , Price: {record.Price} , ProductId:{record.ProductId} , ManufacturerName : {record.ManufacturerDetails.ManufacturerName},  Place : {record.ManufacturerDetails.Place},  PhoneNumber : {record.ManufacturerDetails.PhoneNumber}");
                
            }
           
        }

        /// <summary>
        /// ReadProduct by productID
        /// </summary>
        /// <param name="v"></param>
        private void GetByProductId(int productId)
        {
            productRepository = new ProductRepository();
            Product prodts = productRepository.GetByProductId(productId);
            if (prodts != null)
            {
                Console.WriteLine();
                Console.WriteLine("******Matched record by ProductId*****" + "\n"
                    + "Name:" + prodts.Name + "," + "Price:" + prodts.Price + "," + "ProductID:" + prodts.ProductId + "," + "ManufacturerName:" + prodts.ManufacturerDetails.ManufacturerName + "," + "Place:" + prodts.ManufacturerDetails.Place + "," + "PhoneNumber:" + prodts.ManufacturerDetails.PhoneNumber);
            }
            else
                Console.WriteLine("No matched records found for the productID:{0}", prodts.ProductId);
        }

        /// <summary>
        /// To get all the product details
        /// </summary>
        private void GetAllProducts()
        {
            productRepository = new ProductRepository();
            IEnumerable<Product> productDetails = productRepository.GetAllProducts();
            Console.WriteLine("********Products details************");
            foreach (var products in productDetails)
            {
                Console.WriteLine($"Name : {products.Name} , Price: {products.Price}, ProductId:{products.ProductId} , ManufacturerDetails : {products.ManufacturerDetails.ManufacturerName} ,ManufacturerDetails : {products.ManufacturerDetails.Place}, ManufacturerDetails : {products.ManufacturerDetails.PhoneNumber}");
            }
        }


        /// <summary>
        /// Create Product
        /// </summary>
        public void CreateProduct()
        {
            string jsonPath = Path.Combine(path, "ProductsDetails.json");
            if (File.Exists(jsonPath))
            {
                File.Delete(jsonPath);
            }

            var records = new List<Product>
            {
            new Product() { Name = "Milk", Price = 42.89m, ProductId = 101,ProductInStock=10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "TRT", Place = "Hjlmar", PhoneNumber = 764175849 } },
            new Product() { Name = "Pepsodent Tootpaste", Price = 60.86m,ProductInStock=15, ProductId = 204, ManufacturerDetails = new Manufacturer() { ManufacturerName = "AAA", Place = "korsvagen", PhoneNumber = 764536231 } },
            new Product() { Name = "CastorOil", Price = 50.01m, ProductId = 307,ProductInStock=8, ManufacturerDetails = new Manufacturer() { ManufacturerName = "TRT", Place = "Hjlmar", PhoneNumber = 764975849 } },
            new Product() { Name = "SoyaMilk", Price = 34.83m, ProductId = 402,ProductInStock=10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "TRT", Place = "Nordstan", PhoneNumber = 764175849 } },
            new Product() { Name = "ColgateTootpaste", Price = 55.45m, ProductId = 505,ProductInStock=4, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", Place = "Hjlmar", PhoneNumber = 764536238 } },
            new Product() { Name = "SunflowerOil", Price = 54.65m, ProductId = 608,ProductInStock=5, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SSS", Place = "korsvagen", PhoneNumber = 764636231 } },
            new Product() { Name = "CondensedMilk", Price = 22.34m, ProductId = 603,ProductInStock=0, ManufacturerDetails = new Manufacturer() { ManufacturerName = "VVV", Place = "Qvidingsgatan", PhoneNumber = 764875849 } },
            new Product() { Name = "sensodyneToothPaste", Price = 80.01m, ProductId = 706,ProductInStock=4, ManufacturerDetails = new Manufacturer() { ManufacturerName = "AAA", Place = "Redbergplatsen", PhoneNumber = 764536237 } },
            new Product() { Name = "SesameOil", Price = 89.50m, ProductId = 809,ProductInStock=0, ManufacturerDetails = new Manufacturer() { ManufacturerName = "FRE", Place = "Nordstan", PhoneNumber = 764536267 } },
            new Product() { Name = "Vaseline", Price = 178.45m, ProductId = 509,ProductInStock=7, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", Place = "Qvidingsgatan", PhoneNumber = 764536221 } },
            new Product() { Name = "Nivea", Price = 77.12m, ProductId = 109,ProductInStock=0, ManufacturerDetails = new Manufacturer() { ManufacturerName = "RTE", Place = "CentralStation", PhoneNumber = 764536771 } },
            new Product() { Name = "Cethaphil", Price = 170.22m, ProductId = 609,ProductInStock=12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "TRT", Place = "Qvidingsgatan", PhoneNumber = 764536831 } },
            new Product() { Name = "Muesli", Price = 154.32m, ProductId = 779,ProductInStock=0, ManufacturerDetails = new Manufacturer() { ManufacturerName = "RTE", Place = "Chalmers", PhoneNumber = 764536631 } },
            new Product() { Name = "Pillows", Price = 132.54m, ProductId = 899,ProductInStock=15, ManufacturerDetails = new Manufacturer() { ManufacturerName = "EEE", Place = "Qvidingsgatan", PhoneNumber = 764535231 } },
            new Product() { Name = "Curd", Price = 60.43m, ProductId = 877,ProductInStock=0, ManufacturerDetails = new Manufacturer() { ManufacturerName = "TRY", Place = "Chalmers", PhoneNumber = 764555231 } },
            new Product() { Name = "Chicken", Price = 56.12m, ProductId = 800,ProductInStock=18, ManufacturerDetails = new Manufacturer() { ManufacturerName = "EEE", Place = "korsvagen", PhoneNumber = 764530031 } },
            new Product() { Name = "AllPurposeFlour", Price = 199.32m, ProductId = 678,ProductInStock=0, ManufacturerDetails = new Manufacturer() { ManufacturerName = "VVV", Place = "Qvidingsgatan", PhoneNumber = 764511231 } },
            new Product() { Name = "Sugar", Price = 134.11m, ProductId = 777,ProductInStock=20, ManufacturerDetails = new Manufacturer() { ManufacturerName = "GFT", Place = "Chalmers", PhoneNumber = 764586231 } },
            new Product() { Name = "Toys", Price = 170.23m, ProductId = 833,ProductInStock=0, ManufacturerDetails = new Manufacturer() { ManufacturerName = "TRP", Place = "Qvidingsgatan", PhoneNumber = 764534231 } },
            new Product() { Name = "Toothbrush", Price = 186.89m, ProductId = 853,ProductInStock=13, ManufacturerDetails = new Manufacturer() { ManufacturerName = "IUY", Place = "Nordstan", PhoneNumber = 764596231 } },
            new Product() { Name = "Salt", Price = 199.95m, ProductId = 654,ProductInStock=11, ManufacturerDetails = new Manufacturer() { ManufacturerName = "EEE", Place = "Hjlmar", PhoneNumber = 764586231 } },
            new Product() { Name = "Muffins", Price = 78.95m, ProductId = 760,ProductInStock=10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SEE", Place = "Qvidingsgatan", PhoneNumber = 764500000 } }
        };
            IProductRepository productRepository = new ProductRepository();
            productRepository.SaveProduct(records);
            Console.WriteLine("*******Products created successfully********");
            Console.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetAllManufacturerDetails()

        {
            productRepository = new ProductRepository();
            var manufacturerList = productRepository.GetAllProducts();
            var groupedManufacturerRecords =
                                              manufacturerList.GroupBy(c => c.ManufacturerDetails.ManufacturerName);
                                                       

            Console.WriteLine("****List of Manufacturer details*****");
           
            foreach (var groups in groupedManufacturerRecords )
            {
                Console.WriteLine("ManufacturerName:"+groups.Key + "\n" + "Total no of products:" + groups.Count()) ;
                foreach (var c in groups)
                {
                    Console.WriteLine("\t"  + "ProductName:"+c.Name + "," + "Price:" + c.Price);
                    
                }
                Console.WriteLine();
            }
        }
        
    }

}



