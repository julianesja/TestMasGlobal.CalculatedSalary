namespace TestMasGlobal.CalculatedSalary.Domain.Interfaces.Base
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestMasGlobal.CalculatedSalary.Domain.Entities;

    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        Task<Entity> GetById(int id);

        Task<IEnumerable<Entity>> GetAll();
    }
}
