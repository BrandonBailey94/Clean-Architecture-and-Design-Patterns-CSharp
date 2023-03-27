using Assignment.Entity;
using Assignment.Presenters;
using DataGateway;
using System;

namespace Assignment.UseCases
{
    public class TakeQuantityFromItem_Command
    {
        private readonly IGatewayFacade gatewayFacade;
        private string employeeName;
        private int itemId;
        private int quantityToRemove;
        public TakeQuantityFromItem_Command(string employeeName, int itemId, int quantityToRemove, IGatewayFacade gatewayFacade)
        {
            this.gatewayFacade = gatewayFacade;
            this.employeeName = employeeName;
            this.itemId = itemId;
            this.quantityToRemove = quantityToRemove;
        }
        public IPresenter Execute()
        {
            try
            {
                if (gatewayFacade.FindEmployee(employeeName) == null)
                {
                    return new MessagePresenter("ERROR: Employee not found");

                }

                Item item = gatewayFacade.FindItem(itemId);
                if (item == null)
                {
                    return new MessagePresenter("ERROR: Item not found");
                }

                gatewayFacade.RemoveQuantity(quantityToRemove, itemId);

                gatewayFacade.AddTransaction(
                    new TransactionLogEntry("Quantity Removed", item.ID, item.Name, 0, quantityToRemove, employeeName, DateTime.Now));

                return new TakeQuantityPresenter(employeeName, quantityToRemove, itemId);
            }
            catch (Exception e)
            {
                return new MessagePresenter(e.Message);
            }
        }
    }
}
