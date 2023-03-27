using Assignment.UseCases;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    class ViewInventoryController : IController
    {
        public ViewInventoryController()
        {

        }

        public List<string> Execute()
        {
            return
                new ViewInventoryReport_Command().Execute().GetViewData();
        }
    }
}
