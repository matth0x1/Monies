using System;
using System.Collections.Generic;

namespace GroupExpensesManager
{
    class Expense : IPayment
    {
        public Expense(Person payer, List<Person> beneficiaries, DateTime timeStamp, Guid id, CurrencyValue amount)
        {
            Payer = payer;
            Beneficiaries = beneficiaries;
            TimeStamp = timeStamp;
            Id = id;
            Amount = amount;
        }

        public Person Payer { get; private set; }
        public List<Person> Beneficiaries { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public Guid Id { get; private set; }
        public CurrencyValue Amount { get; private set; }
    }
}
