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

                Person paul   = new Person("Paul");
                Person ringo  = new Person("Ringo");
                Person john   = new Person("John");
                Person george = new Person("George");

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
            string filePath = @"TestData\SerializationTest.xml";
            string testData = File.ReadAllText(filePath);

            Assert.IsFalse(string.IsNullOrWhiteSpace(testData), "File contents is likely empty.");

            return testData;
        }
    }
}
