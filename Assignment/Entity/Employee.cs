using System;
using System.Linq;

namespace Assignment.Entity
{
    public class Employee
    {
        public string EmpName { get; }

        public Employee(string empname)
        {
            if (validateValues(empname))
            {
                EmpName = empname;
            }
        }

        private bool HasSpecialChars(string String)
        {
            return String.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private bool validateValues(string empname)
        {
            if (empname.Length > 20)
            {
                throw new Exception("ERROR: Employee name is greater than 20 characters; ");
            }

            if (HasSpecialChars(empname))
            {
                throw new Exception("ERROR: Employee name cannot contain special characters; ");
            }

            if (empname.Length == 0)
            {
                throw new Exception("ERROR: Employee name is blank; ");
            }
            return true;
        }
    }
}
