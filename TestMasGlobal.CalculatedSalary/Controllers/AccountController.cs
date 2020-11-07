namespace TestMasGlobal.CalculatedSalary.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Helpers;
    using TestMasGlobal.CalculatedSalary.Model;

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;
        private readonly IConfiguration configuration;

        public AccountController(IUserHelper userHelper, IMapper mappe, IConfiguration configuration)
        {
            this.userHelper = userHelper;
            this.configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByEmailAsync(model.User);
                if (user != null)
                {
                    var result = await this.userHelper.ValidatePasswordAsync(
                        user,
                        model.Password);

                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            this.configuration["Tokens:Issuer"],
                            this.configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(15),
                            signingCredentials: credentials);
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return this.Created(string.Empty, results);
                    }
                    else
                    {
                        return BadRequest(new { message = "User or password incorrect" });
                    }
                }
                else
                {
                    return BadRequest( new { message = "User doesn't exist in the database" });
                }
            }

            return BadRequest();
        }
    }
}
