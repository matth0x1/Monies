
namespace GroupExpensesManager
{
    class CurrencyValue
    {
        public CurrencyValue(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }
    }
}
