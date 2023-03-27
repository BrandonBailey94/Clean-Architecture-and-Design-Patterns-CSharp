using Assignment.Entity;
using Assignment.UseCases;
using DataGateway;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AssignmentTests.UseCaseTests
{
    [TestClass]
    public class AddQuantityUseCaseTests
    {
        [TestMethod]
        public void TestBehaviourForAddQuantityFindEmployee()
        {
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();

            AddQuantityToItem_Command AddQuantity = new AddQuantityToItem_Command(1, "Brandon", 1, 0.44, facadeMock.Object);

            AddQuantity.Execute();

            facadeMock.Verify(f => f.FindEmployee(It.IsAny<string>()), Times.Once);

        }

        [TestMethod]
        public void TestBehaviourForAddQuantityFindItem()
        {
            DateTime now = DateTime.Now;
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));

            AddQuantityToItem_Command AddQuantity = new AddQuantityToItem_Command(1, "Brandon", 1, 0.44, facadeMock.Object);

            AddQuantity.Execute();

            facadeMock.Verify(f => f.FindItem(It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void TestBehaviourForAddQuantity()
        {
            DateTime now = DateTime.Now;
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));
            facadeMock.Setup(f => f.FindItem(It.IsAny<int>())).Returns(new Item(1, "Test", 1, now));

            AddQuantityToItem_Command AddQuantity = new AddQuantityToItem_Command(1, "Brandon", 1, 0.44, facadeMock.Object);

            AddQuantity.Execute();

            facadeMock.Verify(f => f.AddQuantity(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void TestBehaviourForAddQuantityAddTransaction()
        {
            DateTime now = DateTime.Now;
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));
            facadeMock.Setup(f => f.FindItem(It.IsAny<int>())).Returns(new Item(1, "Test", 1, now));

            AddQuantityToItem_Command AddQuantity = new AddQuantityToItem_Command(1, "Brandon", 1, 0.44, facadeMock.Object);

            AddQuantity.Execute();

            facadeMock.Verify(f => f.AddTransaction(It.IsAny<TransactionLogEntry>()), Times.Once);

        }
    }
}
