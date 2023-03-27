using System;
using System.Collections.Generic;

namespace Assignment.Presenters
{
    public class TakeQuantityPresenter : IPresenter
    {
        private string employeeName;
        private int quantityToRemove;
        private int itemId;
        public TakeQuantityPresenter(string employeeName, int quantityToRemove, int itemId)
        {
            this.quantityToRemove = quantityToRemove;
            this.itemId = itemId;
            this.employeeName = employeeName;
        }

        public List<string> GetViewData()
        {
            List<string> lines = new List<string> { };

            lines.Add(string.Format(
                    "{0} has removed {1} of Item ID: {2} on {3}",
                    employeeName,
                    quantityToRemove,
                    itemId,
                    DateTime.Now.ToString("dd/MM/yyyy")));

            return lines;
        }
    }
}
