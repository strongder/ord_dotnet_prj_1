using AppProduct.Entity;
using AppProduct.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace AppProduct.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityUserManager _userManager;
        private readonly IIdentityUserRepository _identityUserRepository;

        public UserRepository(
            IdentityUserManager userManager,
            IIdentityUserRepository identityUserRepository)
        {
            _userManager = userManager;
            _identityUserRepository = identityUserRepository;
        }

        public async Task<AppUser?> FindByIdAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString()) as AppUser;
        }

        public async Task<AppUser?> FindByEmailAsync(string email)
        {
            return await _userManager.Users
                .Where(x => x.Email == email)
                .Cast<AppUser>()
                .FirstOrDefaultAsync();
        }

        public async Task<AppUser?> FindByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName) as AppUser;
        }

        public async Task<List<AppUser>> GetPagedAsync(int skipCount, int maxResultCount, string? filter)
        {
            var query = _userManager.Users;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(x => x.UserName.Contains(filter) || x.Email.Contains(filter));
            }

            return await query
                .OrderBy(x => x.UserName)
                .Skip(skipCount)
                .Take(maxResultCount)
                .Cast<AppUser>()
                .ToListAsync();
        }

        public async Task<int> GetCountAsync(string? filter)
        {
            var query = _userManager.Users;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(x => x.UserName.Contains(filter) || x.Email.Contains(filter));
            }

            return await query.CountAsync();
        }

        public async Task CreateAsync(AppUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
        }

        public async Task UpdateAsync(AppUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task DeleteAsync(AppUser user)
        {
            await _userManager.DeleteAsync(user);
        }

        public Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password);
        }

        public Task<List<string>> GetRolesAsync(AppUser user)
        {
            return Task.FromResult(_userManager.GetRolesAsync(user).Result.ToList());
        }

        public Task AddToRoleAsync(AppUser user, string roleName)
        {
            return _userManager.AddToRoleAsync(user, roleName);
        }

        public Task RemoveFromRoleAsync(AppUser user, string roleName)
        {
            return _userManager.RemoveFromRoleAsync(user, roleName);
        }
    }
}
