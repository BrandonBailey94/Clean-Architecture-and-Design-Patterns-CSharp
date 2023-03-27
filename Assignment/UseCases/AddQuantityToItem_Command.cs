using Assignment.Entity;
using Assignment.Presenters;
using DataGateway;
using System;

namespace Assignment.UseCases
{
    public class AddQuantityToItem_Command
    {
        private readonly IGatewayFacade gatewayFacade;
        public int quantityToAdd;
        public string employeeName;
        public int itemId;
        public double newItemPrice;
        public AddQuantityToItem_Command(int quantityToAdd, string employeeName, int itemId, double newItemPrice, IGatewayFacade gatewayFacade)
        {
            this.gatewayFacade = gatewayFacade;
            this.quantityToAdd = quantityToAdd;
            this.itemId = itemId;
            this.employeeName = employeeName;
            this.newItemPrice = newItemPrice;
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

                gatewayFacade.AddQuantity(quantityToAdd, itemId);

                gatewayFacade.AddTransaction(
                    new TransactionLogEntry("Quantity Added", item.ID, item.Name, newItemPrice, quantityToAdd, employeeName, DateTime.Now));

                return new AddQuantityPresenter(quantityToAdd, itemId);
            }
            catch (Exception e)
            {
                return new MessagePresenter(e.Message);
            }
        }
    }
}
