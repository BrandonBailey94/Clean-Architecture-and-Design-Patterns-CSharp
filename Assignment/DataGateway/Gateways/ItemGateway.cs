using Assignment.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataGateway
{
    public class ItemGateway : OracleDatabaseGateway
    {

        protected override string InsertionSQL { get; }
            = "INSERT INTO CCCP_Item (id, itemid, itemname, itemquantity, datecreated) " +
                "VALUES (CCCP_ITEM_SEQ.nextval, :itemid, :itemname, :itemquantity, :datecreated)";

        public ItemGateway()
        {
        }

        protected override void DoInsertion(OracleCommand command, Object objectToInsert)
        {
            Item i = (Item)objectToInsert;

            command.Prepare();
            command.Parameters.Add(":itemid", i.ID);
            command.Parameters.Add(":itemname", i.Name);
            command.Parameters.Add(":itemquantity", i.Quantity);
            command.Parameters.Add(":datecreated", i.DateCreated);
            Console.WriteLine(command.CommandText);
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: Item not inserted");
            }
        }

        public Item FindItem(int itemID)
        {
            Item item = null;

            OracleConnection conn = GetOracleConnection();

            OracleCommand findItemById = new OracleCommand
            {
                Connection = conn,
                CommandText = "SELECT itemid, itemname, itemquantity, datecreated FROM CCCP_Item WHERE CCCP_Item.itemid = :itemID",
                CommandType = CommandType.Text
            };

            try
            {
                findItemById.Prepare();
                findItemById.Parameters.Add(":itemid", itemID);
                OracleDataReader dr = findItemById.ExecuteReader();

                if (dr.Read())
                {
                    item = new Item(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetDateTime(3));
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of item failed", e);
            }

            CloseOracleConnection(conn);

            return item;
        }

        public void AddQuantity(int addQuantity, int itemid)
        {
            OracleConnection conn = GetOracleConnection();

            OracleCommand updateItemQuantity = new OracleCommand
            {
                Connection = conn,
                CommandText = "UPDATE CCCP_Item SET itemquantity = itemquantity + :addQuantity WHERE itemid = :id",
                CommandType = CommandType.Text
            };

            try
            {
                updateItemQuantity.Prepare();
                updateItemQuantity.Parameters.Add(":itemquantity", addQuantity);
                updateItemQuantity.Parameters.Add(":id", itemid);
                int numRowsAffected = updateItemQuantity.ExecuteNonQuery();

                if (numRowsAffected != 1)
                {
                    throw new Exception("ERROR: quantity not updated");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            CloseOracleConnection(conn);
        }

        public void RemoveQuantity(int removeQuantity, int itemid)
        {
            OracleConnection conn = GetOracleConnection();

            OracleCommand updateItemQuantity = new OracleCommand
            {
                Connection = conn,
                CommandText = "UPDATE CCCP_Item SET itemquantity = itemquantity - :removeQuantity WHERE itemid = :id",
                CommandType = CommandType.Text
            };

            try
            {
                updateItemQuantity.Prepare();
                updateItemQuantity.Parameters.Add(":itemquantity", removeQuantity);
                updateItemQuantity.Parameters.Add(":id", itemid);
                int numRowsAffected = updateItemQuantity.ExecuteNonQuery();

                if (numRowsAffected != 1)
                {
                    throw new Exception("ERROR: quantity not updated");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            CloseOracleConnection(conn);
        }

        public List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();

            OracleConnection conn = GetOracleConnection();

            OracleCommand findAllItems = new OracleCommand
            {
                Connection = conn,
                CommandText = "SELECT itemid, itemname, itemquantity, datecreated FROM CCCP_Item",
                CommandType = CommandType.Text
            };

            try
            {
                OracleDataReader dr = findAllItems.ExecuteReader();

                while (dr.Read())
                {
                    Item item = new Item(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetDateTime(3));
                    items.Add(item);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of items failed", e);
            }

            CloseOracleConnection(conn);

            return items;
        }

        public void DeleteAllItems()
        {
            OracleConnection conn = GetOracleConnection();

            OracleCommand deleteAllItems = new OracleCommand
            {
                Connection = conn,
                CommandText = "DELETE FROM CCCP_Item",
                CommandType = CommandType.Text
            };

            try
            {
                int numberOfRows = deleteAllItems.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("ERROR: Failed to delete all items", e);
            }

            CloseOracleConnection(conn);
        }
    }
}
