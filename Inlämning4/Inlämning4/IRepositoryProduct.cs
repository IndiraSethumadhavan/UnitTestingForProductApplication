using System;
using System.Collections.Generic;

namespace Inlämning4
{
    interface IRepositoryProduct : IDisposable
    {
        public List<Product> GetProducts();

        public void CreateProduct(string name, double price, int ID, Manufacturer manufacturer);
        public void DeleteProduct(int product);
        public Product GetProduct(int productId);
        public void UpdateProduct(int ProductToChange, string name, string manufacturer, int Newid, double Newprice);
        public void StockOfProducts();
        public void FindAproduct(JaroWinklerDistance stringDistance, string productName);
    }
}
