using Assignment.UseCases;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    class ViewTransactionController : IController
    {
        public ViewTransactionController()
        {

        }

        public List<string> Execute()
        {
            return
                new ViewTransactionLog_Command().Execute().GetViewData();
        }
    }
}
