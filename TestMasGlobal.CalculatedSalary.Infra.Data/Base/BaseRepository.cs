using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Base;
using TestMasGlobal.CalculatedSalary.Infra.Data.DataContextDatabases;

namespace TestMasGlobal.CalculatedSalary.Infra.Data.Base
{
    public class BaseRepository<Entity> : IBaseRepository<Entity>
        where Entity : BaseEntity
    {
        private readonly IConexionApi<Entity> conexionApi;
        private readonly IConfiguration configuration;
        private readonly string uri;
        private readonly string resource;

        public BaseRepository(IConexionApi<Entity> conexionApi, IConfiguration configuration, string resource)
        {
            this.conexionApi = conexionApi;
            this.configuration = configuration;
            this.uri = this.configuration.GetSection("UriApi").Value.ToString();
            this.resource = resource;
        }
        public virtual async Task<Entity> GetById(int id)
        {
            return (await this.conexionApi.GetAll(this.uri, this.resource)).Where(e => e.Id == id).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<Entity>> GetAll()
        {
            return await this.conexionApi.GetAll(this.uri, this.resource);
        }
    }
}
