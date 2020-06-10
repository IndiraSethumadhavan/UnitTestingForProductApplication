using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using ProductApplication;
using ProductApplication.Controller;

namespace ProductApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Product Management
            ProductManagement prod = new ProductManagement();
            prod.ProdManagment();

            //Store Management
            StoreManagement store = new StoreManagement();
            store.StoresManagment();
        }
    }
}

