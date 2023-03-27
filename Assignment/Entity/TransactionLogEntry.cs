using System;

namespace Assignment.Entity
{
    public class TransactionLogEntry
    {
        public string TypeOfTransaction { get; }
        public int ItemID { get; }
        public string ItemName { get; }
        public double ItemPrice { get; }
        public int Quantity { get; }
        public string EmployeeName { get; }
        public DateTime DateAdded { get; }

        public TransactionLogEntry(string type, int itemID, string itemName, double itemPrice, int quantity, string employeeName, DateTime dateAdded)
        {
            if (ValidateInputs(type, itemID, itemName, itemPrice, quantity, employeeName, dateAdded))
            {
                TypeOfTransaction = type;
                ItemID = itemID;
                ItemName = itemName;
                ItemPrice = itemPrice;
                Quantity = quantity;
                EmployeeName = employeeName;
                DateAdded = dateAdded;
            }
        }

        public bool ValidateInputs(string type, int itemID, string itemName, double itemPrice, int quantity, string employeeName, DateTime dateAdded)
        {
            if (type.Length <= 0)
            {
                throw new Exception("ERROR: Transaction Type Invalid; ");
            }

            if (itemID <= 0)
            {
                throw new Exception("ERROR: Transaction Item ID Invalid; ");
            }

            if (itemName.Length <= 0)
            {
                throw new Exception("ERROR: Transaction Item Name Invalid; ");
            }

            if (itemPrice < 0)
            {
                throw new Exception("ERROR: Transaction Item Price Invalid; ");
            }

            if (quantity < 0)
            {
                throw new Exception("ERROR: Transaction Item Quantity Invalid; ");
            }

            if (employeeName.Length <= 0)
            {
                throw new Exception("ERROR: Transaction Employee Name Invalid; ");
            }

            return true;
        }
    }
}
