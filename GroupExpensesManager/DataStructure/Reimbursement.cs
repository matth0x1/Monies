using System;

namespace GroupExpensesManager
{
    public class Reimbursement : IPayment
    {
        // Used for serialisation
        private Reimbursement() { }

        public Reimbursement(Person payer, Person payee, CurrencyValue amount, DateTime? timeStamp = null) 
            : this(Guid.NewGuid(), payer, payee, amount, timeStamp) { }
        
        public Reimbursement(Guid id, Person payer, Person payee, CurrencyValue amount, DateTime? timeStamp = null)
        {
            Id = id;
            Payer = payer;
            Payee = payee;
            Amount = amount;
            TimeStamp = timeStamp;
        }

        public Guid Id { get; private set; }
        public Person Payer { get; private set; }
        public Person Payee { get; private set; }
        public CurrencyValue Amount { get; private set; }
        public DateTime? TimeStamp { get; private set; }
    }
}
