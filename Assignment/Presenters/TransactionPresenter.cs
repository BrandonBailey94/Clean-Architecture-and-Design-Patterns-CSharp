using Assignment.DTO;
using System.Collections.Generic;

namespace Assignment.Presenters
{
    public class TransactionPresenter : IPresenter
    {
        private List<TransactionDTO> transactions;

        public TransactionPresenter(List<TransactionDTO> transactions)
        {
            this.transactions = transactions;
        }

        public List<string> GetViewData()
        {
            List<string> lines = new List<string>
            {
                "\nTransaction Log:",
                string.Format(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Quantity",
                "Employee",
                "Price")
            };

            foreach (TransactionDTO entry in transactions)
            {
                lines.Add(string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    entry.DateAdded.ToString("dd/MM/yyyy"),
                    entry.TypeOfTransaction,
                    entry.ItemID,
                    entry.ItemName,
                    entry.Quantity,
                    entry.EmployeeName,
                    entry.TypeOfTransaction.Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}", entry.ItemPrice),
                    entry.TypeOfTransaction.Equals("Quantity Added") ? "" : "" + string.Format("{0:C}", entry.ItemPrice)));
            }
            return lines;
        }
    }
}
