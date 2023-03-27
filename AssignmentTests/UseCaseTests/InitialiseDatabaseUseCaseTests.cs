using Assignment.Entity;
using Assignment.UseCases;
using DataGateway;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AssignmentTests.UseCaseTests
{
    [TestClass]
    public class InitialiseDatabaseUseCaseTests
    {
        [TestMethod]
        public void TestBehaviourForInitDatabaseFindEmployee()
        {
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();

            InitialiseDatabase_Command InitDatabase = new InitialiseDatabase_Command(facadeMock.Object);

            InitDatabase.Execute();

            facadeMock.Verify(f => f.AddItem(It.IsAny<Item>()), Times.Exactly(2));

        }

        [TestMethod]
        public void TestBehaviourForInitDatabaseAddTransaction()
        {
            DateTime now = DateTime.Now;
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));
            facadeMock.Setup(f => f.AddItem(It.IsAny<Item>()));

            InitialiseDatabase_Command InitDatabase = new InitialiseDatabase_Command(facadeMock.Object);

            InitDatabase.Execute();

            facadeMock.Verify(f => f.AddTransaction(It.IsAny<TransactionLogEntry>()), Times.Exactly(4));

        }

        [TestMethod]
        public void TestBehaviourForInitDatabaseAddQuantity()
        {
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));
            facadeMock.Setup(f => f.AddItem(It.IsAny<Item>()));

            InitialiseDatabase_Command InitDatabase = new InitialiseDatabase_Command(facadeMock.Object);

            InitDatabase.Execute();

            facadeMock.Verify(f => f.AddQuantity(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }

        [TestMethod]
        public void TestBehaviourForInitDatabaseRemoveQuantity()
        {
            Mock<IGatewayFacade> facadeMock = new Mock<IGatewayFacade>();
            facadeMock.Setup(f => f.FindEmployee(It.IsAny<string>())).Returns(new Employee("Me"));

            InitialiseDatabase_Command InitDatabase = new InitialiseDatabase_Command(facadeMock.Object);

            InitDatabase.Execute();

            facadeMock.Verify(f => f.RemoveQuantity(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }
    }
}
