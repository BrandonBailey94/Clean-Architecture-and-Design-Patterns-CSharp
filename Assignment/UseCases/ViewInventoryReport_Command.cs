using Assignment.Entity;
using Assignment.DTO;
using Assignment.Presenters;
using DataGateway;
using System.Collections.Generic;

namespace Assignment.UseCases
{
    public class ViewInventoryReport_Command
    {
        private readonly DataGatewayFacade gatewayFacade;
        public ViewInventoryReport_Command()
        {
            gatewayFacade = new DataGatewayFacade();
        }

        public List<Item> GetInventoryReportItems()
        {

            List<Item> items = new List<Item> { };

            foreach (Item entry in gatewayFacade.GetAllItems())
            {
                items.Add(entry);
            }

            return items;
        }

        public IPresenter Execute()
        {
            List<ItemDTO> dtos = new List<ItemDTO>();

            foreach (Item entry in GetInventoryReportItems())
            {
                dtos.Add(new ItemDTO(entry));
            }
            return new InventoryPresenter(dtos);
        }
    }
}
