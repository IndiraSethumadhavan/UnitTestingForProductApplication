using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using ProductApplication;
using ProductApplication.Controller;
using ProductApplication.Models;
using ProductApplication.Repositories;
using Xunit;




namespace ProductApplicationTestProject
{
    public class UnitTest1
    {
        ProductRepository repository;
        Mock<IProductRepository> repositoryMock;
        Mock<Product> productMock;
        private object result;

        [Fact]
        public void SetUp()
        {
            repositoryMock = new Mock<IProductRepository>();
            repository = new ProductRepository();
            productMock = new Mock<Product>();

        }



        [Fact]
        public void ShouldNotSaveInvalidProduct()
        {

            var records = new List<Product>
            {
             new Product() { Name = "SoyaBeans", Price = 92.89m, ProductId = 324, ProductInStock = 10, ManufacturerDetails = new Manufacturer() { ManufacturerName = "III", Place = "Hjlmar", PhoneNumber = 761234567 } },
             new Product() { Name = "Chocolate", Price = 34.85m, ProductId = 453, ProductInStock = 5, ManufacturerDetails = new Manufacturer() { ManufacturerName = "AAA", Place = "Redbergsplatsen", PhoneNumber = 762345678 } }

            };


            productMock.SetupGet(p => p.IsValid).Returns(false);
             bool result=repository.SaveProduct(productMock.Object);


            Assert.False(result);
            ///repositoryMock.Verify(r => r.SaveProduct(It.IsAny<Product>()), Times.Never());



        }


    }

    }

