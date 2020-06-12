using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ProductApplication.Models;

namespace ProductApplication.Repositories
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetByProductId(long productId);
        IEnumerable<Product> GetProductsBySearch(string searchString);
        IEnumerable<Product> GetProductsLessThanStatedPrice(decimal price);

        void SaveProduct(List<Product> products);

        bool UpdateProduct(Product product);

        string RemoveProduct(Product product);


    }
}
