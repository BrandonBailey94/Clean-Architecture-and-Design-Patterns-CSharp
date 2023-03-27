namespace Assignment.Controllers
{
    public class Controller_Factory
    {
        public Controller_Factory()
        {

        }

        public IController createController(int menuCommandCode)
        {
            switch (menuCommandCode)
            {
                case IController.ADD_ITEM_TO_STOCK:
                    return new AddItemController();
                case IController.ADD_QUANTITY_TO_ITEM:
                    return new AddQuantityControllers();
                case IController.TAKE_QUANTITY_FROM_ITEM:
                    return new TakeQuantityControllers();
                case IController.VIEW_INVENTORY_REPORT:
                    return new ViewInventoryController();
                case IController.VIEW_FINANCIAL_REPORT:
                    return new ViewFinancialController();
                case IController.VIEW_TRANSACTION_LOG:
                    return new ViewTransactionController();
                case IController.VIEW_PERSONAL_USAGE_REPORT:
                    return new ViewPersonalUsageController();
                case IController.INITIALISE_DATABASE:
                    return new InitialiseDatabaseController();
                default:
                    return new NullController();
            }
        }
    }
}
