using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.IService
{
    public interface IRolePermissionService
    {
        Task<List<string>> GetPermissionsAsync(string roleName);
        Task<List<string>> GetRolesAsync();
        Task CreateRoleAsync(string roleName);
        Task DeleteRoleAsync(string roleName);
        Task GrantPermissionsToRoleAsync(string roleName, List<string> permissions);
        Task RevokePermissionsFromRoleAsync(string roleName, List<string> permissions);
        Task<bool> RoleHasPermissionAsync(string roleName, string permissionName);
    }
}
