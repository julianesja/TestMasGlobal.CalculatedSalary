using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Base;
using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Dto;
using TestMasGlobal.CalculatedSalary.Aplications.Services.Helpers;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Base;

namespace TestMasGlobal.CalculatedSalary.Aplications.Services.Base
{
    public class AplicationService<Entity> : IBaseAplication<Entity> where Entity : BaseEntity
    {
        private readonly IBaseService<Entity> baseService;

        public AplicationService(IBaseService<Entity> baseService)
        {
            this.baseService = baseService;
        }
        public virtual async Task<Response<IEnumerable<Entity>>> GetAll()
        {
            return  await AplicacionesGenerico.TryAsync(
               async () =>
                {
                     return await this.baseService.GetAll();
                });
        }

        public virtual async Task<Response<Entity>> GetById(int Id)
        {
            return await AplicacionesGenerico.TryAsync(
                async () =>
                {
                    return await this.baseService.GetById(Id);
                });
        }
    }
}
