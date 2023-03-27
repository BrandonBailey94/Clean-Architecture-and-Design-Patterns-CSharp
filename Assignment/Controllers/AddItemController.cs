using Assignment.UseCases;
using DataGateway;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    public class AddItemController : IController
    {
        public AddItemController()
        {

        }

        public List<string> Execute()
        {
            string employeeName = ConsoleReader.ReadString("\nEmployee Name");
            int itemId = ConsoleReader.ReadInteger("Item ID");
            string itemName = ConsoleReader.ReadString("Item Name");
            int itemQuantity = ConsoleReader.ReadInteger("Item Quantity");
            double itemPrice = ConsoleReader.ReadDouble("Item Price");

            return
                new AddItemToStock_Command(employeeName, itemId, itemName, itemQuantity, itemPrice, new DataGatewayFacade())
                .Execute()
                .GetViewData();
        }
    }
}
