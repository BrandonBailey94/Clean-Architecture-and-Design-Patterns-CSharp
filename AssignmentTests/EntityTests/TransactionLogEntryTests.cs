using Assignment.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests.EntityTests
{
    [TestClass]
    public class TransactionLogEntryTests
    {
        [TestMethod]
        public void TestIfTransactionTypeIsNullDoesItProduceTheCorrectExceptionMessage()
        {
            try
            {
                TransactionLogEntry transactionLogEntry = new TransactionLogEntry("", 1, "Test name", 3, 1, "Brandon", DateTime.Now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Transaction Type Invalid; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }

        [TestMethod]
        public void TestIfTransactionItemIDIsNullDoesItProduceTheCorrectExceptionMessage()
        {
            try
            {
                TransactionLogEntry transactionLogEntry = new TransactionLogEntry("Add", 0, "Test name", 3, 1, "Brandon", DateTime.Now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Transaction Item ID Invalid; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }

        [TestMethod]
        public void TestIfTransactionItemNameIsNullDoesItProduceTheCorrectExceptionMessage()
        {
            try
            {
                TransactionLogEntry transactionLogEntry = new TransactionLogEntry("Add", 1, "", 3, 1, "Brandon", DateTime.Now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Transaction Item Name Invalid; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }

        [TestMethod]
        public void TestIfTransactionItemPriceIsNullDoesItProduceTheCorrectExceptionMessage()
        {
            try
            {
                TransactionLogEntry transactionLogEntry = new TransactionLogEntry("Add", 1, "Test name", 0, 1, "Brandon", DateTime.Now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Transaction Item Price Invalid; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }

        [TestMethod]
        public void TestIfTransactionQuantityIsNullDoesItProduceTheCorrectExceptionMessage()
        {
            try
            {
                TransactionLogEntry transactionLogEntry = new TransactionLogEntry("Add", 1, "Test name", 3, -1, "Brandon", DateTime.Now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Transaction Item Quantity Invalid; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }

        [TestMethod]
        public void TestIfTransactionEmployeeNameIsNullDoesItProduceTheCorrectExceptionMessage()
        {
            try
            {
                TransactionLogEntry transactionLogEntry = new TransactionLogEntry("Add", 1, "Test name", 3, 1, "", DateTime.Now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Transaction Employee Name Invalid; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }
    }
}
