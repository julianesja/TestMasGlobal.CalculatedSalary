namespace TestMasGlobal.CalculatedSalary.Domain.Interfaces.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using TestMasGlobal.CalculatedSalary.Domain.Entities;
    using TestMasGlobal.CalculatedSalary.Domain.Interfaces.Dto;

    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

      

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginDto model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<User> GetUserByIdAsync(string userId);
    }
}
