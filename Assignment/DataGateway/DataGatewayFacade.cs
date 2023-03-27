using Assignment.Entity;
using Assignment.UseCases;
using System.Collections.Generic;

namespace DataGateway
{
    public class DataGatewayFacade : IGatewayFacade
    {

        private readonly ItemGateway itemGateway;
        private readonly InitialisationGateway initialisationGateway;
        private readonly EmployeeGateway employeeGateway;
        private readonly TransactionGateway transactionGateway;

        public DataGatewayFacade()
        {
            itemGateway = new ItemGateway();
            initialisationGateway = new InitialisationGateway();
            employeeGateway = new EmployeeGateway();
            transactionGateway = new TransactionGateway();
        }

        public void AddItem(Item i)
        {
            itemGateway.Insert(i);
        }

        public void AddEmployee(Employee e)
        {
            employeeGateway.Insert(e);
        }

        public void AddTransaction(TransactionLogEntry t)
        {
            transactionGateway.Insert(t);
        }
        public void AddQuantity(int addQuantity, int itemId)
        {
            itemGateway.AddQuantity(addQuantity, itemId);
        }

        public void RemoveQuantity(int removeQuantity, int itemId)
        {
            itemGateway.RemoveQuantity(removeQuantity, itemId);
        }

        public Item FindItem(int itemId)
        {
            return itemGateway.FindItem(itemId);
        }

        public Employee FindEmployee(string employeeName)
        {
            return employeeGateway.FindEmployee(employeeName);
        }
        public List<Item> GetAllItems()
        {
            return itemGateway.GetAllItems();
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeGateway.GetAllEmployees();
        }

        public List<TransactionLogEntry> GetAllTransactions()
        {
            return transactionGateway.GetAllTransactions();
        }

        public void InitialiseOracleDatabase()
        {
            initialisationGateway.InitialiseOracleDatabase();
        }
    }
}
