using AppProduct.Dtos.Auth;
using AppProduct.Entity;
using AppProduct.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using Volo.Abp.Users;
namespace AppProduct.Service
{
    [UnitOfWork]
    public class AuthService : ApplicationService, IAuthService
    {

        private readonly IdentityUserManager _userManager;
        private readonly IConfiguration _configuration;
        private readonly IdentityRoleManager _roleManager;
        private readonly IPermissionManager _permissions;
        public AuthService(IdentityUserManager userManager, IConfiguration configuration, IdentityRoleManager roleManager, IPermissionManager permissions)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _permissions = permissions;
        }
        public async Task<LoginResultDto> LoginAsync(LoginInputDto input)
        {
            var user = await _userManager.FindByNameAsync(input.UserName);
            if (user == null)
            {
                throw new UserFriendlyException("Invalid username or password.");
            }

            // Build JWT token
            var token = await GenerateTokenAsync(user);
            return new LoginResultDto
            {
                Token = token
            };

        }
        public async Task<string> RegisterAsync(RegisterDto input)
        {
            var user = await _userManager.FindByNameAsync(input.UserName);
            if (user != null)
            {
                throw new UserFriendlyException("Username already exists");
            }
            var emailUser = await _userManager.FindByEmailAsync(input.Email);
            if (emailUser != null)
            {
                throw new UserFriendlyException("Email already exists");
            }
            var newUser = new AppUser(input.UserName, input.Email);
            var result = await _userManager.CreateAsync(newUser, input.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new UserFriendlyException(errors);
            }
            return "User registered successfully";
        }
        public async Task<string> GenerateTokenAsync(IdentityUser user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task CheckPermissionsAsync()
        {
            var user = await _userManager.FindByIdAsync(CurrentUser.Id.ToString());
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);

                var rolePermissionStore = (IRolePermissionStore<IdentityRole>)_roleManager;
                var permissions = await rolePermissionStore.GetGrantedPermissionNamesAsync(role);

                Console.WriteLine($"{roleName}: {string.Join(", ", permissions)}");
            }
        }



    }
}
