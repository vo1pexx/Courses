namespace Shop {
    // Магазин: список товарів і прибуток
    class Store {
        public List<Product> Products = new List<Product>();
        public int Profit = 0;

        public Store() {
            Products.Add(new Product("Хліб", 25, 40));
            Products.Add(new Product("Молоко", 45, 30));
            Products.Add(new Product("Яйця (10 шт)", 70, 25));
            Products.Add(new Product("Цукор", 40, 30));
            Products.Add(new Product("Олія", 95, 20));
            Products.Add(new Product("Шоколад", 60, 35));
            Products.Add(new Product("Чай", 120, 20));
            Products.Add(new Product("Сир", 180, 15));
            Products.Add(new Product("Ковбаса", 250, 12));
            Products.Add(new Product("Кава", 320, 10));
        }

        // Випадковий товар, який є в наявності і на який вистачає грошей. Якщо такого немає - null
        public Product? FindAffordableProduct(int money, Random rnd) {
            List<Product> candidates = new List<Product>();
            foreach (Product product in Products) {
                if (product.Quantity > 0 && product.Price <= money) {
                    candidates.Add(product);
                }
            }

            if (candidates.Count == 0) {
                return null;
            }
            return candidates[rnd.Next(candidates.Count)];
        }

        // Продаж: кількість товару -1, прибуток магазину + ціна, гроші покупця - ціна
        public void Sell(Product product, Customer customer) {
            product.Quantity--;
            Profit += product.Price;
            customer.Buy(product);
        }

        public bool HasProducts() {
            foreach (Product product in Products) {
                if (product.Quantity > 0) {
                    return true;
                }
            }
            return false;
        }
    }
}
