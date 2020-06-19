using System;
using System.Collections.Generic;
using System.Text;
using ProductApplication.Models;
using ProductApplication.MongoDb_Models;
using ProductApplication.Repositories;

namespace ProductApplication.Controller
{
   public class MongoDbProductManagement
    {

        public void MongoDbProdManagment()
        {
            InsertProduct();
            Console.WriteLine("********MongoDB implementation"********);
           RemoveProduct(new MongoProduct { Name = "Pepsodent Tootpaste", ProductId = "6eea1bf08ad05d339877def5", Price = 50.37m, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "ERE", PhoneNumber = 762892333, Place = "Redbergplasten" } });
            UpdateProduct(new MongoProduct { Name = "Toothbrush", ProductId = "5eecbb1daf356825443869e6", Price = 50.78m, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", PhoneNumber = 762892530, Place = "Hjlmar" } });
            GetAllProducts();
            GetByProductId("5eecbb1daf356825443869d8");
        }


        private void InsertProduct()
        {
            IMongoDbProductRepository mongoRep = new MongoDbProductRepository();
            mongoRep.InsertProduct(new MongoProduct { Name = "Milk", ProductId = "5eecbb1daf356825443869d3", Price = 50.06m, ProductInStock = 5, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", PhoneNumber = 762892451, Place = "Redbergplasten" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "SoyaMilk", ProductId = "5eecbb1daf356825443869d6", Price = 75.45m, ProductInStock = 6, ManufacturerDetails = new Manufacturer() { ManufacturerName = "VVV", PhoneNumber = 762892400, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "CondensedMilk", ProductId = "5eecbb1daf356825443869d9", Price = 89.45m, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "PPP", PhoneNumber = 762892410, Place = "korsvagen" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "CastorOil", ProductId = "5eecbb1daf356825443869d5", Price = 100.33m, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "PVI", PhoneNumber = 762892412, Place = "Qvidingsgatan" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "SunflowerOil", ProductId = "5eecbb1daf356825443869d8", Price = 120.34m, ProductInStock = 15, ManufacturerDetails = new Manufacturer() { ManufacturerName = "PPP", PhoneNumber = 762892433, Place = "Nordstan" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "SesameOil", ProductId = "5eecbb1daf356825443869db", Price = 112.22m, ProductInStock = 3, ManufacturerDetails = new Manufacturer() { ManufacturerName = "OPV", PhoneNumber = 762892423, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "ColgateTootpaste", ProductId = "5eecbb1daf356825443869d7", Price = 122.34m, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "FFF", PhoneNumber = 762892422, Place = "Chalmers" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "sensodyneToothPaste", ProductId = "5eecbb1daf356825443869da", Price = 157.23m, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "KHI", PhoneNumber = 762892454, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Vaseline", ProductId = "5eecbb1daf356825443869dc", Price = 145.45m, ProductInStock = 7, ManufacturerDetails = new Manufacturer() { ManufacturerName = "RTR", PhoneNumber = 762892433, Place = "korsvagen" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Nivea", ProductId = "5eecbb1daf356825443869dd", Price = 130.33m, ProductInStock = 8, ManufacturerDetails = new Manufacturer() { ManufacturerName = "YUI", PhoneNumber = 762892421, Place = "Chalmers" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Cethaphil", ProductId = "5eecbb1daf356825443869de", Price = 200.43m, ProductInStock = 9, ManufacturerDetails = new Manufacturer() { ManufacturerName = "HTY", PhoneNumber = 762892455, Place = "Qvidingsgatan" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Muesli", ProductId = "5eecbb1daf356825443869df", Price = 222.55m, ProductInStock = 6, ManufacturerDetails = new Manufacturer() { ManufacturerName = "FRT", PhoneNumber = 762892421, Place = "Redbergplasten" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Pillows", ProductId = "5eecbb1daf356825443869e0", Price = 170.56m, ProductInStock = 5, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SDA", PhoneNumber = 762892411, Place = "Chalmers" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Curd", ProductId = "5eecbb1daf356825443869e1", Price = 90.33m, ProductInStock = 7, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SER", PhoneNumber = 762892413, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Chicken", ProductId = "5eecbb1daf356825443869e2", Price = 190.22m, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "DFS", PhoneNumber = 762892477, Place = "korsvagen" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "AllPurposeFlour", ProductId = "5eecbb1daf356825443869e3", Price = 279.06m, ProductInStock = 8, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SES", PhoneNumber = 762892454, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Sugar", ProductId = "5eecbb1daf356825443869e4", Price = 127.89m, ProductInStock = 15, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SSS", PhoneNumber = 762892410, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Toys", ProductId = "5eecbb1daf356825443869e5", Price = 89.09m, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SWE", PhoneNumber = 762892499, Place = "Qvidingsgatan" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Toothbrush", ProductId = "5eecbb1daf356825443869e6", Price = 190.78m, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SWR", PhoneNumber = 762892534, Place = "Redbergplasten" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Salt", ProductId = "5eecbb1daf356825443869e7", Price = 34.57m, ProductInStock = 8, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SSS", PhoneNumber = 762892347, Place = "Chalmers" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Muffins", ProductId = "5eecbb1daf356825443869e8", Price = 50.37m, ProductInStock = 16, ManufacturerDetails = new Manufacturer() { ManufacturerName = "AWE", PhoneNumber = 762892856, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Pepsodent Tootpaste", ProductId = "5eecbb1daf356825443869d4", Price = 50.37m, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "ERE", PhoneNumber = 762892333, Place = "Redbergplasten" } });

        }

        public string RemoveProduct(MongoProduct product)
        {
            IMongoDbProductRepository mongoRep = new MongoDbProductRepository();
            string res = mongoRep.RemoveProduct(product);
            Console.WriteLine(res);
            Console.WriteLine();
            return res;
        }


        public string  UpdateProduct(MongoProduct product)
        {
            IMongoDbProductRepository mongoRep = new MongoDbProductRepository();
            string res = mongoRep.UpdateProduct(product);
            Console.WriteLine(res);
            Console.WriteLine();
            return res;
        }

        public void GetAllProducts()
        {
            
        //productRepository = new ProductRepository();
          IMongoDbProductRepository mongoRep = new MongoDbProductRepository();
            IEnumerable<MongoProduct> productList = mongoRep.GetAllProducts();
            
                Console.WriteLine("********Products details************");
                foreach (var products in productList)
                {
               
                 Console.WriteLine($"Name : {products.Name} , ProductId:{products.ProductId} ,Price: {products.Price}, ManufacturerDetails : {products.ManufacturerDetails.ManufacturerName} ,ManufacturerDetails : {products.ManufacturerDetails.Place}, ManufacturerDetails : {products.ManufacturerDetails.PhoneNumber}");

                }
                
        }

        public void GetByProductId(string productId)
        {
            IMongoDbProductRepository mongoRep = new MongoDbProductRepository();
            MongoProduct prodts = mongoRep.GetByProductId(productId);
            if (prodts != null)
            {
                Console.WriteLine();
                Console.WriteLine("******Matched record by ProductId*****" + "\n"
                    + "Name:" + prodts.Name + "," + "Price:" + prodts.Price + "," + "ProductID:" + prodts.ProductId + "," + "ManufacturerName:" + prodts.ManufacturerDetails.ManufacturerName + "," + "Place:" + prodts.ManufacturerDetails.Place + "," + "PhoneNumber:" + prodts.ManufacturerDetails.PhoneNumber);
            }
            else
                Console.WriteLine("No matched records found for the productID:{0}", prodts.ProductId);
        }



    }


}
