namespace Shop {
    // Покупець з карткою, грошима та статистикою покупок
    class Customer {
        public int CardNumber;
        public int Money;
        public int ItemsBought;
        public int MoneySpent;

        public Customer(int cardNumber, int money) {
            CardNumber = cardNumber;
            Money = money;
            ItemsBought = 0;
            MoneySpent = 0;
        }

        // Покупець платить за товар: гроші зменшуються, статистика росте
        public void Buy(Product product) {
            Money -= product.Price;
            ItemsBought++;
            MoneySpent += product.Price;
        }
    }
}
