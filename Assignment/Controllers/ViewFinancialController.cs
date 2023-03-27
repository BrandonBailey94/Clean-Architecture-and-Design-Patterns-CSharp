using Assignment.UseCases;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    class ViewFinancialController : IController
    {
        public ViewFinancialController()
        {

        }

        public List<string> Execute()
        {
            return
                new ViewFinanicalReport_Command().Execute().GetViewData();
        }
    }
}
