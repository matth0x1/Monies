using System;
using System.Collections.Generic;

namespace GroupExpensesManager
{
    public class ExpensesRecord
    {
        // Used for serialisation
        private ExpensesRecord() { }

        public ExpensesRecord(Dictionary<Guid, Person> participants, Dictionary<Guid, Expense> expenses)
        {
            Participants = participants;
            Expenses = expenses;
        }

        public Dictionary<Guid, Person> Participants { get; private set; }
        public Dictionary<Guid, Expense> Expenses { get; private set; }

        public string Serialize()
        {
            return XmlSerializationUtils.SerializeObject(this);
        }

        public static ExpensesRecord Deserialize(string xmlString)
        {
            if (string.IsNullOrWhiteSpace(xmlString))
                throw new Exception("Unable to deserialize; given XML string was NULL, Empty or Whitespace.");

            try
            {
                return XmlSerializationUtils.DeserialiseObject<ExpensesRecord>(xmlString);
            }
            catch(Exception e)
            {
                throw new Exception("Unable to deserialize XML string to ExpensesRecord, see inner exception.", e);
            }
        }
    }
}
