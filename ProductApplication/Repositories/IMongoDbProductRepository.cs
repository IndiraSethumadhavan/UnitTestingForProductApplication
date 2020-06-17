using ProductApplication.MongoDb_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApplication.Repositories
{
   public interface IMongoDbProductRepository
    {
        IEnumerable<MongoProduct> GetAllProducts();

        MongoProduct GetByProductId(string productId);

        void SaveProduct(List<MongoProduct> products);

        string UpdateProduct(MongoProduct product);

        string RemoveProduct(MongoProduct product);
        void InsertProduct(string tableName, List<MongoProduct> product);

    }
}
