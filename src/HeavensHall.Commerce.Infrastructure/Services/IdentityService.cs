using HeavensHall.Commerce.Application.Common.Models;
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Enums;
using HeavensHall.Commerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task SignOut() => await _signInManager.SignOutAsync();

        public List<UserDTO> GetUserList()
        {
            var users = new List<UserDTO>();

            var applicationUsers = _userManager.Users.ToList();

            foreach (var user in applicationUsers)
            {
                users.Add(new UserDTO()
                {
                    Id = user.Id,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Name = user.Name,
                    Role = _userManager.GetRolesAsync(user).Result[0]
                });
            }

            return users;
        }

        public async Task<Result> CreateUserAccount(UserCredentials userCredentials, bool signIn = false)
        {
            ApplicationUser identityUser = new()
            {
                UserName = userCredentials.Email,
                Name = userCredentials.Name,
                Email = userCredentials.Email,
                IsActive = userCredentials.IsActive
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

        public async Task<Result> UpdateUserAccount(UserCredentials user, bool signIn)
        {
            var applicationUser = await _userManager.FindByNameAsync(user.Email);

            var role = await _userManager.AddToRoleAsync(applicationUser, user.Role);
            var changePassword = await _userManager.ChangePasswordAsync(applicationUser, applicationUser.PasswordHash, user.Password);

            applicationUser.Name = user.Name;
            applicationUser.IsActive = user.IsActive;

            var update = await _userManager.UpdateAsync(applicationUser);

            if (update.Succeeded && changePassword.Succeeded && role.Succeeded)
            {
                return Result.Success();
            }

            var errors = new List<string>();

            foreach (var e in update.Errors)
                errors.Add(e.Description);

            foreach (var e in changePassword.Errors)
                errors.Add(e.Description);

            foreach (var e in role.Errors)
                errors.Add(e.Description);

            return Result.Failure(errors);
        }

        public async Task<Result> Login(UserCredentials userCredentials)
        {
            var login = await _signInManager.PasswordSignInAsync(userCredentials.Email, userCredentials.Password, userCredentials.RememberMe, lockoutOnFailure: false);

            return login.ToApplicationSignInResult();
        }

        public async Task<string> CreateRole(string role)
        {
            string[] roles = Enum.GetNames(typeof(UserRole));

            var roleFound = await _roleManager.RoleExistsAsync(role);

            if (!roleFound)
            {
                foreach (var singleRole in roles)
                {
                    if (role == singleRole)
                        await _roleManager.CreateAsync(new IdentityRole(singleRole));
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
