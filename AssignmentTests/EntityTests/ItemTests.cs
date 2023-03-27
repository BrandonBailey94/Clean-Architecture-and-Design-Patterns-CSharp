using Assignment.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests.EntityTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void TestNewItemHasCorrectId()
        {
            Item item = new Item(1, "Test Item", 1, DateTime.Now);
            Assert.AreEqual(1, item.ID);
        }

        [TestMethod]
        public void TestNewItemHasCorrectName()
        {
            Item item = new Item(1, "Test Item", 1, DateTime.Now);
            Assert.AreEqual("Test Item", item.Name);
        }

        [TestMethod]
        public void TestNewItemHasCorrectQuantity()
        {
            Item item = new Item(2, "Test Item", 1, DateTime.Now);
            Assert.AreEqual(1, item.Quantity);
        }

        [TestMethod]
        public void TestNewItemHasCorrectCreationDate()
        {
            DateTime now = DateTime.Now;
            Item item = new Item(2, "Test Item", 1, now);
            Assert.AreEqual(now, item.DateCreated);
        }


        [TestMethod]
        public void TestInvalidValuesForNewItemProducesCorrectErrorMessage()
        {
            try
            {
                Item item = new Item(0, "", 0, DateTime.Now);
                Assert.Fail("No expection messaged produced.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is Exception);
            }
        }

        [TestMethod]
        public void TestInvalidIDExpection()
        {
            try
            {
                DateTime now = DateTime.Now;
                Item item = new Item(0, "Test Item", 1, now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: ID below 1; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }

        [TestMethod]
        public void TestInvalidQuantityExpection()
        {
            try
            {
                DateTime now = DateTime.Now;
                Item item = new Item(1, "Test Item", 0, now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Quantity below 1; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }

        [TestMethod]
        public void TestInvalidItemNameExpection()
        {
            try
            {
                DateTime now = DateTime.Now;
                Item item = new Item(1, "", 1, now);
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Item name is empty; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }
    }
}
