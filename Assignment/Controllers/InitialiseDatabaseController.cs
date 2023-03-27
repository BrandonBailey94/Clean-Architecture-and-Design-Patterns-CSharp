using Assignment.UseCases;
using DataGateway;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    class InitialiseDatabaseController : IController
    {
        public InitialiseDatabaseController()
        {

        }

        public List<string> Execute()
        {
            return
                new InitialiseDatabase_Command(new DataGatewayFacade())
                .Execute()
                .GetViewData();
        }
    }
}
