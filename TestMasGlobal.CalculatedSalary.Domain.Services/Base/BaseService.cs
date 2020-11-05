using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Base;

namespace TestMasGlobal.CalculatedSalary.Domain.Services.Base
{
    public class BaseService<Entity> : IBaseService<Entity>
        where Entity : BaseEntity
    {
        private readonly IBaseRepository<Entity> baseRepository;

        public BaseService(IBaseRepository<Entity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public virtual Task<Entity> GetById(int id)
        {
           return this.baseRepository.GetById(id);
        }

        public virtual Task<IEnumerable<Entity>> GetAll()
        {
            return this.baseRepository.GetAll();
        }
    }
}
