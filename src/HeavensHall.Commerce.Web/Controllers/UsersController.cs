using AutoMapper;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HeavensHall.Commerce.Web.Controllers
{
    [Route("usuarios")]
    public class UsersController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public UsersController(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        public IActionResult UserListScreen()
        {
            var users = _identityService.GetUserList();

            return View("Users/UserManagement", _mapper.Map<List<UserModel>>(users));
        }
    }
}
