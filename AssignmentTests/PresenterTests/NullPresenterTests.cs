using Assignment.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace AssignmentTests.PresenterTests
{
    [TestClass]
    public class NullPresenterTests
    {
        [TestMethod]
        public void TestViewDataReturnsListOfOneItem()
        {
            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new NullPresenter().GetViewData());
            List<string> expectedList = new List<string> {};

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }
    }
}
