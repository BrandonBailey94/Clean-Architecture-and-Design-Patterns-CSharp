using System.Collections.Generic;

namespace Assignment.Controllers
{
    public interface IController
    {
        public const int ADD_ITEM_TO_STOCK = 1;
        public const int ADD_QUANTITY_TO_ITEM = 2;
        public const int TAKE_QUANTITY_FROM_ITEM = 3;
        public const int VIEW_INVENTORY_REPORT = 4;
        public const int VIEW_FINANCIAL_REPORT = 5;
        public const int VIEW_TRANSACTION_LOG = 6;
        public const int VIEW_PERSONAL_USAGE_REPORT = 7;
        public const int EXIT = 8;
        public const int INITIALISE_DATABASE = 9;

        public List<string> Execute();
    }
}
