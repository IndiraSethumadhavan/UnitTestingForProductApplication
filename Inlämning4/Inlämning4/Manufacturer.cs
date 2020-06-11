using System.Collections.Generic;
using System.Linq;

namespace Inlämning4
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Branch { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public Manufacturer()
        {
        }
        public Manufacturer(string name, string country, int manufacturerÍd, string branch)
        {
            this.Name = name;
            this.Country = country;
            this.ManufacturerId = manufacturerÍd;
            this.Branch = branch;
            //I CREATE A LIST IN THE CONSTRUCTOR TO INICIALIZE THE STORE LIST, BECAUSE THE USER CAN´T PASS A LIST FROM THE CONSOLE
            List<Product> products = new List<Product>();
            Products = products;
        }
        public override string ToString()
        {
            return $"MANUFACTURER NAME : {Name}, Id : {ManufacturerId},Branch {Branch} ,Country : {Country}, Number of  Products: {Products.Count()} ";
        }
    }
}
