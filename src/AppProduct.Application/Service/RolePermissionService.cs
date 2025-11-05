using AppProduct.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using static OpenIddict.Abstractions.OpenIddictConstants;

public class RolePermissionService : ApplicationService, IRolePermissionService
{
    private readonly IdentityRoleManager _roleManager;
    private readonly IRepository<IdentityRole, Guid> _roleRepository;
    private readonly IPermissionManager _permissionManager;
    private readonly IPermissionGrantRepository _permissionGrantRepository;

    public RolePermissionService(
        IdentityRoleManager roleManager,
        IRepository<IdentityRole, Guid> roleRepository,
        IPermissionManager permissionManager,
        IPermissionGrantRepository permissionGrantRepository
        )
    {
        _roleManager = roleManager;
        _roleRepository = roleRepository;
        _permissionManager = permissionManager;
        _permissionGrantRepository = permissionGrantRepository;
    }

    public async Task<List<string>> GetRolesAsync()
    {
        var roles = await _roleRepository.GetListAsync();
        return roles.Select(r => r.Name).ToList();
    }

    public async Task CreateRoleAsync(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
        {
            throw new UserFriendlyException($"Role '{roleName}' already exists.");
        }

        await _roleManager.CreateAsync(new IdentityRole(Guid.NewGuid(), roleName));
    }

    public async Task DeleteRoleAsync(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
            throw new UserFriendlyException($"Role '{roleName}' not found.");

        await _roleManager.DeleteAsync(role);
    }
    public async Task<List<string>> GetPermissionsAsync(string roleName)
    {
        var result = await _permissionManager.GetAllForRoleAsync(roleName);
        return result
        .Where(p => p.IsGranted) // chỉ lấy quyền được cấp
        .Select(p => p.Name)
        .ToList();
    }


    public async Task GrantPermissionsToRoleAsync(string roleName, List<string> permissions)
    {
        foreach (var permission in permissions)
        {
            await _permissionManager.SetForRoleAsync(roleName, permission, true);
        }
    }


    public Task RevokePermissionsFromRoleAsync(string roleName, List<string> permissions)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RoleHasPermissionAsync(string roleName, string permissionName)
    {
        throw new NotImplementedException();
    }
}
