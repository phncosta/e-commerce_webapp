using AutoMapper;
using HeavensHall.Commerce.Application.Common.Models;
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

        [HttpGet("login")]
        public IActionResult LoginScreen() => View("Login");

        [HttpGet("novo-cliente")]
        public IActionResult CreateCustommerAccount() => View("CustomerRegistration");

        [HttpGet("novo-funcionario")]
        public IActionResult CreateEmployeeAccount() => View("EmployeeRegistration");

        [HttpGet("atualizar/{id}")]
        public IActionResult UpdateAccountPage(string id)
        {
            return View("EmployeeUpdate");
        }

        [HttpPost("autenticar")]
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


        [HttpPost("atualizar")]
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
                nameof(UserRole.Admin) => RedirectToAction("gerenciar", "produtos"),
                nameof(UserRole.Stockist) => RedirectToAction("gerenciar", "produtos"),
                _ => RedirectToAction("Index", "Home"),
            };
        }
    }
}
