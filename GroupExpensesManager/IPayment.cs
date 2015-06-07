using System;

namespace GroupExpensesManager
{
    public interface IPayment
    {
        Guid Id { get; }
        CurrencyValue Amount { get; }
        DateTime? TimeStamp { get; }
    }
}
