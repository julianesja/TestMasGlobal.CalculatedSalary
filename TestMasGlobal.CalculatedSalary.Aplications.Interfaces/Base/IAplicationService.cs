using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Dto;
using TestMasGlobal.CalculatedSalary.Domain.Entities;

namespace TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Base
{
    public interface IAplicationService<Entity> where Entity : BaseEntity
    {
        Task<Response<Entity>> GetById(int Id);

        Task<Response<IEnumerable<Entity>>> GetAll();
    }
}
