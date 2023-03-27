using Assignment.UseCases;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    class NullController : IController
    {
        public NullController()
        {

        }

        public List<string> Execute()
        {
            return
                new NullCommand().Execute().GetViewData();
        }
    }
}
