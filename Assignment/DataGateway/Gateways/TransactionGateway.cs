using Assignment.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace DataGateway
{
    public class TransactionGateway : OracleDatabaseGateway
    {

        protected override string InsertionSQL { get; }
            = "INSERT INTO CCCP_Transaction (id, ttype, itemid, itemname, itemprice, itemquantity, employeename, dateadded) " +
                "VALUES (CCCP_Transaction_Seq.nextval, :ttype, :itemid, :itemname, :itemprice, :qitemuantity, :employeename, :dateadded)";

        public TransactionGateway()
        {
        }

        protected override void DoInsertion(OracleCommand command, Object objectToInsert)
        {
            TransactionLogEntry t = (TransactionLogEntry)objectToInsert;

            command.Prepare();
            command.Parameters.Add(":ttype", t.TypeOfTransaction);
            command.Parameters.Add(":itemid", t.ItemID);
            command.Parameters.Add(":itemname", t.ItemName);
            command.Parameters.Add(":itemprice", t.ItemPrice);
            command.Parameters.Add(":itemquantity", t.Quantity);
            command.Parameters.Add(":employeename", t.EmployeeName);
            command.Parameters.Add(":dateadded", t.DateAdded);
            Console.WriteLine(command.CommandText);
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: Transaction not inserted");
            }
        }

        public List<TransactionLogEntry> GetAllTransactions()
        {
            List<TransactionLogEntry> transactions = new List<TransactionLogEntry>();

            OracleConnection conn = GetOracleConnection();

            OracleCommand findAllTransactions = new OracleCommand
            {
                Connection = conn,
                CommandText = "SELECT ttype, itemid, itemname, itemprice, itemquantity, employeename, dateadded FROM CCCP_Transaction",
                CommandType = CommandType.Text
            };

            try
            {
                OracleDataReader dr = findAllTransactions.ExecuteReader();

                while (dr.Read())
                {
                    TransactionLogEntry transaction = new TransactionLogEntry(dr.GetString(0), dr.GetInt32(1), dr.GetString(2), dr.GetDouble(3), dr.GetInt32(4), dr.GetString(5), dr.GetDateTime(6));
                    transactions.Add(transaction);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of transactions failed", e);
            }

            CloseOracleConnection(conn);

            return transactions;
        }

        public void DeleteAllTransactions()
        {
            OracleConnection conn = GetOracleConnection();

            OracleCommand deleteAllTransactions = new OracleCommand
            {
                Connection = conn,
                CommandText = "DELETE FROM CCCP_Transaction",
                CommandType = CommandType.Text
            };

            try
            {
                int numberOfRows = deleteAllTransactions.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("ERROR: Failed to delete all transactions", e);
            }

            CloseOracleConnection(conn);
        }
    }
}
