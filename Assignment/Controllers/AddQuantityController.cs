using Assignment.UseCases;
using DataGateway;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    class AddQuantityControllers : IController
    {
        public AddQuantityControllers()
        {

        }

        public List<string> Execute()
        {
            string employeeName = ConsoleReader.ReadString("\nEmployee Name");
            int itemId = ConsoleReader.ReadInteger("Item ID");
            int quantityToAdd = ConsoleReader.ReadInteger("How many items would you like to add?");
            double newItemPrice = ConsoleReader.ReadDouble("What is the new price of the item?");

            return
                new AddQuantityToItem_Command(quantityToAdd, employeeName, itemId, newItemPrice, new DataGatewayFacade())
                .Execute()
                .GetViewData();
        }
    }
}
