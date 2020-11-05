using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Domain.Entities;

namespace TestMasGlobal.CalculatedSalary.Infra.Data.DataContextDatabases
{
    public class ConexionApi<Entity> : IConexionApi<Entity> where Entity : BaseEntity
    {

        public async Task<IEnumerable<Entity>> GetAll(string uri, string resource)
        {
            IEnumerable<Entity> Result = new List<Entity>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                //HTTP GET
                var responseTask = client.GetAsync(resource);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<Entity[]>();
                    Result = readTask.ToList();
                }
            }
            return Result;
        }
    }
}
