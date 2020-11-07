using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Entities.Dto;
using TestMasGlobal.CalculatedSalary.Domain.Services.Base;

namespace TestMasGlobal.CalculatedSalary.Domain.Services.Services
{
    public static class FactoryEmployee
    {
        public static EmployeeDto GetEmployeeDto(Employee employee)
        {
            ISalaryEmployee salaryEmployee;
            if (employee.ContractTypeName == "HourlySalaryEmployee")
            {
                salaryEmployee = new HourlySalaryEmployee();
                return salaryEmployee.GetEmployeeDto(employee);
            }
            else if (employee.ContractTypeName == "MonthlySalaryEmployee")
            {
                salaryEmployee = new MonthlySalaryEmployee();
                return salaryEmployee.GetEmployeeDto(employee);
            }
            else
            {
                return null;
            }
        }

    }

  
}
