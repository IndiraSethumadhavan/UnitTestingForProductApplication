namespace Inlämning4
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Product()
        {
        }
        public Product(string name, double price, int productId, Manufacturer manufacturer)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Price = price;
            this.Manufacturer = manufacturer;
        }
        public override string ToString()
        {
            return $"PRODUCT NAME : {Name}, Id : {ProductId}, Price {Price}, Manufacturer : {Manufacturer.Name}";
        }
    }
}
