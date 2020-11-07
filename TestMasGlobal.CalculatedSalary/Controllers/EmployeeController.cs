using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Aplications.Interfaces.Interfaces;

namespace TestMasGlobal.CalculatedSalary.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeApplication employeeApplication;

        public EmployeeController(IEmployeeApplication employeeApplication)
        {
            this.employeeApplication = employeeApplication;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.employeeApplication.GetEmployeeAll();
            if (result.Exitoso)
            {
                return Ok(result.Entidad);
            }
            else
            {
                return this.BadRequest();
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.employeeApplication.GetEmployee(id);
            if (result.Exitoso)
            {
                return Ok(result.Entidad);
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}