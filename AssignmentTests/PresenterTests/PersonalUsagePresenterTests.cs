using Assignment.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Xml.Linq;
using Assignment.DTO;
using Assignment.Entity;

namespace AssignmentTests.PresenterTests
{
    [TestClass]
    public class PresonalUsagePresenterTests
    {
        [TestMethod]
        public void TestViewDataReturnsListOfOneItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };

            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 1, "Test", 0.44, 1, "Brandon", now)));

            viewDataList.AddRange(new PersonalUsagePresenter(dTOs, "Brandon").GetViewData());
            List<string> expectedList = new List<string> {};

            expectedList.Add(string.Format("\nPersonal Usage Report for Brandon"));
            expectedList.Add(string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                "Date Taken",
                "ID",
                "Name",
                "Quantity Removed"));

            expectedList.Add(string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                now,
                "1",
                "Test",
                "1"));

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfTwoItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };

            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 1, "Test", 0.44, 1, "Brandon", now)));

            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 2, "Test1", 0.44, 2, "Brandon", now)));

            viewDataList.AddRange(new PersonalUsagePresenter(dTOs, "Brandon").GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add(string.Format("\nPersonal Usage Report for Brandon"));
            expectedList.Add(string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                "Date Taken",
                "ID",
                "Name",
                "Quantity Removed"));

            expectedList.Add(string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                now,
                "1",
                "Test",
                "1"));

            expectedList.Add(string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                now,
                "2",
                "Test1",
                "2"));

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfThreeItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };

            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 1, "Test", 0.44, 1, "Brandon", now)));

            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 2, "Test1", 0.44, 2, "Brandon", now)));

            dTOs.Add(new TransactionDTO(
                 new TransactionLogEntry
                 ("Add", 3, "Test2", 0.44, 3, "Brandon", now)));

            viewDataList.AddRange(new PersonalUsagePresenter(dTOs, "Brandon").GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add(string.Format("\nPersonal Usage Report for Brandon"));
            expectedList.Add(string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                "Date Taken",
                "ID",
                "Name",
                "Quantity Removed"));

            expectedList.Add(string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                now,
                "1",
                "Test",
                "1"));

            expectedList.Add(string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                now,
                "2",
                "Test1",
                "2"));

            expectedList.Add(string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                now,
                "3",
                "Test2",
                "3"));

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }
    }
}
