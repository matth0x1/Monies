using System;
using System.Collections.Generic;

namespace GroupExpensesManager
{
    public class Expense : IPayment
    {
        // Used for serialisation
        private Expense() { }

        public Expense(Person payer, List<Person> beneficiaries, CurrencyValue amount, DateTime? timeStamp = null)
            : this(Guid.NewGuid(), payer, beneficiaries, amount, timeStamp) { }

        public Expense(Guid id, Person payer, List<Person> beneficiaries, CurrencyValue amount, DateTime? timeStamp = null)
        {
            Id = id;
            Payer = payer;
            Beneficiaries = beneficiaries;
            Amount = amount;
            TimeStamp = timeStamp;
        }

        public Guid Id { get; private set; }
        public Person Payer { get; private set; }
        public List<Person> Beneficiaries { get; private set; }
        public CurrencyValue Amount { get; private set; }
        public DateTime? TimeStamp { get; private set; }
    }
}
