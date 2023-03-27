using Assignment.Entity;
using System;

namespace Assignment.DTO
{
    [Serializable]
    public class ItemDTO
    {
        public Item item { get; }
        public int ID { get; }
        public string Name { get; }
        public int Quantity { get; }
        public DateTime DateCreated { get; }

        public ItemDTO(Item item)
        {
            this.item = item;
            this.ID = item.ID;
            this.Name = item.Name;
            this.Quantity = item.Quantity;
            this.DateCreated = item.DateCreated;
        }
    }
}
