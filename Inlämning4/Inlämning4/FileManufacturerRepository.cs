using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Inlämning4
{
    public class FileManufacturerRepository : IManufacturerRepository
    {
        public HashSet<Manufacturer> manufacturersList = new HashSet<Manufacturer>();
        //DEFAULT CONSTRUCTOR 
        public FileManufacturerRepository()
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var programPath = Path.Combine(path, "Inlämning4");
                if (Directory.Exists(programPath))
                {
                    var jsonPath = Path.Combine(programPath, "Manufacturers.json");
                    if (File.Exists(jsonPath))
                    {
                        var records = LoadFromJson<Manufacturer>(jsonPath);
                        if (records != null)
                        {
                            manufacturersList = records.ToHashSet();
                        }
                    }
                }

            }
            catch (Exception msg)
            {

                msg.Dump(); ;
            }
        }
        //GET MANUFACTURERS
        public HashSet<Manufacturer> GetManufacturers()
        {

            return manufacturersList;
        }
        //PRINT MANUFACTURERS iNFORMATION
        public void PrintManufacturersInformation()
        {
            foreach (var manufacturer in manufacturersList)
            {
                manufacturer.Dump();
            }
        }
        //CREATE MANUFACTURER
        public void CreateManufacturer(string name, int ID, string country, string branch)
        {
            var manufacturer = new Manufacturer(name, country, ID, branch);
            manufacturersList.Add(manufacturer);
            $"{manufacturer.Name} has been created and added to the list".Dump();
        }

        //DELETE MANUFACTURER
        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            var m = manufacturersList.FirstOrDefault(m => m.ManufacturerId == manufacturer.ManufacturerId);
            if (m != null)
            {
                manufacturersList.Remove(m);
            }
            else
            {
                Console.WriteLine($"{manufacturer.Name} not found");
            }

        }

        //GET A MANUFACTURER
        public Manufacturer GetManufacturer(int manufacturerId)
        {
            var manufacturer = manufacturersList.First(m => m.ManufacturerId == manufacturerId);
            if (manufacturer != null)
            {
                Console.WriteLine($" The manufacturer: {manufacturer.Name} was found");
                return manufacturer;
            }
            else
            {
                Console.WriteLine($"\tThe Manufacture Id {manufacturerId} Was Not Found");
                return null;
            }

        }

        //UPDATE MANUFACTURER
        public void UpdateManufacturer(Manufacturer manufacturer, string NewName, int Newid)
        {
            var m = manufacturersList.FirstOrDefault(m => m.ManufacturerId == manufacturer.ManufacturerId);
            if (m != null)
            {
                m.Name = NewName;
                m.ManufacturerId = Newid;
                Console.WriteLine($"{manufacturer.Name} was updated");
            }
            Console.WriteLine($"{manufacturer.Name} Not found");
        }

        //GET MANUFACTURER PRODUCTS
        public IEnumerable<Product> GetManufacturerProducts(Manufacturer manufacturer)
        {
            return manufacturer.Products;
        }
        public void Dispose()
        {
            //Save to json file
            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programPath = Path.Combine(path, "Inlämning4");
            var jsonPath = Path.Combine(programPath, "Manufacturers.json");
            SaveTojson(jsonPath, manufacturersList);
        }
        //PRINT ALL THE MANUFACTURERS AND THEIR PRODUCTS
        public void PrintManufacurersProducts()
        {
            foreach (var manufacturer in manufacturersList)
            {
                //GROUPING FOR NOT GETTING REPETEAD ITEMS
                var products = manufacturer.Products.GroupBy(p => p.Name);

                manufacturer.Name.Dump("\n\tThe Manufacturer"); products.Count().Dump("\n\tHave this Number of Products");
                foreach (var product in products)
                {
                    product.Key.Dump();
                }
            }
        }

        //LOAD FROM A JSON FILE
        public static IEnumerable<Manufacturer> LoadFromJson<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);

            var records = JsonSerializer.Deserialize<List<Manufacturer>>(jsonString);
            return records.ToList();
        }
        //SAVE TO A JSON FILE
        public static void SaveTojson<T>(string filePath, IEnumerable<T> records)
        {
            var jsonString = JsonSerializer.SerializeToUtf8Bytes(records);
            File.WriteAllBytes(filePath, jsonString);
        }
    }
}
