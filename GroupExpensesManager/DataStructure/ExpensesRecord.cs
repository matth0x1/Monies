using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

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
            using (StringWriter str = new StringWriter())
            using (XmlTextWriter xml = new XmlTextWriter(str))
            {
                xml.WriteStartDocument();
                xml.WriteWhitespace("\n");
                xml.WriteStartElement("ExpensesRecord");
                xml.WriteAttributeString("Version", "1.0.0.0");
                xml.WriteWhitespace("\n  ");

                //People
                xml.WriteStartElement("Participants");
                xml.WriteWhitespace("\n  ");
                //    Person: ID, Name

                foreach (Person person in Participants.Values)
                {
                    xml.WriteWhitespace("  ");
                    xml.WriteStartElement("Person");
                    xml.WriteAttributeString("ID", person.Id.ToString());
                    xml.WriteAttributeString("Name", person.Name);
                    xml.WriteEndElement();
                    xml.WriteWhitespace("\n  ");
                }
                // End Participants
                xml.WriteEndElement();
                xml.WriteWhitespace("\n  ");

                //Expenses 
                xml.WriteStartElement("Expenses");
                xml.WriteWhitespace("\n  ");

                foreach (Expense expense in Expenses.Values)
                {
                    //    Expense
                    xml.WriteWhitespace("  ");
                    xml.WriteStartElement("Expense");
                    xml.WriteAttributeString("Amount", expense.Amount.Amount.ToString(CultureInfo.InvariantCulture));
                    xml.WriteAttributeString("Currency", expense.Amount.Currency.Name);

                    if (expense.TimeStamp != null)
                        xml.WriteAttributeString("Timestamp", expense.TimeStamp.ToString());

                    xml.WriteWhitespace("\n      ");
                    
                    //        Beneficiaries: ID
                    xml.WriteStartElement("Beneficiaries");
                    xml.WriteWhitespace("\n      ");

                    foreach (Person beneficiary in expense.Beneficiaries)
                    {
                        xml.WriteWhitespace("  ");
                        xml.WriteStartElement("Beneficiary");
                        xml.WriteAttributeString("ID", beneficiary.Id.ToString());
                        xml.WriteEndElement();
                        xml.WriteWhitespace("\n      ");

                    }

                    // End Beneficiaries
                    xml.WriteEndElement();
                    xml.WriteWhitespace("\n    ");

                    // End Expense
                    xml.WriteEndElement();
                    xml.WriteWhitespace("\n  ");
                }
                // End Expenses
                xml.WriteEndElement();
                xml.WriteWhitespace("\n");

                // End ExpensesRecord
                xml.WriteEndElement();

                return str.ToString();
            }
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
