
namespace GroupExpensesManager
{
    class Currency
    {
        public Currency(string name, decimal exchangeRate)
        {
            Name = name;
            ExchangeRate = exchangeRate;
        }

        public string Name { get; private set; }
        public decimal ExchangeRate { get; private set; }
    }
}
