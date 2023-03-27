using Assignment.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AssignmentTests.PresenterTests
{
    [TestClass]
    public class AddQuantityPresenterTests
    {
        [TestMethod]
        public void TestViewDataReturnsListOfOneItem()
        {
            DateTime now = DateTime.Now;
            List<string> expectedList = new List<string> {
                "2 items have been added to Item ID: 4 on " + now.ToString("dd/MM/yyyy")
            };

            CollectionAssert.AreEqual(expectedList, new AddQuantityPresenter(2, 4).GetViewData());
        }

        [TestMethod]
        public void TestViewDataReturnsListOfTwoItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new AddQuantityPresenter(2, 4).GetViewData());
            viewDataList.AddRange(new AddQuantityPresenter(1, 5).GetViewData());
            List<string> expectedList = new List<string> {
                "2 items have been added to Item ID: 4 on " + now.ToString("dd/MM/yyyy"),
                "1 items have been added to Item ID: 5 on " + now.ToString("dd/MM/yyyy"),
            };

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfThreeItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new AddQuantityPresenter(2, 4).GetViewData());
            viewDataList.AddRange(new AddQuantityPresenter(1, 5).GetViewData());
            viewDataList.AddRange(new AddQuantityPresenter(3, 2).GetViewData());
            List<string> expectedList = new List<string> {
                "2 items have been added to Item ID: 4 on " + now.ToString("dd/MM/yyyy"),
                "1 items have been added to Item ID: 5 on " + now.ToString("dd/MM/yyyy"),
                "3 items have been added to Item ID: 2 on " + now.ToString("dd/MM/yyyy"),
            };

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }
    }
}
