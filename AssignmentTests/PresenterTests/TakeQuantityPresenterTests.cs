using Assignment.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace AssignmentTests.PresenterTests
{
    [TestClass]
    public class TakeQuantityPresenterTests
    {
        [TestMethod]
        public void TestViewDataReturnsListOfOneItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new TakeQuantityPresenter("Brandon", 1, 1).GetViewData());
            List<string> expectedList = new List<string> {
                "Brandon has removed 1 of Item ID: 1 on " + now.ToString("dd/MM/yyyy"),
            };

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfTwoItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new TakeQuantityPresenter("Brandon", 1, 1).GetViewData());
            viewDataList.AddRange(new TakeQuantityPresenter("Brandon", 2, 2).GetViewData());
            List<string> expectedList = new List<string> {
                "Brandon has removed 1 of Item ID: 1 on " + now.ToString("dd/MM/yyyy"),
                "Brandon has removed 2 of Item ID: 2 on " + now.ToString("dd/MM/yyyy"),
            };

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsListOfThreeItem()
        {
            DateTime now = DateTime.Now;
            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new TakeQuantityPresenter("Brandon", 1, 1).GetViewData());
            viewDataList.AddRange(new TakeQuantityPresenter("Brandon", 2, 2).GetViewData());
            viewDataList.AddRange(new TakeQuantityPresenter("Brandon", 3, 3).GetViewData());
            List<string> expectedList = new List<string> {
                "Brandon has removed 1 of Item ID: 1 on " + now.ToString("dd/MM/yyyy"),
                "Brandon has removed 2 of Item ID: 2 on " + now.ToString("dd/MM/yyyy"),
                "Brandon has removed 3 of Item ID: 3 on " + now.ToString("dd/MM/yyyy"),
            };

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }
    }
}
