using Assignment.UseCases;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    class ViewPersonalUsageController : IController
    {
        public ViewPersonalUsageController()
        {

        }

        public List<string> Execute()
        {

            string employeeName = ConsoleReader.ReadString("Employee name");

            return
                new ViewPersonalUsageReport_Command(employeeName).Execute().GetViewData();
        }
    }
}
