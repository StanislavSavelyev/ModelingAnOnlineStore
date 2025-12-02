namespace Modeling_an_online_store
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public Product(string name, decimal price)
            {
                Name = name;
                Price = price;
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Price}");
            }
        }
        public class  Store
        {
            public List<Product> Products { get; set; }

            public List<Product> Basket { get; set; }
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
                Basket = new List<Product>();
            }
            public void ShowCatalog()
            {
                Console.WriteLine("Каталог продуктов");
                ShowProdects(Products);
            }
            public void AddToBasket(int numberPtoduct)
            {
                Basket.Add(Products[numberPtoduct - 1]);
                Console.WriteLine($"Продукт {Products[numberPtoduct - 1].Name} успешно добавлен в корзину.");
                Console.WriteLine($"В коризне {Basket.Count} продуктов");
            }

            public void ShowBasket()
            {
                Console.WriteLine("Содержимое корзины");
                ShowProdects(Basket);
            }

            public void ShowProdects(List<Product> products)
            {
                int number = 1;
                foreach (var product in products)
                {
                    Console.Write(number + ". ");
                    product.Print();
                    number++;
                }
            }
        }

        static void Main(string[] args)
        {
            var onlineStore = new Store();

            Console.WriteLine("Здравствуйте, выберите дейтвие:");
            Console.WriteLine("1. Показать каталог продуктов?");
            Console.WriteLine("Выберите номер действия который хотите совершить");

            int number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1: onlineStore.ShowCatalog(); break;
                default: Console.WriteLine("Выберите номер действия из списка"); break;
            }
            bool yes = false;
            do
            {
                Console.WriteLine("Хотите добавить продукт в корзину? Введите Да или Нет.");
                yes = IsYes(Console.ReadLine());
                if (yes)
                {
                    onlineStore.ShowCatalog();
                    Console.WriteLine("Напишите номер продукта который нужно добавить в корзину");
                    int productNumber = Convert.ToInt32(Console.ReadLine);
                    onlineStore.AddToBasket(productNumber);
                }
            }while (yes);

            Console.WriteLine("Хотите посмотреть корзину? Введите Да или Нет.");
            yes = IsYes(Console.ReadLine());
            if (yes)
            {
                onlineStore.ShowBasket();
            }
               
        }

        private static bool IsYes(string answer)
        {
            return answer.ToLower() == "да";   
        }
    }
}
