using System;
using System.Collections.Generic;

namespace Inlämning4
{
    interface IManufacturerRepository : IDisposable
    {
        public Manufacturer GetManufacturer(int manufacturerId);
        public void PrintManufacturersInformation();
        public void CreateManufacturer(string name, int ID, string country, string branch);
        public void DeleteManufacturer(Manufacturer manufacturer);
        public HashSet<Manufacturer> GetManufacturers();
        public void UpdateManufacturer(Manufacturer manufacturer, string NewName, int Newid);
        public IEnumerable<Product> GetManufacturerProducts(Manufacturer manufacturer);
        public void PrintManufacurersProducts();

    }
}
