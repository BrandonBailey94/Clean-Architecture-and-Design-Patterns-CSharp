using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataGateway
{
    public class InitialisationGateway : OracleDatabaseGateway
    {

        protected override string InsertionSQL { get; } = "";

        private OracleCommand createEmployeeSeq = new OracleCommand
        {
            CommandText = "CREATE SEQUENCE CCCP_Employee_Seq START WITH 1 INCREMENT BY 1",
            CommandType = CommandType.Text
        };

        private OracleCommand createItemSeq = new OracleCommand
        {
            CommandText = "CREATE SEQUENCE CCCP_Item_Seq START WITH 1 INCREMENT BY 1",
            CommandType = CommandType.Text
        };

        private OracleCommand dropEmployeeSeq = new OracleCommand
        {
            CommandText = "DROP SEQUENCE CCCP_Employee_Seq",
            CommandType = CommandType.Text
        };

        private OracleCommand createEmployeeTable = new OracleCommand
        {
            CommandText = "CREATE TABLE CCCP_Employee(id number primary key, employeename varchar2(20) not null)",
            CommandType = CommandType.Text
        };

        private OracleCommand dropItemSeq = new OracleCommand
        {
            CommandText = "DROP SEQUENCE CCCP_Item_Seq",
            CommandType = CommandType.Text
        };

        private OracleCommand createItemTable = new OracleCommand
        {
            CommandText = "CREATE TABLE CCCP_Item (id number primary key, itemid number not null, itemname varchar2(20) not null, itemquantity number not null, datecreated DATE not null)",
            CommandType = CommandType.Text
        };

        private OracleCommand createTransactionSeq = new OracleCommand
        {
            CommandText = "CREATE SEQUENCE CCCP_Transaction_Seq START WITH 1 INCREMENT BY 1",
            CommandType = CommandType.Text
        };

        private OracleCommand dropTransactionSeq = new OracleCommand
        {
            CommandText = "DROP SEQUENCE CCCP_Transaction_Seq",
            CommandType = CommandType.Text
        };

        private OracleCommand createTransactionTable = new OracleCommand
        {
            CommandText = "CREATE TABLE CCCP_Transaction(id number primary key, ttype varchar2(64) not null, itemid number not null, itemname varchar2(20) not null, itemprice number not null, itemquantity number not null, employeename varchar2(20) not null, dateadded DATE not null)",
            CommandType = CommandType.Text
        };

        private OracleCommand dropEmployeeTable = new OracleCommand
        {
            CommandText = "DROP TABLE CCCP_Employee",
            CommandType = CommandType.Text
        };


        private OracleCommand dropItemTable = new OracleCommand
        {
            CommandText = "DROP TABLE CCCP_Item",
            CommandType = CommandType.Text
        };

        private OracleCommand dropTransactionTable = new OracleCommand
        {
            CommandText = "DROP TABLE CCCP_Transaction",
            CommandType = CommandType.Text
        };

        private List<OracleCommand> commandSequence;

        public InitialisationGateway()
        {
            commandSequence = new List<OracleCommand>()
            {
                dropEmployeeTable,
                dropEmployeeSeq,

                dropItemTable,
                dropItemSeq,

                dropTransactionTable,
                dropTransactionSeq,

                createEmployeeTable,
                createEmployeeSeq,

                createItemTable,
                createItemSeq,

                createTransactionTable,
                createTransactionSeq
            };
        }

        public void InitialiseOracleDatabase()
        {
            OracleConnection conn = GetOracleConnection();

            foreach (OracleCommand c in commandSequence)
            {
                try
                {
                    c.Connection = conn;
                    Console.WriteLine(c.CommandText);
                    c.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("ERROR: SQL command failed\n" + e.StackTrace, e);
                }
            }

            CloseOracleConnection(conn);
        }

        protected override void DoInsertion(OracleCommand command, object objectToInsert)
        {
            throw new NotImplementedException();
        }
    }
}
