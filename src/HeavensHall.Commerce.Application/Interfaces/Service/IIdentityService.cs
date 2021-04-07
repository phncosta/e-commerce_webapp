using HeavensHall.Commerce.Application.Common.Models;
using HeavensHall.Commerce.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Service
{
    public interface IIdentityService
    {
        Task<Result> CreateUserAccount(UserCredentials userCredentials, bool signIn = false);
        Task<string> CreateRole(string role);
        Task<Result> DeleteUser(string userId);
        Task<Result> UpdateUserAccount(UserCredentials user, bool signIn);
        Task<Result> Login(UserCredentials userCredentials);
        Task SignOut();
        List<UserDTO> GetUserList();
    }
}
