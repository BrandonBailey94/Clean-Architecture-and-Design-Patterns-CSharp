using Assignment.DTO;
using System.Collections.Generic;

namespace Assignment.Presenters
{
    public class InventoryPresenter : IPresenter
    {
        private List<ItemDTO> items;

        public InventoryPresenter(List<ItemDTO> items)
        {
            this.items = items;
        }

        public List<string> GetViewData()
        {
            List<string> lines = new List<string>
            {
                "\nAll items",
                string.Format(
                "\t{0, -4} {1, -20} {2, -20}",
                "ID",
                "Name",
                "Quantity")
            };

            foreach (ItemDTO dto in items)
            {
                lines.Add(string.Format(
                    "\t{0, -4} {1, -20} {2, -20}",
                    dto.ID,
                    dto.Name,
                    dto.Quantity));
            }

            return lines;
        }
    }
}
