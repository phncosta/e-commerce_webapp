using AutoMapper;
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Enums;
using HeavensHall.Commerce.Web.Models;
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

        [Route("login")]
        public IActionResult LoginScreen() => View("Login");

        [HttpGet("novo-cliente")]
        public IActionResult CreateCustommerAccount() => View("CustomerRegistration");

        [HttpGet("novo-funcionario")]
        public IActionResult CreateEmployeeAccount() => View("EmployeeRegistration");

        [HttpPost]
        [Route("autenticar")]
        public async Task<IActionResult> Authenticate(UserCredentialsModel userCredentialsModel, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            var userCredentials = _mapper.Map<UserCredentials>(userCredentialsModel);

            var login = await _identityService.Login(userCredentials);

            if (login.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }

            return View("Login", ViewData["Error"] = "Usuário ou senha incorretos.");
        }

        [HttpPost]
        [Route("logout")]
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


        [HttpPost]
        [Route("criar")]
        public async Task<IActionResult> RegisterAccount(UserModel userModel, bool signIn = false)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserCredentials>(userModel);

                var createAccount = await _identityService.CreateUserAccount(user, signIn);

                if (createAccount.Succeeded)
                {
                    return RedirectUserByRole(user.Role);
                }

                foreach (var error in createAccount.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return BadRequest(ModelState);
        }

        private IActionResult RedirectUserByRole(string userRole)
        {
            return userRole switch
            {
                nameof(UserRole.Admin) => RedirectToAction("gerenciar", "produtos"),
                nameof(UserRole.Stockist) => RedirectToAction("gerenciar", "produtos"),
                _ => RedirectToAction("Index", "Home"),
            };
        }
    }
}
