using ProductApplication.MongoDb_Models;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using ProductApplication.Models;

namespace ProductApplication.Repositories
{
   public class MongoDbStoreRepository : IMongoStore
    {
        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<MongoStore> collection;

        public MongoDbStoreRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("Läger");
            collection = database.GetCollection<MongoStore>("Stores");
        }

        public IEnumerable<MongoStore> GetAllStores()
        {
            var allStores = collection.Find(Builders<MongoStore>.Filter.Empty);
            return allStores.ToEnumerable();
        }

        public MongoStore GetByStoreId(string storeId)
        {
            MongoStore record = collection.Find(Builders<MongoStore>.Filter.Eq(x => x.Id, storeId)).FirstOrDefault();
            return record;
        }

        public void InsertStore(MongoStore store)
        {
            var foundItems = collection.Find<MongoStore>(x => x.StoreName== store.StoreName).Any();
            if (!foundItems)
                collection.InsertOne(store);
        }

        public string RemoveStore(MongoStore store)
        {
            collection.DeleteOne(s => s.StoreName == store.StoreName);
            return "Store is removed successfully :" + store.StoreName;
        }

        public string UpdateStore(MongoStore store)
        {
            collection.ReplaceOne(p => p.StoreName == store.StoreName, store);

            return "Store Address and Store PinCode details are updated successfully";
        }
    }
}
