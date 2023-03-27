using System.Collections.Generic;
using Assignment.Entity;
using Assignment.DTO;
using DataGateway;
using Assignment.Presenters;

namespace Assignment.UseCases
{
    public class ViewFinanicalReport_Command
    {
        private readonly DataGatewayFacade gatewayFacade;
        public ViewFinanicalReport_Command()
        {
            gatewayFacade = new DataGatewayFacade();
        }

        private List<TransactionLogEntry> GetFinancialReportTransactions()
        {

            List<TransactionLogEntry> transactions = new List<TransactionLogEntry> { };

            foreach (TransactionLogEntry entry in gatewayFacade.GetAllTransactions())
            {

                if (entry.TypeOfTransaction.Equals("Item Added")
                    || entry.TypeOfTransaction.Equals("Quantity Added"))
                {
                    double cost = entry.ItemPrice * entry.Quantity;
                    transactions.Add(entry);
                }
            }

            return transactions;
        }

        public IPresenter Execute()
        {
            List<TransactionDTO> dtos = new List<TransactionDTO>();

            foreach (TransactionLogEntry entry in GetFinancialReportTransactions())
            {
                dtos.Add(new TransactionDTO(entry));
            }

            return new FinancialPresenter(dtos);
        }
    }
}
