using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace DataGateway
{
    public abstract class OracleDatabaseGateway
    {
        private OracleDatabaseConnectionPool connectionPool;

        protected abstract string InsertionSQL { get; }

        public OracleDatabaseGateway()
        {
            connectionPool = OracleDatabaseConnectionPool.GetInstance();
        }

        protected void CloseOracleConnection(OracleConnection conn)
        {
            connectionPool.ReleaseConnection(conn);
        }

        protected OracleConnection GetOracleConnection()
        {
            return connectionPool.AcquireConnection();
        }

        // This implements the Template Method design pattern
        public void Insert(Object objectToInsert)
        {
            OracleConnection conn = GetOracleConnection();

            OracleCommand command = new OracleCommand
            {
                Connection = conn,
                CommandText = InsertionSQL,
                CommandType = CommandType.Text
            };

            try
            {
                DoInsertion(command, objectToInsert);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            CloseOracleConnection(conn);
        }

        protected abstract void DoInsertion(OracleCommand command, Object objectToInsert);
    }
}