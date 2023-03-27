using Assignment.Entity;
using Assignment.DTO;
using Assignment.Presenters;
using DataGateway;
using System.Collections.Generic;

namespace Assignment.UseCases
{
    public class ViewPersonalUsageReport_Command
    {
        private readonly DataGatewayFacade gatewayFacade;
        private string employeeName;
        public ViewPersonalUsageReport_Command(string employeeName)
        {
            gatewayFacade = new DataGatewayFacade();
            this.employeeName = employeeName;
        }

        public List<TransactionLogEntry> GetPersonalUsageReportTransactions()
        {
            List<TransactionLogEntry> transactions = new List<TransactionLogEntry> { };

            foreach (TransactionLogEntry entry in gatewayFacade.GetAllTransactions())
            {
                if (entry.TypeOfTransaction.Equals("Quantity Removed") && entry.EmployeeName == employeeName)
                {
                    transactions.Add(entry);
                }
            }

            return transactions;
        }
        public IPresenter Execute()
        {
            List<TransactionDTO> dtos = new List<TransactionDTO>();

            foreach (TransactionLogEntry entry in GetPersonalUsageReportTransactions())
            {
                dtos.Add(new TransactionDTO(entry));
            }

            return new PersonalUsagePresenter(dtos, employeeName);
        }
    }
}
