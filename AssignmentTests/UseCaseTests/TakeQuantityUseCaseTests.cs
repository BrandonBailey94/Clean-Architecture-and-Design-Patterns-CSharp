using Assignment.Entity;
using Assignment.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AssignmentTests.UseCaseTests
{
    [TestClass]
    public class TakeQuantityUseCaseTests
    {
        [TestMethod]
        public void TestBehaviourForTakeQuantityFindEmployee()
        {
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();

            TakeQuantityFromItem_Command AddQuantity = new TakeQuantityFromItem_Command("Brandon", 1, 1, facadeMock.Object);

            AddQuantity.Execute();

            facadeMock.Verify(f => f.FindEmployee(It.IsAny<string>()), Times.Once);

        }

        [TestMethod]
        public void TestBehaviourForTakeQuantityFindItem()
        {
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));

            TakeQuantityFromItem_Command AddQuantity = new TakeQuantityFromItem_Command("Brandon", 1, 1, facadeMock.Object);

            AddQuantity.Execute();

            facadeMock.Verify(f => f.FindItem(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void TestBehaviourForTakeQuantityRemoveQuantity()
        {
            DateTime now = DateTime.Now;
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));
            facadeMock.Setup(f => f.FindItem(It.IsAny<int>())).Returns(new Item(1, "Test", 1, now));

            TakeQuantityFromItem_Command AddQuantity = new TakeQuantityFromItem_Command("Brandon", 1, 0, facadeMock.Object);

            AddQuantity.Execute();

            facadeMock.Verify(f => f.RemoveQuantity(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void TestBehaviourForTakeQuantityTakeQuantityAddTransaction()
        {
            DateTime now = DateTime.Now;
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));
            facadeMock.Setup(f => f.FindItem(It.IsAny<int>())).Returns(new Item(1, "Test", 1, now));

            TakeQuantityFromItem_Command AddQuantity = new TakeQuantityFromItem_Command("Brandon", 1, 1, facadeMock.Object);

            AddQuantity.Execute();

            facadeMock.Verify(f => f.AddTransaction(It.IsAny<TransactionLogEntry>()), Times.Once);

        }
    }
}
