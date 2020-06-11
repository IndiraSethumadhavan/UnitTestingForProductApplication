using System;
using System.Collections.Generic;

namespace Inlämning4
{
    interface IRepositorySore : IDisposable
    {
        public IEnumerable<Store> GetStores();
        public void PrintStoresInformation();
        public void PrintStoresInformationAndProducts();
        public void CreateStore(string name, int ID);
        public void DeleteStore(int ID);
        public Store GetStore(int store);
        public void UpdateStore(int StoreToChange, string NewName, int Newid);
        public List<Product> GetProducts(Store store);
        public void UpdateProductInStore(int storeId, int productId, int newPrice, int newId, string newName);
        public void DeleteProductFromStore(int storeId, int productId);
        public void AddProductToAstore(int storeId, Product product);
        public void SearchProduct(string strng);
        public void SearchProductsPerPrice(double price);
        public void WichStoreHasTheProduct(JaroWinklerDistance jaroWinklerDistance, string product);
    }
}
