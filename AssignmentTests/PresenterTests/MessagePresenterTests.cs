using Assignment.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Assignment.DTO;
using Assignment.Entity;

namespace AssignmentTests.PresenterTests
{
    [TestClass]
    public class MessagePresenterTests
    {

        [TestMethod]
        public void TestViewDataReturnsASingleMessage()
        {
            string message = "Test1";
            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new MessagePresenter(message).GetViewData());
            List<string> expectedList = new List<string> {
                "Test1",
            };

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }
        [TestMethod]
        public void TestViewDataReturnsAListOfOneMessage()
        {
            List<string> messageList = new List<string> { 
            "Test1"
            };

            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new MessagePresenter(messageList).GetViewData());
            List<string> expectedList = new List<string> {
                "Test1",
            };

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsAListOfTwoMessage()
        {
            List<string> messageList = new List<string> {
            "Test1",
            "Test2",
            };

            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new MessagePresenter(messageList).GetViewData());
            List<string> expectedList = new List<string> {
                "Test1",
                "Test2",
            };

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }

        [TestMethod]
        public void TestViewDataReturnsAListOfThreeMessage()
        {
            List<string> messageList = new List<string> {
            "Test1",
            "Test2",
            "Test3",
            };

            List<string> viewDataList = new List<string> { };
            viewDataList.AddRange(new MessagePresenter(messageList).GetViewData());
            List<string> expectedList = new List<string> {
                "Test1",
                "Test2",
                "Test3",
            };

            CollectionAssert.AreEqual(expectedList, viewDataList);
        }
    }
}
