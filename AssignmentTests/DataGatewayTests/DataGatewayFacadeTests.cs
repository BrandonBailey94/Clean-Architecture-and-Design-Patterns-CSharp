using Assignment.Entity;
using DataGateway;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AssignmentTests.DataGatewayTests
{
    [TestClass]
    public class DataGatewayFacadeTests
    {
        [TestMethod]
        public void TestThatNewEmployeeIsAddedIntoTheDatabase()
        {
            EmployeeGateway empGateway = new EmployeeGateway();
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();

            empGateway.DeleteAllEmployees();

            dataGatewayFacade.AddEmployee(new Employee("Brandon"));

            Assert.AreEqual(1, dataGatewayFacade.GetAllEmployees().Count);

        }

        [TestMethod]
        public void TestThatNewItemIsAddedIntoTheDatabase()
        {
            ItemGateway itemGateway = new ItemGateway();
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();

            itemGateway.DeleteAllItems();

            dataGatewayFacade.AddItem(new Item(1, "Test Item", 1, DateTime.Now));

            Assert.AreEqual(1, dataGatewayFacade.GetAllItems().Count);
        }

        [TestMethod]
        public void TestThatNewTransactionIsAddedIntoTheDatabase()
        {
            TransactionGateway transactionGateway = new TransactionGateway();
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();

            transactionGateway.DeleteAllTransactions();

            dataGatewayFacade.AddTransaction(new TransactionLogEntry("Add", 1, "Test Item", 0.40, 1, "Brandon", DateTime.Now));

            Assert.AreEqual(1, dataGatewayFacade.GetAllTransactions().Count);
        }

        [TestMethod]
        public void TestFacadeFindItemReturnsCorrectItem()
        {
            DateTime now = DateTime.Now;
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();
            ItemGateway itemGateway = new ItemGateway();

            itemGateway.DeleteAllItems();
            Item AddedItem = new Item(1, "Test", 1, now);
            dataGatewayFacade.AddItem(AddedItem);
            Item findItem = dataGatewayFacade.FindItem(1);

            Assert.AreEqual(findItem.ID, AddedItem.ID);
        }

        [TestMethod]
        public void TestFacadeFindEmployeeReturnsCorrectEmployee()
        {
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();
            EmployeeGateway employeeGateway = new EmployeeGateway();

            employeeGateway.DeleteAllEmployees();
            Employee AddedEmployee = new Employee("Brandon");
            dataGatewayFacade.AddEmployee(AddedEmployee);
            Employee findEmployee = dataGatewayFacade.FindEmployee("Brandon");

            Assert.AreEqual(findEmployee.EmpName, AddedEmployee.EmpName);
        }

        [TestMethod]
        public void TestFacadeGetAllItemsReturnsCorrectItemCountOfOne()
        {
            DateTime now = DateTime.Now;
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();
            ItemGateway itemGateway = new ItemGateway();

            itemGateway.DeleteAllItems();
            Item AddedItem = new Item(1, "Test", 1, now);
            dataGatewayFacade.AddItem(AddedItem);
            List<Item> getItems = dataGatewayFacade.GetAllItems();

            Assert.AreEqual(getItems.Count, 1);
        }

        [TestMethod]
        public void TestFacadeGetAllItemsReturnsCorrectItemCountOfTwo()
        {
            DateTime now = DateTime.Now;
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();
            ItemGateway itemGateway = new ItemGateway();

            itemGateway.DeleteAllItems();
            Item AddedItem = new Item(1, "Test", 1, now);
            Item AddedItem2 = new Item(2, "Test1", 2, now);
            dataGatewayFacade.AddItem(AddedItem);
            dataGatewayFacade.AddItem(AddedItem2);
            List<Item> getItems = dataGatewayFacade.GetAllItems();

            Assert.AreEqual(getItems.Count, 2);
        }

        [TestMethod]
        public void TestFacadeGetAllEmployeesReturnsCorrectEmployeesCountOfOne()
        {
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();
            EmployeeGateway employeeGateway = new EmployeeGateway();

            employeeGateway.DeleteAllEmployees();
            Employee AddedEmployee = new Employee("Brandon");
            dataGatewayFacade.AddEmployee(AddedEmployee);
            List<Employee> getEmployees = dataGatewayFacade.GetAllEmployees();

            Assert.AreEqual(getEmployees.Count, 1);
        }

        [TestMethod]
        public void TestFacadeGetAllEmployeeReturnsCorrectEmployeeCountOfTwo()
        {
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();
            EmployeeGateway employeeGateway = new EmployeeGateway();

            employeeGateway.DeleteAllEmployees();
            Employee AddedEmployee = new Employee("Brandon");
            Employee AddedEmployee2 = new Employee("Brandon2");
            dataGatewayFacade.AddEmployee(AddedEmployee);
            dataGatewayFacade.AddEmployee(AddedEmployee2);
            List<Employee> getEmployees = dataGatewayFacade.GetAllEmployees();

            Assert.AreEqual(getEmployees.Count, 2);
        }

        [TestMethod]
        public void TestFacadeGetAllTransactionsReturnsCorrectTransactionsCountOfOne()
        {
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();
            TransactionGateway transactionGateway = new TransactionGateway();

            transactionGateway.DeleteAllTransactions();
            TransactionLogEntry trans = new TransactionLogEntry("Add", 1, "Test Item", 0.40, 1, "Brandon", DateTime.Now);
            dataGatewayFacade.AddTransaction(trans);
            List<TransactionLogEntry> getTransaction = dataGatewayFacade.GetAllTransactions();

            Assert.AreEqual(getTransaction.Count, 1);
        }

        [TestMethod]
        public void TestFacadeGetAllTransactionsReturnsCorrectTransactionsCountOfTwo()
        {
            DataGatewayFacade dataGatewayFacade = new DataGatewayFacade();
            TransactionGateway transactionGateway = new TransactionGateway();

            transactionGateway.DeleteAllTransactions();
            TransactionLogEntry trans = new TransactionLogEntry("Add", 1, "Test Item", 0.40, 1, "Brandon", DateTime.Now);
            TransactionLogEntry trans1 = new TransactionLogEntry("Add", 2, "Test Item2", 0.45, 2, "Brandon", DateTime.Now);
            dataGatewayFacade.AddTransaction(trans);
            dataGatewayFacade.AddTransaction(trans1);
            List<TransactionLogEntry> getTransaction = dataGatewayFacade.GetAllTransactions();

            Assert.AreEqual(getTransaction.Count, 2);
        }
    }
}
