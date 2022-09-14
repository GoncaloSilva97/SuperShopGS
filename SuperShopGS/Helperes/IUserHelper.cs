using Microsoft.AspNetCore.Identity;
using SuperShopGS.Data.Entities;
using SuperShopGS.Models;
using System.Threading.Tasks;

namespace SuperShopGS.Helperes
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);


        Task<IdentityResult> AddUserAsync(User user, string password);


        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();


        Task<IdentityResult> UpdateUserAsync(User user);


        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);
    }
}
