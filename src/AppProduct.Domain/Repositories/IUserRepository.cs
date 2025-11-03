using AppProduct.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser?> FindByIdAsync(Guid id);
        Task<AppUser?> FindByEmailAsync(string email);
        Task<AppUser?> FindByUserNameAsync(string userName);

        Task<List<AppUser>> GetPagedAsync(int skipCount, int maxResultCount, string? filter);
        Task<int> GetCountAsync(string? filter);

        Task CreateAsync(AppUser user, string password);
        Task UpdateAsync(AppUser user);
        Task DeleteAsync(AppUser user);

        Task<bool> CheckPasswordAsync(AppUser user, string password);

        Task<List<string>> GetRolesAsync(AppUser user);
        Task AddToRoleAsync(AppUser user, string roleName);
        Task RemoveFromRoleAsync(AppUser user, string roleName);

    }
}
