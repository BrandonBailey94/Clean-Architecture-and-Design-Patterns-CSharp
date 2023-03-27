using Assignment.Entity;
using System;

namespace Assignment.DTO
{
    [Serializable]
    public class TransactionDTO
    {
        public TransactionLogEntry trans { get; }
        public string TypeOfTransaction { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateAdded { get; set; }

        public TransactionDTO(TransactionLogEntry trans)
        {
            this.trans = trans;
            this.TypeOfTransaction = trans.TypeOfTransaction;
            this.ItemID = trans.ItemID;
            this.ItemName = trans.ItemName;
            this.ItemPrice = trans.ItemPrice;
            this.Quantity = trans.Quantity;
            this.EmployeeName = trans.EmployeeName;
            this.DateAdded = trans.DateAdded;
        }
    }
}
