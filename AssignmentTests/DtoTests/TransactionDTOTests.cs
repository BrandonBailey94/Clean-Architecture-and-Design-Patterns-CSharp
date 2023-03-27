using Assignment.DTO;
using Assignment.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests.DtoTests
{
    [TestClass]
    public class TransactionDTOTests
    {
        [TestMethod]
        public void TestDTOIsNotNull()
        {
            DateTime now = DateTime.Now;

            TransactionLogEntry trans = new TransactionLogEntry("Add", 1, "Test", 0.44, 1, "Brandon", now);
            TransactionDTO transDTO = new TransactionDTO(trans);
            Assert.IsNotNull(transDTO);
        }

        [TestMethod]
        public void TestDTOsavestransTypeCorrectly()
        {
            DateTime now = DateTime.Now;

            TransactionLogEntry trans = new TransactionLogEntry("Add", 1, "Test", 0.44, 1, "Brandon", now);
            TransactionDTO transDTO = new TransactionDTO(trans);
            Assert.AreEqual(trans.TypeOfTransaction, transDTO.TypeOfTransaction);
        }

        [TestMethod]
        public void TestDTOsavestransItemIDCorrectly()
        {
            DateTime now = DateTime.Now;

            TransactionLogEntry trans = new TransactionLogEntry("Add", 1, "Test", 0.44, 1, "Brandon", now);
            TransactionDTO transDTO = new TransactionDTO(trans);
            Assert.AreEqual(trans.ItemID, transDTO.ItemID);
        }

        [TestMethod]
        public void TestDTOsavestransItemNameCorrectly()
        {
            DateTime now = DateTime.Now;

            TransactionLogEntry trans = new TransactionLogEntry("Add", 1, "Test", 0.44, 1, "Brandon", now);
            TransactionDTO transDTO = new TransactionDTO(trans);
            Assert.AreEqual(trans.ItemName, transDTO.ItemName);
        }

        [TestMethod]
        public void TestDTOsavestransItemPriceCorrectly()
        {
            DateTime now = DateTime.Now;

            TransactionLogEntry trans = new TransactionLogEntry("Add", 1, "Test", 0.44, 1, "Brandon", now);
            TransactionDTO transDTO = new TransactionDTO(trans);
            Assert.AreEqual(trans.ItemPrice, transDTO.ItemPrice);
        }

        [TestMethod]
        public void TestDTOsavestransItemQuantityCorrectly()
        {
            DateTime now = DateTime.Now;

            TransactionLogEntry trans = new TransactionLogEntry("Add", 1, "Test", 0.44, 1, "Brandon", now);
            TransactionDTO transDTO = new TransactionDTO(trans);
            Assert.AreEqual(trans.Quantity, transDTO.Quantity);
        }

        [TestMethod]
        public void TestDTOsavestransEmployeeNameCorrectly()
        {
            DateTime now = DateTime.Now;

            TransactionLogEntry trans = new TransactionLogEntry("Add", 1, "Test", 0.44, 1, "Brandon", now);
            TransactionDTO transDTO = new TransactionDTO(trans);
            Assert.AreEqual(trans.EmployeeName, transDTO.EmployeeName);
        }

        [TestMethod]
        public void TestDTOsavestransDateCorrectly()
        {
            DateTime now = DateTime.Now;

            TransactionLogEntry trans = new TransactionLogEntry("Add", 1, "Test", 0.44, 1, "Brandon", now);
            TransactionDTO transDTO = new TransactionDTO(trans);
            Assert.AreEqual(trans.DateAdded, transDTO.DateAdded);
        }
    }
}
