using HeavensHall.Commerce.Application.Common.Models;
using HeavensHall.Commerce.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Service
{
    public interface IIdentityService
    {
        Task<Result> CreateUserAccount(UserCredentials userCredentials, bool signIn = false);
        Task<SignInResult> Login(UserCredentials userCredentials);
        Task<string> CreateRole(string role);
        Task<Result> DeleteUser(string userId);
        Task SignOut();
    }
}
