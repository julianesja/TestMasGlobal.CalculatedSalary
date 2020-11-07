using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces;
using TestMasGlobal.CalculatedSalary.Test.Service;

namespace TestMasGlobal.CalculatedSalary.Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void ShuldGetEmployees()
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();

            var employees =  employeeRepository.GetAll().Result;

            Assert.IsTrue(employees.Count() > 0);

        }
    }
}
