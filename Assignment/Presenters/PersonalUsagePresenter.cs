using Assignment.DTO;
using System.Collections.Generic;

namespace Assignment.Presenters
{
    public class PersonalUsagePresenter : IPresenter
    {
        private List<TransactionDTO> transactions;
        private string name;

        public PersonalUsagePresenter(List<TransactionDTO> transactions, string name)
        {
            this.transactions = transactions;
            this.name = name;
        }

        public List<string> GetViewData()
        {
            List<string> lines = new List<string>
            {
                string.Format("\nPersonal Usage Report for {0}", name),
                string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                "Date Taken",
                "ID",
                "Name",
                "Quantity Removed")
            };

            foreach (TransactionDTO dto in transactions)
            {
                lines.Add(string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                dto.DateAdded,
                dto.ItemID,
                dto.ItemName,
                dto.Quantity));
            }
            return lines;
        }
    }
}
