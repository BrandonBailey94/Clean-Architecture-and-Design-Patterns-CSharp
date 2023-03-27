using Assignment.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Assignment.DTO;
using Assignment.Entity;

namespace AssignmentTests.PresenterTests
{
    [TestClass]
    public class FinancialPresenterTests
    {
        [TestMethod]
        public void TestViewDataReturnsListOfOneItem()
        {
            DateTime now = DateTime.Now;
            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };
            
               dTOs.Add(new TransactionDTO(
                    new TransactionLogEntry
                    ("Add", 1, "Test", 0.44, 1, "Brandon", now)));
            
            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new FinancialPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> {};

            expectedList.Add("\nFinancial Report:");
            expectedList.Add(string.Format("Test: Total price of item: £0.44"));
            expectedList.Add(string.Format("{0}: {1:C}", "Total price of all items", 0.44));

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfTwoItem()
        {
            DateTime now = DateTime.Now;
            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 1, "Test", 0.44, 1, "Brandon", now)));
            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 2, "Test1", 0.5, 2, "Brandon", now)));

            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new FinancialPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> {};

            expectedList.Add("\nFinancial Report:");
            expectedList.Add(string.Format("Test: Total price of item: £0.44"));
            expectedList.Add(string.Format("Test1: Total price of item: £1.00"));
            expectedList.Add(string.Format("{0}: {1:C}", "Total price of all items", 1.44));


            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfThreeItem()
        {
            DateTime now = DateTime.Now;
            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 1, "Test", 0.44, 1, "Brandon", now)));
            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 2, "Test1", 0.5, 2, "Brandon", now)));
            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 2, "Test2", 0.5, 4, "Brandon", now)));

            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new FinancialPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> {};

            expectedList.Add("\nFinancial Report:");
            expectedList.Add(string.Format("Test: Total price of item: £0.44"));
            expectedList.Add(string.Format("Test1: Total price of item: £1.00"));
            expectedList.Add(string.Format("Test2: Total price of item: £2.00"));
            expectedList.Add(string.Format("{0}: {1:C}", "Total price of all items", 3.44));

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }
    }
}
