using Assignment.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataGateway
{
    public class EmployeeGateway : OracleDatabaseGateway
    {

        protected override string InsertionSQL { get; }
            = "INSERT INTO CCCP_Employee (id, employeename) VALUES (CCCP_EMPLOYEE_SEQ.nextval, :employeename)";

        public EmployeeGateway()
        {
        }

        protected override void DoInsertion(OracleCommand command, Object objectToInsert)
        {
            Employee e = (Employee)objectToInsert;

            command.Prepare();
            command.Parameters.Add(":employeename", e.EmpName);
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: employee not inserted");
            }
        }

        public Employee FindEmployee(string employeeName)
        {
            Employee employee = null;

            OracleConnection conn = GetOracleConnection();

            OracleCommand findEmployeeByName = new OracleCommand
            {
                Connection = conn,
                CommandText = "SELECT id, employeename FROM CCCP_Employee WHERE employeename = :employeeName",
                CommandType = CommandType.Text
            };

            try
            {
                findEmployeeByName.Prepare();
                findEmployeeByName.Parameters.Add(":employeename", employeeName);
                OracleDataReader dr = findEmployeeByName.ExecuteReader();

                if (dr.Read())
                {
                    employee = new Employee(dr.GetString(1));
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of employee failed", e);
            }

            CloseOracleConnection(conn);

            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            OracleConnection conn = GetOracleConnection();

            OracleCommand findAllEmployees = new OracleCommand
            {
                Connection = conn,
                CommandText = "SELECT id, employeename FROM CCCP_Employee",
                CommandType = CommandType.Text
            };

            try
            {
                OracleDataReader dr = findAllEmployees.ExecuteReader();

                while (dr.Read())
                {
                    Employee member = new Employee(dr.GetString(1));
                    employees.Add(member);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of employees failed", e);
            }

            CloseOracleConnection(conn);

            return employees;
        }

        public void DeleteAllEmployees()
        {
            OracleConnection conn = GetOracleConnection();

            OracleCommand deleteAllEmployees = new OracleCommand
            {
                Connection = conn,
                CommandText = "DELETE FROM CCCP_Employee",
                CommandType = CommandType.Text
            };

            try
            {
                OracleDataReader dr = deleteAllEmployees.ExecuteReader();

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: Failed to delete all employees", e);
            }

            CloseOracleConnection(conn);
        }
    }
}
