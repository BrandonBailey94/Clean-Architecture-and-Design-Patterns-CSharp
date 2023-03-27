using System;

namespace Assignment.Entity
{
    public class Item
    {
        public int ID { get; }
        public string Name { get; }
        public int Quantity { get; }
        public DateTime DateCreated { get; }

        public Item(int id, string name, int quantity, DateTime dateCreated)
        {
            if (validateValues(id, name, quantity, dateCreated))
            {
                ID = id;
                Name = name;
                Quantity = quantity;
                DateCreated = dateCreated;
            }
        }

        private bool validateValues(int id, string name, int quantity, DateTime dateCreated)
        {
            if (id < 1)
            {
                throw new Exception("ERROR: ID below 1; ");
            }

            if (quantity < 1)
            {
                throw new Exception("ERROR: Quantity below 1; ");
            }

            if (name.Length == 0)
            {
                throw new Exception("ERROR: Item name is empty; ");
            }

            return true;
        }
    }
}
