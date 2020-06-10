using System;
using System.Collections.Generic;
using System.Text;
using ProductApplication.Models;

namespace ProductApplication.Repositories
{
    public interface IStoreRepository 
    {

        IEnumerable<Store> GetAllStores();

        Store GetByStoreId(long storeId);
        IEnumerable<Store> GetStoresBySearch(string searchString);
        
        void SaveStore(List<Store> stores);

        void UpdateStore(Store stores);

        void RemoveStore(Store store);

        void AddProductInStore(Product product, long storeId);
       void RemoveProductInStore(Product product, long storeId);

        void ProductInStock(Product product);

    }
}
