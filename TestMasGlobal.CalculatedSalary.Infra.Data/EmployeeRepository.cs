using Microsoft.Extensions.Configuration;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces;
using TestMasGlobal.CalculatedSalary.Infra.Data.Base;
using TestMasGlobal.CalculatedSalary.Infra.Data.DataContextDatabases;

namespace TestMasGlobal.CalculatedSalary.Infra.Data
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConexionApi<Employee> conexionApi, IConfiguration configuration) : base(conexionApi, configuration, "Employees")
        {
        }
    }
}
