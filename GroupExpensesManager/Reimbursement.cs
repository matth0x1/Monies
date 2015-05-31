using System;

namespace GroupExpensesManager
{
    class Reimbursement : IPayment
    {
        public Reimbursement(Person payee, Guid id, CurrencyValue amount, DateTime timeStamp)
        {
            Payee = payee;
            Id = id;
            Amount = amount;
            TimeStamp = timeStamp;
        }

        public Person Payee { get; private set; }
        public Guid Id { get; private set; }
        public CurrencyValue Amount { get; private set; }
        public DateTime TimeStamp { get; private set; }
    }
}
