using Assignment.Entity;
using Assignment.Presenters;
using DataGateway;
using System;

namespace Assignment.UseCases
{
    public class InitialiseDatabase_Command
    {
        private readonly IGatewayFacade gatewayFacade;

        public InitialiseDatabase_Command(IGatewayFacade gatewayFacade)
        {
            this.gatewayFacade = gatewayFacade;
        }

        public IPresenter Execute()
        {
            gatewayFacade.InitialiseOracleDatabase();

            gatewayFacade.AddEmployee(new Employee("Brandon"));

            gatewayFacade.AddItem(new Item(1, "Pencil", 10, DateTime.Now));
            gatewayFacade.AddItem(new Item(2, "Eraser", 20, DateTime.Now));

            gatewayFacade.AddTransaction(new TransactionLogEntry("Item Added", 1, "Pencil", 0.40, 10, "Brandon", DateTime.Now));
            gatewayFacade.AddTransaction(new TransactionLogEntry("Item Added", 2, "Eraser", 0.20, 20, "Brandon", DateTime.Now));

            gatewayFacade.RemoveQuantity(1, 2);
            gatewayFacade.AddTransaction(new TransactionLogEntry("Quantity Removed", 2, "Eraser", 0.20, 1, "Brandon", DateTime.Now));


            gatewayFacade.AddQuantity(1, 1);
            gatewayFacade.AddTransaction(new TransactionLogEntry("Quantity Added", 1, "Pencil", 0.40, 1, "Brandon", DateTime.Now));

            return new NullPresenter();
        }
    }
}
