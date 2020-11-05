namespace TestMasGlobal.CalculatedSalary.Infra.Data.DataContextDatabases
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestMasGlobal.CalculatedSalary.Domain.Entities;
    public interface IConexionApi<Entity> where Entity : BaseEntity
    {
        Task<IEnumerable<Entity>> GetAll(string uri, string resource);
    }
}
