using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Entities.Dto;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Base;

namespace TestMasGlobal.CalculatedSalary.Domain.Interfaces.Services
{
    public interface IEmployeeService: IBaseService<Employee>
    {
        Task<EmployeeDto> GetEmployee(int id);

        Task<IEnumerable<EmployeeDto>> GetEmployeeAll();
    }
}
