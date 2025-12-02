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
        public class Store
        {
            public List<Product> Products { get; set; }

            public List<Product> Basket { get; set; }
            public List<Order> Orders { get; set; }
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
                Orders = new List<Order>();
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

            public void CreateOrder()
            {
                //Передать в отдел доставки
                if (Basket.Count > 0)
                {
                    var order = new Order(Basket);
                    Orders.Add(order);
                    Basket.Clear();
                    Console.WriteLine("Зака успешно создан");
                }
                else
                {
                    Console.WriteLine("Корзина пустая, сначала добавте товар, который хотите купить");
                }
            }
        }

        public class Order
        {
            public List<Product> Products { get; set; }

            public decimal FullPrice { get; set; }
            public Order(List<Product> products)
            {
                Products = products;

                foreach (var product in products)
                {
                    FullPrice += product.Price;
                }
            }
        }

        static void Main(string[] args)
        {
            var onlineStore = new Store();
            while (true)
            {
                Console.WriteLine("Здравствуйте, выберите дейтвие:");
                Console.WriteLine("1. Показать каталог продуктов?");
                Console.WriteLine("2. Хотите добавить продукт в корзину?");
                Console.WriteLine("3. Хотите посмотреть корзину?");
                Console.WriteLine("4. Хотите оформить заказ?");
                Console.WriteLine("Выберите номер действия который хотите совершить");

                int number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1: onlineStore.ShowCatalog(); break;
                    case 2:
                        {
                            string answer = string.Empty;
                            do
                            {
                                onlineStore.ShowCatalog();
                                Console.WriteLine("Напишите номер продукта который нужно добавить в корзину");
                                int productNumber = Convert.ToInt32(Console.ReadLine());
                                if (productNumber < 1 || productNumber > onlineStore.Products.Count)
                                {
                                    Console.WriteLine("Такой позиции не существует, попробуйте еще раз");
                                    answer = "да";
                                    continue;
                                }
                                onlineStore.AddToBasket(productNumber);
                                Console.WriteLine("Хотите добавить еще товар? Введите Да или Нет");
                                answer = Console.ReadLine().ToLower();

                                while (answer != "нет" && answer != "да")
                                {
                                    Console.WriteLine("Не верные данные попробуйте еще раз");
                                    answer = Console.ReadLine().ToLower();
                                }
                            } while (answer == "да");
                        }
                        break;
                    case 3: onlineStore.ShowBasket(); break;
                    case 4: onlineStore.CreateOrder(); break;
                    default: Console.WriteLine("Выберите номер действия из списка"); break;
                }

            }
        }
    }
}
