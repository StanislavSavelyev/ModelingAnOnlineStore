namespace Modeling_an_online_store
{
    internal class Program
    {
        public class Product
        {
            string Name { get; set; }
            decimal Price { get; set; }
            public Product(string name, decimal price)
            {
                Name = name;
                Price = price;
            }
        }
        public class  Store
        {
            public List<Product> Products { get; set; }
            public Store()
            {
                Products = new List<Product>
                {
                    new Product("Хлеб", 50),
                    new Product("Молоко", 100),
                    new Product("Кетчуп", 40),
                    new Product("Печеньк", 80),
                    new Product("Сок", 150),
                    new Product("Йогурт", 120)
                };
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
