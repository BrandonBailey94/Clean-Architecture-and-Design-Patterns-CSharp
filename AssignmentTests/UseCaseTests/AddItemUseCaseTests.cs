using Assignment.Entity;
using Assignment.UseCases;
using Castle.Components.DictionaryAdapter.Xml;
using Castle.Core.Smtp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AssignmentTests.UseCaseTests
{
    [TestClass]
    public class AddItemUseCaseTests
    {
        [TestMethod]
        public void TestBehaviourForAddItemFindEmployee()
        {
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();

            AddItemToStock_Command AddItem = new AddItemToStock_Command("Brandon", 1, "Test", 1, 0.44, facadeMock.Object);

            AddItem.Execute();

            facadeMock.Verify(facadeMock => facadeMock.FindEmployee(It.IsAny<string>()), Times.Once);

        }

        [TestMethod]
        public void TestBehaviourForAddItem()
        {
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));

            AddItemToStock_Command AddItem = new AddItemToStock_Command("Brandon", 1, "Test", 1, 0.44, facadeMock.Object);

            AddItem.Execute();

            facadeMock.Verify(facadeMock => facadeMock.AddItem(It.IsAny<Item>()), Times.Once);

        }

        [TestMethod]
        public void TestBehaviourForAddItemAddTransaction()
        {
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));

            AddItemToStock_Command AddItem = new AddItemToStock_Command("Brandon", 1, "Test", 1, 0.44, facadeMock.Object);

            AddItem.Execute();

            facadeMock.Verify(facadeMock => facadeMock.AddTransaction(It.IsAny<TransactionLogEntry>()), Times.Once);

        }
    }
}
