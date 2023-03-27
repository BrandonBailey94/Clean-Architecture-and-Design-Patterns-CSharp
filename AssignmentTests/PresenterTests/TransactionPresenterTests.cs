using Assignment.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Assignment.DTO;
using Assignment.Entity;

namespace AssignmentTests.PresenterTests
{
    [TestClass]
    public class TransactionPresenterTests
    {
        [TestMethod]
        public void TestViewDataReturnsListOfOneRemoveQuantityItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };

            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Removed", 1, "Test", 0.44, 1, "Brandon", now)));

            viewDataList.AddRange(new TransactionPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add("\nTransaction Log:");
            expectedList.Add(string.Format(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Quantity",
                "Employee",
                "Price"));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Removed",
                    "1",
                    "Test",
                    "1",
                    "Brandon",
                    "Quantity Removed".Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}"), 0.44));

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfTwoRemoveQuantityItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };

            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Removed", 1, "Test", 0.44, 1, "Brandon", now)));
            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Removed", 2, "Test1", 0.45, 2, "Brandon", now)));

            viewDataList.AddRange(new TransactionPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add("\nTransaction Log:");
            expectedList.Add(string.Format(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Quantity",
                "Employee",
                "Price"));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Removed",
                    "1",
                    "Test",
                    "1",
                    "Brandon",
                    "Quantity Removed".Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}"), 0.44));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Removed",
                    "2",
                    "Test1",
                    "2",
                    "Brandon",
                    "Quantity Removed".Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}"), 0.45));

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfThreeRemoveQuantityItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };

            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Removed", 1, "Test", 0.44, 1, "Brandon", now)));
            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Removed", 2, "Test1", 0.45, 2, "Brandon", now)));
            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Removed", 3, "Test2", 0.46, 3, "Brandon", now)));

            viewDataList.AddRange(new TransactionPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add("\nTransaction Log:");
            expectedList.Add(string.Format(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Quantity",
                "Employee",
                "Price"));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Removed",
                    "1",
                    "Test",
                    "1",
                    "Brandon",
                    "Quantity Removed".Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}"), 0.44));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Removed",
                    "2",
                    "Test1",
                    "2",
                    "Brandon",
                    "Quantity Removed".Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}"), 0.45));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Removed",
                    "3",
                    "Test2",
                    "3",
                    "Brandon",
                    "Quantity Removed".Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}"), 0.46));

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfOneAddedQuantityItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };

            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Added", 1, "Test", 0.44, 1, "Brandon", now)));

            viewDataList.AddRange(new TransactionPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add("\nTransaction Log:");
            expectedList.Add(string.Format(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Quantity",
                "Employee",
                "Price"));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Added",
                    "1",
                    "Test",
                    "1",
                    "Brandon",
                    "£0.44"));

            foreach (string s in expectedList)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            foreach (string s in viewDataList)
            {
                Console.WriteLine(s);
            }

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfTwoAddedQuantityItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };

            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Added", 1, "Test", 0.44, 1, "Brandon", now)));
            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Added", 2, "Test1", 0.45, 2, "Brandon", now)));

            viewDataList.AddRange(new TransactionPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add("\nTransaction Log:");
            expectedList.Add(string.Format(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Quantity",
                "Employee",
                "Price"));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Added",
                    "1",
                    "Test",
                    "1",
                    "Brandon",
                    "£0.44"));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Added",
                    "2",
                    "Test1",
                    "2",
                    "Brandon",
                    "£0.45"));


            foreach (string s in expectedList)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            foreach (string s in viewDataList)
            {
                Console.WriteLine(s);
            }
            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfThreeAddedQuantityItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };

            List<TransactionDTO> dTOs = new List<TransactionDTO>() { };

            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Added", 1, "Test", 0.44, 1, "Brandon", now)));
            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Added", 2, "Test1", 0.45, 2, "Brandon", now)));
            dTOs.Add(new TransactionDTO(new TransactionLogEntry("Quantity Added", 3, "Test2", 0.46, 3, "Brandon", now)));

            viewDataList.AddRange(new TransactionPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add("\nTransaction Log:");
            expectedList.Add(string.Format(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Quantity",
                "Employee",
                "Price"));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Added",
                    "1",
                    "Test",
                    "1",
                    "Brandon",
                    "£0.44"));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Added",
                    "2",
                    "Test1",
                    "2",
                    "Brandon",
                    "£0.45"));

            expectedList.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    now.ToString("dd/MM/yyyy"),
                    "Quantity Added",
                    "3",
                    "Test2",
                    "3",
                    "Brandon",
                    "£0.46"));


            foreach (string s in expectedList)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            foreach (string s in viewDataList)
            {
                Console.WriteLine(s);
            }

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }
    }
}
