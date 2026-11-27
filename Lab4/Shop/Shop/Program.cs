namespace Shop {
    internal class Program {

        static List<Customer> CreateCustomers(int count, Random rnd) {
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < count; i++) {
                int cardNumber = rnd.Next(1, 1001);     // від 1 до 1000
                int money = rnd.Next(1000, 10001);      // від 1000 до 10 000
                customers.Add(new Customer(cardNumber, money));
            }
            return customers;
        }

        // Покупці купують по колу, доки хоч хтось ще може щось купити
        static void RunSimulation(Store store, List<Customer> customers, Random rnd) {
            bool someoneBought = true;
            while (someoneBought && store.HasProducts()) {
                someoneBought = false;
                foreach (Customer customer in customers) {
                    Product? product = store.FindAffordableProduct(customer.Money, rnd);
                    if (product != null) {
                        store.Sell(product, customer);
                        someoneBought = true;
                    }
                }
            }
        }

        static SimulationResult CalculateResult(Store store, List<Customer> customers) {
            Customer topBuyer = customers[0];
            Customer topSpender = customers[0];

            foreach (Customer customer in customers) {
                if (customer.ItemsBought > topBuyer.ItemsBought) {
                    topBuyer = customer;
                }
                if (customer.MoneySpent > topSpender.MoneySpent) {
                    topSpender = customer;
                }
            }

            SimulationResult result = new SimulationResult();
            result.Profit = store.Profit;
            result.TopBuyerCard = topBuyer.CardNumber;
            result.TopBuyerItems = topBuyer.ItemsBought;
            result.TopSpenderCard = topSpender.CardNumber;
            result.TopSpenderMoney = topSpender.MoneySpent;
            return result;
        }

        static void PrintResults(Store store, List<Customer> customers) {
            Console.WriteLine("\n--- Покупці ---");
            foreach (Customer customer in customers) {
                Console.WriteLine($"Картка №{customer.CardNumber}: куплено товарів {customer.ItemsBought}, витрачено {customer.MoneySpent}, залишилось грошей {customer.Money}");
            }

            Console.WriteLine("\n--- Залишок товарів у магазині ---");
            foreach (Product product in store.Products) {
                Console.WriteLine($"{product.Name}: {product.Quantity} шт (ціна {product.Price})");
            }

            SimulationResult result = CalculateResult(store, customers);
            Console.WriteLine("\n--- Підсумок ---");
            Console.WriteLine($"Прибуток магазину: {result.Profit}");
            Console.WriteLine($"Найбільше товарів купив покупець з карткою №{result.TopBuyerCard} ({result.TopBuyerItems} шт)");
            Console.WriteLine($"Найбільше грошей витратив покупець з карткою №{result.TopSpenderCard} ({result.TopSpenderMoney})");
        }

        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть кількість покупців: ");
            int count;
            if (!int.TryParse(Console.ReadLine(), out count) || count <= 0) {
                Console.WriteLine("Помилка: потрібно ввести додатне ціле число.");
                return;
            }

            Random rnd = new Random();
            Store store = new Store();
            List<Customer> customers = CreateCustomers(count, rnd);

            RunSimulation(store, customers, rnd);
            PrintResults(store, customers);
        }
    }
}
