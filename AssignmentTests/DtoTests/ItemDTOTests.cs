using Assignment.DTO;
using Assignment.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssignmentTests.DtoTests
{
    [TestClass]
    public class AddItemControllerTests
    {
        [TestMethod]
        public void TestDTOIsNotNull()
        {
            DateTime now = DateTime.Now;

            Item item = new Item(1, "Test", 1, now);
            ItemDTO itemDTO = new ItemDTO(item);
            Assert.IsNotNull(itemDTO);
        }

        [TestMethod]
        public void TestDTOsavesItemIDCorrectly()
        {
            DateTime now = DateTime.Now;

            Item item = new Item(1, "Test", 1, now);
            ItemDTO itemDTO = new ItemDTO(item);
            Assert.AreEqual(item.ID, itemDTO.ID);
        }

        [TestMethod]
        public void TestDTOsavesItemNameCorrectly()
        {
            DateTime now = DateTime.Now;

            Item item = new Item(1, "Test", 1, now);
            ItemDTO itemDTO = new ItemDTO(item);
            Assert.AreEqual(item.Name, itemDTO.Name);
        }

        [TestMethod]
        public void TestDTOsavesItemQuantityCorrectly()
        {
            DateTime now = DateTime.Now;

            Item item = new Item(1, "Test", 1, now);
            ItemDTO itemDTO = new ItemDTO(item);
            Assert.AreEqual(item.Quantity, itemDTO.Quantity);
        }

        [TestMethod]
        public void TestDTOsavesItemDateCorrectly()
        {
            DateTime now = DateTime.Now;

            Item item = new Item(1, "Test", 1, now);
            ItemDTO itemDTO = new ItemDTO(item);
            Assert.AreEqual(item.DateCreated, itemDTO.DateCreated);
        }
    }
}
