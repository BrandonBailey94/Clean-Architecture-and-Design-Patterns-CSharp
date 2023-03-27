using System;
using System.Collections.Generic;

namespace Assignment.Presenters
{
    public class AddQuantityPresenter : IPresenter
    {
        private int quantityToAdd;
        private int itemId;
        public AddQuantityPresenter(int quantityToAdd, int itemId)
        {
            this.quantityToAdd = quantityToAdd;
            this.itemId = itemId;
        }

        public List<string> GetViewData()
        {
            List<string> lines = new List<string> { };

            lines.Add(string.Format(
                "{0} items have been added to Item ID: {1} on {2}",
                quantityToAdd,
                itemId,
                DateTime.Now.ToString("dd/MM/yyyy")));

            return lines;
        }
    }
}
