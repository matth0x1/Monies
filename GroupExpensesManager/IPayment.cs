using System;

namespace GroupExpensesManager
{
    interface IPayment
    {
        Guid Id { get; }
        CurrencyValue Amount { get; }
        DateTime TimeStamp { get; }
    }
}
