using AutoMapper;
using HeavensHall.Commerce.Application.Common.Models;
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Enums;
using HeavensHall.Commerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Web.Controllers
{
    [Route("conta")]
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public AccountController(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        [HttpGet("login")]
        public IActionResult LoginScreen() => View("Login");

        [HttpGet("novo-cliente")]
        public IActionResult CreateCustommerAccount() => View("CustomerRegistration");

        [HttpGet("novo-funcionario")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateEmployeeAccount() => View("EmployeeRegistration");

        [HttpGet("nao-autorizado")]
        public IActionResult NotAuthorized() => View("NotAuthorized");

        [HttpGet("alterar"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAccountPageAsync(string id)
        {
            UserDTO user = await _identityService.GetUserById(id);

            var userModel = _mapper.Map<UserModel>(user);

            return View("EmployeeUpdate", userModel);
        }

        [HttpPost("desativar"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeAccountStatus(string id, bool status)
        {
            var result = await _identityService.ChangeAccountStatus(id, status);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Authenticate(UserCredentialsModel userCredentialsModel, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var userCredentials = _mapper.Map<UserCredentials>(userCredentialsModel);

                var login = await _identityService.Login(userCredentials);

                if (login.Succeeded)
                {
                    string userRole = await _identityService.GetUserRole(userCredentials.Email);
                    return returnUrl is null ? RedirectUserByRole(userRole) : LocalRedirect(returnUrl);
                }

                foreach (var error in login.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> SignOut(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            await _identityService.SignOut();

            if (returnUrl is null)
            {
                return LoginScreen();
            }

            return LocalRedirect(returnUrl);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> RegisterAccount(UserModel userModel, bool signIn = false, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserCredentials>(userModel);

                var createAccount = await _identityService.CreateUserAccount(user, signIn);

                if (createAccount.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in createAccount.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("atualizar"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAccount(UserModel userModel, bool signIn = false)
        {
            var user = _mapper.Map<UserCredentials>(userModel);

            var updateAccount = await _identityService.UpdateUserAccount(user, signIn);

            if (updateAccount.Succeeded)
            {
                return Ok();
            }

            foreach (var error in updateAccount.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return BadRequest(ModelState);
        }

        private IActionResult RedirectUserByRole(string userRole)
        {
            return userRole switch
            {
                nameof(UserRole.Admin) => RedirectToAction("", "gerenciar"),
                nameof(UserRole.Stockist) => RedirectToAction("visualizar", "produtos"),
                _ => RedirectToAction("Index", "Home"),
            };
        }
    }
}
