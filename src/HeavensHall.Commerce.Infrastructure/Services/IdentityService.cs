using HeavensHall.Commerce.Application.Common.Models;
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Enums;
using HeavensHall.Commerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _accessor;

        public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _accessor = accessor;
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
                var role = await CreateRole(GetRoleVerified(userCredentials.Role));
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

        public async Task<Result> Login(UserCredentials userCredentials)
        {
            var user = await _userManager.FindByNameAsync(userCredentials.Email);

            if (user is null || !user.IsActive)
            {
                var error = new List<string>
                {
                    "Conta desativada ou inexistente."
                };

                return Result.Failure(error);
            }

            var login = await _signInManager.PasswordSignInAsync(userCredentials.Email, userCredentials.Password,
                                                                 userCredentials.RememberMe, lockoutOnFailure: false);

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

        public async Task<Result> ChangeAccountStatus(string id, bool status)
        {
            var user = await _userManager.FindByIdAsync(id);

            user.IsActive = status;

            var changeStatus = await _userManager.UpdateAsync(user);

            if (changeStatus.Succeeded)
            {
                return Result.Success();
            }

            var errors = new List<string>();

            foreach (var error in changeStatus.Errors)
            {
                errors.Add(error.Description);
            }

            return Result.Failure(errors);
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id);

            var user = new UserDTO()
            {
                Id = applicationUser.Id,
                Name = applicationUser.Name,
                Email = applicationUser.Email,
                Role = _userManager.GetRolesAsync(applicationUser).Result[0],
                IsActive = applicationUser.IsActive
            };

            return user;
        }

        public async Task<Result> UpdateUserAccount(UserCredentials user, bool signIn)
        {
            var applicationUser = await _userManager.FindByNameAsync(user.Email);

            // To Fix: PW and Role Update
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

        public async Task<string> GetUserRole(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return _userManager.GetRolesAsync(user).Result[0];
        }

        public async Task<string> GetUserId(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return user?.Id;
        }

        private string GetRoleVerified(string userRole)
        {
            if (!GetUser().Identity.IsAuthenticated)
            {
                return UserRole.Customer.ToString();
            }

            return userRole;
        }

        protected ClaimsPrincipal GetUser()
        {
            return _accessor?.HttpContext?.User;
        }
    }
}
