using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoniesTests
{
    [TestClass]
    public class DataLoadingTests
    {
        [TestMethod]
        public void SimpleHappyPath()
        {
            string filePath = @"TestData\simpleData.xml";
            string testData = File.ReadAllText(filePath);

            Assert.IsFalse(string.IsNullOrWhiteSpace(testData), "File contents is likely empty.");

            // Build DataStore.

            // Calculate BalanceSheet.

            // Format BalanceSheet.

            // Output FormattedBalanceSheet.
        }
    }
}
