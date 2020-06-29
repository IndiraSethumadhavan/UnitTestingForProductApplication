using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductApplication.Models;
using ProductApplication.MongoDb_Models;
using ProductApplication.Repositories;
using ProductApplication.MongodbFilter;
using System.Runtime.CompilerServices;

namespace ProductApplication.Controller
{
   public class MongoDbProductManagement
    {


        public void MongoDbProdManagment()
        {
            try
            {
                InsertProduct();
                Console.WriteLine("********Product MongoDB implementation********");
                RemoveProduct(new MongoProduct { Name = "Pepsodent Tootpaste", Price = 50.37m, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "ERE", PhoneNumber = 762892333, Place = "Redbergplasten" } });
                UpdateProduct(new MongoProduct { Name = "Toothbrush", Price = 50.78m, Id = "5ef5c2a3ac609330f4f799bf", ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "TTT", PhoneNumber = 762892530, Place = "Hjalmar" } });
                GetAllProducts();
                GetByProductId("5ef5c2a2ac609330f4f799b1");
                //ProductFilter-Search by ProductName
                IMongoDbProductRepository productRep = new MongoDbProductRepository();
                IMongoStore storeRep = new MongoDbStoreRepository();
                ProductFilter productFilter = new ProductFilter(productRep, storeRep);
                var searchProduct = productFilter.SearchProductByName("Vaseline").FirstOrDefault();
                Console.WriteLine();
                Console.WriteLine("********Matched record by ProductName************");
                Console.WriteLine($"Name : {searchProduct.Name} , ProductId:{searchProduct.Id} ,Price: {searchProduct.Price},ProductInStock:{searchProduct.ProductInStock}, ManufacturerDetails : {searchProduct.ManufacturerDetails.ManufacturerName} ,ManufacturerDetails : {searchProduct.ManufacturerDetails.Place}, ManufacturerDetails : {searchProduct.ManufacturerDetails.PhoneNumber}");
                //ProductFilter-ProductsCostingLessThan
                Console.WriteLine("********Matched 10 records by ProductPrice ************");
                var matchedProduct = productFilter.ProductsCostingLessThan(130.12m);
                foreach (var records in matchedProduct)
                {
                    Console.WriteLine($"Name : {records.Name} , ProductId:{records.Id} ,Price: {records.Price},ProductInStock:{records.ProductInStock}, ManufacturerDetails : {records.ManufacturerDetails.ManufacturerName} ,ManufacturerDetails : {records.ManufacturerDetails.Place}, ManufacturerDetails : {records.ManufacturerDetails.PhoneNumber}");

                }
                //ProductFilter-Manufacturerdetails
                productFilter.ListOfManufacturersWithProductCount();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



            private void InsertProduct()
        {
            
            IMongoDbProductRepository mongoRep = new MongoDbProductRepository();

            //mongoRep.DropCollection();
            mongoRep.InsertProduct(new MongoProduct { Name = "Milk", Price = 50.06m, ProductInStock = 5, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", PhoneNumber = 762892451, Place = "Redbergplasten" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "SoyaMilk", Price = 75.45m, ProductInStock = 6, ManufacturerDetails = new Manufacturer() { ManufacturerName = "VVV", PhoneNumber = 762892400, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "CondensedMilk", Price = 89.45m, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "PPP", PhoneNumber = 762892410, Place = "korsvagen" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "CastorOil", Price = 100.33m, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", PhoneNumber = 762892412, Place = "Qvidingsgatan" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "SunflowerOil",  Price = 120.34m, ProductInStock = 15, ManufacturerDetails = new Manufacturer() { ManufacturerName = "PPP", PhoneNumber = 762892433, Place = "Nordstan" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "SesameOil",  Price = 112.22m, ProductInStock = 3, ManufacturerDetails = new Manufacturer() { ManufacturerName = "OPV", PhoneNumber = 762892423, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "ColgateTootpaste",Price = 122.34m, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "FFF", PhoneNumber = 762892422, Place = "Chalmers" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "sensodyneToothPaste",  Price = 157.23m, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "FFF", PhoneNumber = 762892454, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Vaseline",  Price = 145.45m, ProductInStock = 7, ManufacturerDetails = new Manufacturer() { ManufacturerName = "RTR", PhoneNumber = 762892433, Place = "korsvagen" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Nivea",Price = 130.33m, ProductInStock = 8, ManufacturerDetails = new Manufacturer() { ManufacturerName = "YUI", PhoneNumber = 762892421, Place = "Chalmers" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Cethaphil", Price = 200.43m, ProductInStock = 9, ManufacturerDetails = new Manufacturer() { ManufacturerName = "HTY", PhoneNumber = 762892455, Place = "Qvidingsgatan" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Muesli", Price = 222.55m, ProductInStock = 6, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", PhoneNumber = 762892421, Place = "Redbergplasten" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Pillows", Price = 170.56m, ProductInStock = 5, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SES", PhoneNumber = 762892411, Place = "Chalmers" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Curd", Price = 90.33m, ProductInStock = 7, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SES", PhoneNumber = 762892413, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Chicken", Price = 190.22m, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "VVV", PhoneNumber = 762892477, Place = "korsvagen" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "AllPurposeFlour", Price = 279.06m, ProductInStock = 8, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SWE", PhoneNumber = 762892454, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Sugar",  Price = 127.89m, ProductInStock = 15, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SSS", PhoneNumber = 762892410, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Toys", Price = 89.09m, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SSS", PhoneNumber = 762892499, Place = "Qvidingsgatan" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Toothbrush", Price = 190.78m, ProductInStock = 12, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SWR", PhoneNumber = 762892534, Place = "Redbergplasten" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Salt", Price = 34.57m, ProductInStock = 8, ManufacturerDetails = new Manufacturer() { ManufacturerName = "SSS", PhoneNumber = 762892347, Place = "Chalmers" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Muffins", Price = 50.37m, ProductInStock = 16, ManufacturerDetails = new Manufacturer() { ManufacturerName = "AWE", PhoneNumber = 762892856, Place = "Hjlmar" } });
            mongoRep.InsertProduct(new MongoProduct { Name = "Pepsodent Tootpaste", Price = 50.37m, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "ERE", PhoneNumber = 762892333, Place = "Redbergplasten" } });

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
            MongoProduct product = new MongoProduct();
        //productRepository = new ProductRepository();
          IMongoDbProductRepository mongoRep = new MongoDbProductRepository();
            IEnumerable<MongoProduct> productList = mongoRep.GetAllProducts();

            Console.WriteLine("********Products details************");
                foreach (var products in productList)
                {

                    Console.WriteLine($"Name : {products.Name} , ProductId:{products.Id} ,Price: {products.Price}, ManufacturerDetails : {products.ManufacturerDetails.ManufacturerName} ,ManufacturerDetails : {products.ManufacturerDetails.Place}, ManufacturerDetails : {products.ManufacturerDetails.PhoneNumber}");

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
                    + "Name:" + prodts.Name + "," + "Price:" + prodts.Price + "," + "ProductID:" + prodts.Id + "," + "ManufacturerName:" + prodts.ManufacturerDetails.ManufacturerName + "," + "Place:" + prodts.ManufacturerDetails.Place + "," + "PhoneNumber:" + prodts.ManufacturerDetails.PhoneNumber);
            }
            else
                Console.WriteLine("No matched records found for the productID:{0}:" + productId);
        }



    }


}
