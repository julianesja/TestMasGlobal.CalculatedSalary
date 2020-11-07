using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Entities.Dto;
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

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            var employee = await this.employeeRepository.GetById(id);
            if(employee != null)
            {
                return  FactoryEmployee.GetEmployeeDto(employee);
            }
            return null;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeeAll()
        {
            var employees = await this.employeeRepository.GetAll();
            if (employees.Count() > 0)
            {
                return employees.Select(e => FactoryEmployee.GetEmployeeDto(e));
            }
            return null;
        }
    }
}
