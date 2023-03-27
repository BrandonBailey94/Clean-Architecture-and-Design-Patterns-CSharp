using Assignment.UseCases;
using DataGateway;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    class TakeQuantityControllers : IController
    {
        public TakeQuantityControllers()
        {

        }

        public List<string> Execute()
        {
            string employeeName = ConsoleReader.ReadString("\nEmployee Name");
            int itemId = ConsoleReader.ReadInteger("Item ID");
            int quantityToRemove = ConsoleReader.ReadInteger("How many items would you like to remove?");

            return
                new TakeQuantityFromItem_Command(employeeName, itemId, quantityToRemove, new DataGatewayFacade())
                .Execute()
                .GetViewData();
        }
    }
}
