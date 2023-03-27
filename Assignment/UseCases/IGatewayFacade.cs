using Assignment.Entity;
using System.Collections.Generic;

namespace Assignment.UseCases
{
    public interface IGatewayFacade
    {
        public void AddItem(Item i);

        public void AddEmployee(Employee e);

        public void AddTransaction(TransactionLogEntry t);

        public void AddQuantity(int addQuantity, int itemId);

        public void RemoveQuantity(int removeQuantity, int itemId);

        public Item FindItem(int itemId);

        public Employee FindEmployee(string employeeName);

        public List<Item> GetAllItems();

        public List<Employee> GetAllEmployees();

        public List<TransactionLogEntry> GetAllTransactions();

        public void InitialiseOracleDatabase();
    }
}
