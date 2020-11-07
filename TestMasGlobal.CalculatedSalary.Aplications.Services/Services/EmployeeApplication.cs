using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Dto;
using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Interfaces;
using TestMasGlobal.CalculatedSalary.Aplications.Services.Base;
using TestMasGlobal.CalculatedSalary.Aplications.Services.Helpers;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Entities.Dto;
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

        public async Task<Response<EmployeeDto>> GetEmployee(int id)
        {
            return await AplicacionesGenerico.TryAsync(
              async () =>
              {
                  return await this.employeeService.GetEmployee(id);
              });
        }

        public async Task<Response<IEnumerable<EmployeeDto>>> GetEmployeeAll()
        {
            return await AplicacionesGenerico.TryAsync(
             async () =>
             {
                 return await this.employeeService.GetEmployeeAll();
             });
        }
    }
}
