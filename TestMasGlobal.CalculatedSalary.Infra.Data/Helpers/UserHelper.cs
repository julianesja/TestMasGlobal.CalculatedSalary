

namespace TestMasGlobal.CalculatedSalary.Infra.Data.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using TestMasGlobal.CalculatedSalary.Domain.Entities;
    using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Dto;
    using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Helpers;
    using TestMasGlobal.CalculatedSalary.Infra.Data.DataContextDatabases;

    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationContext context;

        public UserHelper(UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.context = context;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await this.userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await this.userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await this.roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

      

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await this.userManager.FindByEmailAsync(email);
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await this.userManager.FindByIdAsync(userId);
        }

        public async Task<SignInResult> LoginAsync(LoginDto model)
        {
            return await this.signInManager.PasswordSignInAsync(
                model.User,
                model.Password,
                true,
                false);
        }

        public async Task LogoutAsync()
        {
            await this.signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await this.userManager.UpdateAsync(user);
        }

        public async Task<SignInResult> ValidatePasswordAsync(User user, string password)
        {
            return await this.signInManager.CheckPasswordSignInAsync(
               user,
               password,
               false);
        }
    }
}
