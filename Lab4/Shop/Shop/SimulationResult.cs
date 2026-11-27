namespace Shop {
    // Структура з підсумками симуляції
    struct SimulationResult {
        public int Profit;
        public int TopBuyerCard;      // картка покупця з найбільшою кількістю товарів
        public int TopBuyerItems;
        public int TopSpenderCard;    // картка покупця, який витратив найбільше грошей
        public int TopSpenderMoney;
    }
}
