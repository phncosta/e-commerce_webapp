using CleanArchitecture.Infrastructure.Identity;
using HeavensHall.Commerce.Application.Common.Models;
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Enums;
using HeavensHall.Commerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(UserManager<ApplicationUser> userManager,
                               SignInManager<ApplicationUser> signInManager,
                               RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<Result> CreateUserAccount(UserCredentials userCredentials, bool signIn = false)
        {
            ApplicationUser identityUser = new()
            {
                UserName = userCredentials.Email,
                Name = userCredentials.Name,
                Email = userCredentials.Email
            };

            var result = await _userManager.CreateAsync(identityUser, userCredentials.Password);

            if (result.Succeeded)
            {
                var role = await CreateRole(userCredentials.Role);
                result = await _userManager.AddToRoleAsync(identityUser, role);

                if (signIn)
                {
                    await _signInManager.SignInAsync(identityUser, new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(90)
                    });
                }
            }

            return result.ToApplicationResult();
        }

        public async Task SignOut() => await _signInManager.SignOutAsync();

        public async Task<SignInResult> Login(UserCredentials userCredentials)
        {
            return await _signInManager.PasswordSignInAsync(userCredentials.Email, userCredentials.Password, userCredentials.RememberMe, lockoutOnFailure: false);
        }

        public async Task<string> CreateRole(string role)
        {
            string[] roles = Enum.GetNames(typeof(UserRole));

            var roleFound = await _roleManager.RoleExistsAsync(role);

            if (!roleFound)
            {
                foreach (var userRole in roles)
                {
                    if (role == userRole)
                        await _roleManager.CreateAsync(new IdentityRole(userRole));
                }
            }

            return role;
        }

        public async Task<Result> DeleteUser(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user is null)
            {
                return Result.Success();
            }

            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
    }
}
