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

        static void Main(string[] args)
        {
            var prodect1 = new Product("Хлеб", 50);
            var prodect2 = new Product("Молоко", 100);
            var prodect3 = new Product("Кетчуп", 40);
            var prodect4 = new Product("Печеньк", 80);
            var prodect5 = new Product("Сок", 150);
            var prodect6 = new Product("Йогурт", 120);
        }
    }
}
