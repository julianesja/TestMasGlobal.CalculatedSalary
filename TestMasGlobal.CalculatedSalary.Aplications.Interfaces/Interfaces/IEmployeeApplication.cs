using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Base;
using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Dto;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Entities.Dto;

namespace TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Interfaces
{
    public interface IEmployeeApplication: IBaseAplication<Employee>
    {
        Task<Response<EmployeeDto>> GetEmployee(int id);

        Task<Response<IEnumerable<EmployeeDto>>> GetEmployeeAll();
    }
}
