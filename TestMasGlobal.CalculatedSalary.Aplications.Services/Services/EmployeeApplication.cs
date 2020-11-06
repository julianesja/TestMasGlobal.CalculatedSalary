using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Interfaces;
using TestMasGlobal.CalculatedSalary.Aplications.Services.Base;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Services;

namespace TestMasGlobal.CalculatedSalary.Aplications.Services.Services
{
    public class EmployeeApplication : AplicationService<Employee>, IEmployeeApplication
    {
        private readonly IEmployeeService employeeService;

        public EmployeeApplication(IEmployeeService employeeService) : base(employeeService)
        {
            this.employeeService = employeeService;
        }
    }
}
