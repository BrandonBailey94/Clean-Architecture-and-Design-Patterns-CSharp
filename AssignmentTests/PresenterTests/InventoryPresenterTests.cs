using Assignment.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Assignment.DTO;
using Assignment.Entity;

namespace AssignmentTests.PresenterTests
{
    [TestClass]
    public class InventoryPresenterTests
    {
        [TestMethod]
        public void TestViewDataReturnsListOfOneItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };

            List<ItemDTO> dTOs = new List<ItemDTO>() { };

            dTOs.Add(new ItemDTO(new Item(1, "Test", 1, now)));

            viewDataList.AddRange(new InventoryPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add("\nAll items");
            expectedList.Add(string.Format(
                "\t{0, -4} {1, -20} {2, -20}",
                "ID",
                "Name",
                "Quantity"));

            expectedList.Add(string.Format(
                    "\t{0, -4} {1, -20} {2, -20}",
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

            List<ItemDTO> dTOs = new List<ItemDTO>() { };

            dTOs.Add(new ItemDTO(new Item(1, "Test", 1, now)));
            dTOs.Add(new ItemDTO(new Item(2, "Test1", 2, now)));

            viewDataList.AddRange(new InventoryPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add("\nAll items");
            expectedList.Add(string.Format(
                "\t{0, -4} {1, -20} {2, -20}",
                "ID",
                "Name",
                "Quantity"));

            expectedList.Add(string.Format(
                    "\t{0, -4} {1, -20} {2, -20}",
                    "1",
                    "Test",
                    "1"));
            expectedList.Add(string.Format(
                    "\t{0, -4} {1, -20} {2, -20}",
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

            List<ItemDTO> dTOs = new List<ItemDTO>() { };

            dTOs.Add(new ItemDTO(new Item(1, "Test", 1, now)));
            dTOs.Add(new ItemDTO(new Item(2, "Test1", 2, now)));
            dTOs.Add(new ItemDTO(new Item(3, "Test2", 3, now)));

            viewDataList.AddRange(new InventoryPresenter(dTOs).GetViewData());
            List<string> expectedList = new List<string> { };

            expectedList.Add("\nAll items");
            expectedList.Add(string.Format(
                "\t{0, -4} {1, -20} {2, -20}",
                "ID",
                "Name",
                "Quantity"));

            expectedList.Add(string.Format(
                    "\t{0, -4} {1, -20} {2, -20}",
                    "1",
                    "Test",
                    "1"));
            expectedList.Add(string.Format(
                    "\t{0, -4} {1, -20} {2, -20}",
                    "2",
                    "Test1",
                    "2"));
            expectedList.Add(string.Format(
                    "\t{0, -4} {1, -20} {2, -20}",
                    "3",
                    "Test2",
                    "3"));

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }
    }
}
