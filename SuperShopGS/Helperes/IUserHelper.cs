using Microsoft.AspNetCore.Identity;
using SuperShopGS.Data.Entities;
using System.Threading.Tasks;

namespace SuperShopGS.Helperes
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);


        Task<IdentityResult> AddUserAsync(User user, string password);
    }
}
