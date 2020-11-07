using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces;

namespace TestMasGlobal.CalculatedSalary.Test.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetAll()
        {
            IEnumerable<Employee> employee = new List<Employee>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Employees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<Employee[]>();
                    employee = readTask.ToList();
                }
            }
            return employee;
        }

        public Task<Employee> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
