using System;
using System.Collections.Generic;
using System.IO;
using GroupExpensesManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoniesTests
{
    [TestClass]
    public class DataLoadingTests
    {
        [TestMethod]
        public void SerializeData()
        {
            ExpensesRecord expensesRecord;

            // Create data
            {
                // Create Participants
                Dictionary<Guid, Person> participants = new Dictionary<Guid, Person>();

                Person paul   = new Person(new Guid("95af1e71-b8fe-43b4-a579-ec3a41b6e99f"),"Paul");
                Person ringo  = new Person(new Guid("39116393-da1b-4ad1-a8ba-89a78acfae0f"), "Ringo");
                Person john   = new Person(new Guid("9b371c8d-6eca-460a-867b-4105f0e42f58"), "John");
                Person george = new Person(new Guid("9059fd43-2960-4276-9200-82e3b33a1698"), "George");

                participants.Add(paul.Id,   paul);
                participants.Add(ringo.Id,  ringo);
                participants.Add(john.Id,   john);
                participants.Add(george.Id, george);

                List<Person> everyone = new List<Person>(participants.Values);

                // Create Expenses
                Dictionary<Guid, Expense> expenses = new Dictionary<Guid, Expense>();

                Expense expense1 = new Expense(paul,   everyone, new CurrencyValue(30.00m, Currency.Gbp));
                Expense expense2 = new Expense(ringo,  everyone, new CurrencyValue(10.00m, Currency.Gbp));
                Expense expense3 = new Expense(john,   everyone, new CurrencyValue(00.00m, Currency.Gbp));
                Expense expense4 = new Expense(george, everyone, new CurrencyValue(15.00m, Currency.Gbp));

                expenses.Add(expense1.Id, expense1);
                expenses.Add(expense2.Id, expense2);
                expenses.Add(expense3.Id, expense3);
                expenses.Add(expense4.Id, expense4);

                // Create ExpensesRecord
                expensesRecord = new ExpensesRecord(participants, expenses);
            }

            // Serialize Data
            string serialisedExpensesRecord = expensesRecord.Serialize();

            // Compare XML
            string exampleDataXml = GetSerializationTestXmlString();
            
            Assert.AreEqual(serialisedExpensesRecord, exampleDataXml);
        }

        [TestMethod]
        public void DeserialiseData()
        {
            string testData = GetSerializationTestXmlString();

            // Deserialise Data
            
            // Validate data objects
        }

        [TestMethod]
        public void SimpleHappyPath()
        {
           string testData = GetSimpleDataXmlString();

            // Build DataStore.

            // Calculate BalanceSheet.

            // Format BalanceSheet.

            // Output FormattedBalanceSheet.
        }

        private static string GetSimpleDataXmlString()
        {
            string filePath = @"TestData\simpleData.xml";
            string testData = File.ReadAllText(filePath);

            Assert.IsFalse(string.IsNullOrWhiteSpace(testData), "File contents is likely empty.");

            return testData;
        }

        private static string GetSerializationTestXmlString()
        {
            string filePath = @"TestData\simpleData.xml";
            string testData = File.ReadAllText(filePath);

            Assert.IsFalse(string.IsNullOrWhiteSpace(testData), "File contents is likely empty.");

            return testData;
        }
    }
}
