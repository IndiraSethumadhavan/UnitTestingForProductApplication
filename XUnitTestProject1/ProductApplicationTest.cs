using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using Moq;
using ProductApplication;
using ProductApplication.Controller;
using ProductApplication.Models;
using ProductApplication.Repositories;
using Xunit;




namespace ProductApplicationTestProject
{
    public class ProductApplicationTest
    {

        // Product
        // create Product-2 testcases-Indira
        //read Product-3 testcases-Tatjana
        //update Product-3 testcase-Abde
        //delete Product -4 testcase-Indira
        
        //Create Product
        [Fact]
        public void CreateProductSuccessValidation()
        {
                      
          ProductManagement productManagement = new ProductManagement();
            List<Product> products = BindProducts();
            productManagement.CreateProduct(products);
            ProductRepository productRepository = new ProductRepository();
          var result1 =  productRepository.GetAllProducts();
          Assert.True(result1.Count() == 22,"No of Product count is not matched");
        }


        [Fact]
       
        public void CreateProductException()
        {
            ProductManagement productManagement = new ProductManagement();
            List<Product> products = new List<Product>();
            var exception = Assert.Throws<System.Exception>(() => productManagement.CreateProduct(products));
            Assert.Equal("Product details not available", exception.Message);

        }

        [Fact]
        public void DeleteProductSuccessValidation()
        {
            ProductManagement productManagement = new ProductManagement();
            List<Product> products = BindProducts();
             productManagement.CreateProduct(products);
            Product product2 = new Product() { Name = "SesameOil", Price = 89.50m, ProductId = 809, ProductInStock = 0, ManufacturerDetails = new Manufacturer() { ManufacturerName = "FRE", Place = "Nordstan", PhoneNumber = 764536267 } };

            string result1 = productManagement.RemoveProduct(product2);
            
            Assert.Equal("Product item is removed successfully",result1 );
                       
        }

        [Fact]
        public void DeleteProductFailureValidation()
        {
            ProductManagement productManagement = new ProductManagement();
            List<Product> products = BindProducts();
            productManagement.CreateProduct(products);
            Product product2 = new Product() { Name = "Milk", Price = 42.89m, ProductId = 2000, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "TRT", Place = "Hjlmar", PhoneNumber = 764075849 } };
            string result2 = productManagement.RemoveProduct(product2);
            Assert.Equal("Product id not exist", result2);
            
        }

        [Fact]
        public void DeleteProductException()
        {

            ProductManagement productManagement = new ProductManagement();
            List<Product> products = BindProducts();
            productManagement.CreateProduct(products);
            Product product2 = new Product() { Name = "SesameOil", Price = 89.50m, ProductId = -1, ProductInStock = 0, ManufacturerDetails = new Manufacturer() { ManufacturerName = "FRE", Place = "Nordstan", PhoneNumber = 764536267 } };
            var throwException =Assert.Throws<System.Exception>(() => productManagement.RemoveProduct(product2));
            Assert.Equal("ProductID should be a positive number", throwException.Message);
        }

        [Fact]
        public void DeleteProductFailureValidationWithoutPassingtheProductId()
        {
            ProductManagement productManagement = new ProductManagement();
            List<Product> products = BindProducts();
            productManagement.CreateProduct(products);
            Product product2 = new Product() { Name = "SesameOil", Price = 89.50m, ProductInStock = 0, ManufacturerDetails = new Manufacturer() { ManufacturerName = "FRE", Place = "Nordstan", PhoneNumber = 764536267 } };
            string result3 = productManagement.RemoveProduct(product2);
            Assert.Equal("Please provide the valid ProductId", result3);
        }
        
        //
        [Fact]
        public void UpdateProductFail()
        {
            var productRepository = new ProductManagement();
            var updated = productRepository.UpdateProduct();
            Assert.False(updated);
        }

        //
        [Fact]
        public void UpdateProductSucces()
        {
            var productRepository = new ProductManagement();
            var updated = productRepository.UpdateProduct();
            Assert.True(updated);
        }
        //
        [Fact]
        public void UpdateProductException()
        {
            var productManagement = new ProductManagement();
            Assert.ThrowsAny<FileNotFoundException>(() => productManagement.UpdateProduct());
        }
        
        private List<Product> BindProducts()
        {
            List<Product> records = new List<Product>
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
            return records;
        }
        
        //Succesful test
        [Fact]
        public void ReadProductsSucces()
        {
            var productManagement = new ProductManagement();
            var productsReaded = productManagement.GetAllProducts();
            Assert.True(productsReaded);
        }
        //Failing Test
        [Fact]
        public void ReadProdúctsFail()
        {
            var productManagement = new ProductManagement();
            var productsReaded = productManagement.GetAllProducts();
            Assert.False(productsReaded);
        }
        //Read Product throws an exception fail
        [Fact]
        public void ReadProdúctsException()
        {
            var productManagement = new ProductManagement();
            Assert.Throws<NullReferenceException>(() => productManagement.GetAllProducts());
        }

    }

}

