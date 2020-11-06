using System.Threading.Tasks;
using TestMasGlobal.CalculatedSalary.Domain.Entities;
using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Helpers;
using TestMasGlobal.CalculatedSalary.Infra.Data.DataContextDatabases;

namespace TestMasGlobal.CalculatedSalary.Infra.Data.Seeders
{
    public class UserSeeder : ISeeder
    {
        private readonly ApplicationContext applicationContext;
        private readonly IUserHelper userHelper;

        public UserSeeder(ApplicationContext applicationContext, IUserHelper userHelper)
        {
            this.applicationContext = applicationContext;
            this.userHelper = userHelper;
        }
        public async Task ExecuteSeederAsync()
        {
            await applicationContext.Database.EnsureCreatedAsync();
            User user = new User()
            {
                Name = "Julian",
                LastName = "Estrada",
                Email = "julianesja@gmail.com",
                UserName = "julianesja@gmail.com"
            };
            var result = await this.userHelper.AddUserAsync(user, "Jupiter1026$");
        }
    }
}
