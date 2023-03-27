using Assignment.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AssignmentTests.EntityTests
{
    [TestClass]
    public class AddQuantityPresenterTests
    {
        [TestMethod]
        public void TestNewEmployeeNameIsSetAndIsCorrect()
        {
            Employee employee_name = new Employee("Brandon");
            Assert.AreEqual("Brandon", employee_name.EmpName);
        }

        [TestMethod]
        public void TestBlankEmployeeNameGivesException()
        {
            Assert.ThrowsException<Exception>(() => new Employee(""));
        }

        [TestMethod]
        public void TestBlankEmployeeNameGivesCorrectExceptionMessage()
        {
            try
            {
                Employee employee = new Employee("");
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Employee name is blank; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }

        [TestMethod]
        public void TestEmployeeNameIsNotGreaterThan20Characters()
        {
            Employee employee_name = new Employee("Brandon");
            Assert.IsTrue(employee_name.EmpName.Length <= 20);
        }

        [TestMethod]
        public void TestIfEmployeeNameIsGreaterThan20CharactersThrowException()
        {
            Assert.ThrowsException<Exception>(() => new Employee("BrandonBrandonBrandon"));
        }

        [TestMethod]
        public void TestIfEmployeeNameIsGreaterThan20CharactersThrowCorrectExceptionMessage()
        {
            try
            {
                Employee employee = new Employee("BrandonBrandonBrandon");
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Employee name is greater than 20 characters; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }

        [TestMethod]
        public void TestEmployeeNameDoesNotContainsSpecialCharacters()
        {
            Employee emp_name = new Employee("Brandon");
            Assert.IsFalse(emp_name.EmpName.Any(ch => !char.IsLetterOrDigit(ch)));
        }

        [TestMethod]
        public void TestEmployeeNameDoesContainsSpecialCharactersThrowException()
        {
            Assert.ThrowsException<Exception>(() => new Employee("Bran*don"));
        }


        [TestMethod]
        public void TestEmployeeNameDoesContainsSpecialCharactersThrowCorrectExceptionMessage()
        {
            try
            {
                Employee employee = new Employee("Bran*don");
            }
            catch (Exception e)
            {
                string expectedErrorMsg =
                    "ERROR: Employee name cannot contain special characters; ";
                Assert.AreEqual(expectedErrorMsg, e.Message);
                return;
            }
        }
    }
}
