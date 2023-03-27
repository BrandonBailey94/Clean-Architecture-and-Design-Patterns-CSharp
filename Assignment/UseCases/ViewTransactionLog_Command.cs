using Assignment.Entity;
using Assignment.DTO;
using Assignment.Presenters;
using DataGateway;
using System.Collections.Generic;

namespace Assignment.UseCases
{
    public class ViewTransactionLog_Command
    {
        private readonly DataGatewayFacade gatewayFacade;
        public ViewTransactionLog_Command()
        {
            gatewayFacade = new DataGatewayFacade();
        }

        public List<TransactionLogEntry> GetTransactionReportTransactions()
        {

            List<TransactionLogEntry> transactions = new List<TransactionLogEntry> { };

            foreach (TransactionLogEntry entry in gatewayFacade.GetAllTransactions())
            {
                transactions.Add(entry);
            }

            return transactions;
        }
        public IPresenter Execute()
        {
            List<TransactionDTO> dtos = new List<TransactionDTO>();

            foreach (TransactionLogEntry entry in GetTransactionReportTransactions())
            {
                dtos.Add(new TransactionDTO(entry));
            }

            return new TransactionPresenter(dtos);
        }
    }
}
