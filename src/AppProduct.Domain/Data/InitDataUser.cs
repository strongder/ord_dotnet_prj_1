using AppProduct.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace AppProduct.Data
{
    public class InitDataUser
    : IDataSeedContributor, ITransientDependency
    {
        private readonly IdentityUserManager _userManager;
        private readonly IdentityRoleManager _roleManager;
        private readonly IPermissionManager _permissionManager;
        private readonly IPermissionDefinitionManager _permissionDefinitionManager;

        public InitDataUser(
            IdentityUserManager userManager,
            IdentityRoleManager roleManager,
            IPermissionManager permissionManager,
            IPermissionDefinitionManager permissionDefinitionManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _permissionManager = permissionManager;
            _permissionDefinitionManager = permissionDefinitionManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var adminRole = await _roleManager.FindByNameAsync("admin");
            var isNewRole = false;
            if (adminRole == null)
            {
                adminRole = new IdentityRole(Guid.NewGuid(), "admin");
                await _roleManager.CreateAsync(adminRole);
                isNewRole = true;
            }

            var adminUser = await _userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                adminUser = new AppUser("admin", "admin@example.com");
                await _userManager.CreateAsync(adminUser, "Admin123!");
                await _userManager.AddToRoleAsync(adminUser, "admin");
            }

            if (isNewRole)
            {
                var allPermissionNames = (await _permissionDefinitionManager.GetPermissionsAsync())
                 .SelectMany(p => GetPermissionNamesRecursive(p))
                .ToList();

                foreach (var item in allPermissionNames)
                {
                   await _permissionManager.SetForRoleAsync("admin", item, true);
                }
            }
        }
        List<string> GetPermissionNamesRecursive(PermissionDefinition p)
        {
            var list = new List<string> { p.Name };
            foreach (var child in p.Children)
            {
                list.AddRange(GetPermissionNamesRecursive(child));
            }
            return list;
        }
    }
}
