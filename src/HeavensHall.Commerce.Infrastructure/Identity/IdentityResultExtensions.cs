using HeavensHall.Commerce.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace HeavensHall.Commerce.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                        ? Result.Success()
                        : Result.Failure(result.Errors.Select(e => e.Description));
        }

        public static Result ToApplicationSignInResult(this SignInResult result)
        {
            return result.Succeeded
                        ? Result.Success()
                        : Result.Failure(GetSignInFailures(result));
        }

        public static List<string> GetSignInFailures(SignInResult result)
        {
            var errors = new List<string>();

            if (result.IsLockedOut)
                errors.Add("Usuário com login barrado.");

            else if (result.IsNotAllowed)
                errors.Add("Usuário com acesso não permitido.");

            else if (result.RequiresTwoFactor)
                errors.Add("Necessária autenticação em dois fatores.");

            else
                errors.Add("Usuário ou senha incorretos.");

            return errors;
        }
    }
}