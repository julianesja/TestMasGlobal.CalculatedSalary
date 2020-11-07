using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Entities.Dto;

namespace TestMasGlobal.CalculatedSalary.Domain.Services.Base
{
    public interface ISalaryEmployee
    {
        EmployeeDto GetEmployeeDto(Employee employee);
    }
}
