using Assignment.DTO;
using System.Collections.Generic;

namespace Assignment.Presenters
{
    public class FinancialPresenter : IPresenter
    {
        private List<TransactionDTO> transactions;

        public FinancialPresenter(List<TransactionDTO> transactions)
        {
            this.transactions = transactions;
        }

        public List<string> GetViewData()
        {
            double total = 0;

            List<string> lines = new List<string>
            {
                "\nFinancial Report:"
            };

            foreach (TransactionDTO dto in transactions)
            {
                double cost = dto.ItemPrice * dto.Quantity;
                lines.Add(string.Format("{0}: Total price of item: {1:C}", dto.ItemName, cost));
                total += cost;

            }

            lines.Add(string.Format("{0}: {1:C}", "Total price of all items", total));

            return lines;
        }
    }
}
