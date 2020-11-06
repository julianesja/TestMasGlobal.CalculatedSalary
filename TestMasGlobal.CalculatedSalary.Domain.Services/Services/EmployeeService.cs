using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Services;
using TestMasGlobal.CalculatedSalary.Domain.Services.Base;

namespace TestMasGlobal.CalculatedSalary.Domain.Services.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
    }
}
