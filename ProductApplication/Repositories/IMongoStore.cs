﻿using ProductApplication.MongoDb_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApplication.Repositories
{
    interface IMongoStore
    {
        IEnumerable<MongoStore> GetAllStores();

        MongoStore GetByStoreId(string storeId);

        string UpdateStore(MongoStore store);

        string RemoveStore(MongoStore store);

        void InsertStore(MongoStore store);
        
    }
}
