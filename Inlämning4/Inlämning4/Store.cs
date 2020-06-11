using System.Collections.Generic;
using System.Linq;

namespace Inlämning4
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }


        public Store()
        {
        }
        public Store(string Name, int StoreId)
        {
            this.Name = Name;
            this.StoreId = StoreId;
            //I CREATE A LIST IN THE CONSTRUCTOR TO INICIALIZE THE STORE LIST, BECAUSE THE USER CAN´T PASS A LIST FROM THE CONSOLE
            List<Product> products = new List<Product>();
            Products = products;
        }
        public override string ToString()
        {
            return $"STORE NAME :{Name} , Id : {StoreId}, Number of Products: {Products.Count()}";
        }
    }
}

