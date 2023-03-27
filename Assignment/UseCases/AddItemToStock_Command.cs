using Assignment.Entity;
using Assignment.Presenters;
using DataGateway;
using System;

namespace Assignment.UseCases
{
    public class AddItemToStock_Command
    {
        private readonly IGatewayFacade gatewayFacade;
        private string employeeName;
        private int itemId;
        private string itemName;
        private int itemQuantity;
        private double itemPrice;

        public AddItemToStock_Command(string employeeName, int itemId, string itemName, int itemQuantity, double itemPrice, IGatewayFacade gatewayFacade)
        {
            this.gatewayFacade = gatewayFacade;
            this.employeeName = employeeName;
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemQuantity = itemQuantity;
            this.itemPrice = itemPrice;
        }

        public IPresenter Execute()
        {
            try
            {
                if (gatewayFacade.FindEmployee(employeeName) == null)
                {
                    return new MessagePresenter("ERROR: Employee not found");
                }

                gatewayFacade.AddItem(new Item(itemId, itemName, itemQuantity, DateTime.Now));

                gatewayFacade.AddTransaction(
                    new TransactionLogEntry("Item Added", itemId, itemName, itemPrice, itemQuantity, employeeName, DateTime.Now));

            }
            catch (Exception e)
            {
                return new MessagePresenter(e.Message);
            }
            return new NullPresenter();
        }
    }
}
