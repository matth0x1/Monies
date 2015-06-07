
namespace GroupExpensesManager
{
    public class Currency
    {
        // Used for serialisation
        private Currency() { }

        public Currency(string name, decimal exchangeRate)
        {
            Name = name;
            ExchangeRate = exchangeRate;
        }

        public string Name { get; private set; }
        public decimal ExchangeRate { get; private set; }

        public static Currency Gbp = new Currency("GBP", 1);
        public static Currency Usd = new Currency("USD", 0.65m);
        public static Currency Eur = new Currency("EUR", 0.72m);
    }
}
