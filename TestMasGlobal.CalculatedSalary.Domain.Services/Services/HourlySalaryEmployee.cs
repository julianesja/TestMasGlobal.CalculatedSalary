using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Entities.Dto;
using TestMasGlobal.CalculatedSalary.Domain.Services.Base;

namespace TestMasGlobal.CalculatedSalary.Domain.Services.Services
{
    public class HourlySalaryEmployee : ISalaryEmployee
    {
        public EmployeeDto GetEmployeeDto(Employee employee)
        {
            return new EmployeeDto
            {
                ContractTypeName = employee.ContractTypeName,
                HourlySalary = employee.HourlySalary,
                MonthlySalary = employee.MonthlySalary,
                Name = employee.Name,
                RoleDescription = employee.RoleDescription,
                RoleId = employee.RoleId,
                RoleName = employee.RoleName,
                AnnualSalary = 120 * employee.HourlySalary * 12
            };
        }
    }
}
