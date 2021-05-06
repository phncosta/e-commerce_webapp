using AutoMapper;
using HeavensHall.Commerce.Application.Common.Models;
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Web.Controllers
{
    [Authorize]
    [Route("cliente")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IIdentityService identityService, IMapper mapper)
        {
            _customerService = customerService;
            _identityService = identityService;
            _mapper = mapper;
        }

        public IActionResult Home() => View("CustomerDetails");

        [HttpGet("enderecos")]
        public async Task<IActionResult> AddressManagement()
        {
            string userId = await _identityService.GetUserId(User.Identity.Name);
            int customerId = _customerService.GetCustomerIdFromUser(userId);
            var addresses = await _customerService.GetCustomerAddresses(customerId);
            var customer = new CustomerModel()
            {
                Id = customerId,
                Addresses = _mapper.Map(addresses, new List<AddressModel>()),
            };

            return View("AddressManagement", customer);
        }

        [HttpGet("cadastrar-endereco")]
        public IActionResult AddressRegistrationScreen(int id) => View("AddressRegistration", new CustomerModel() { Id = id });

        [HttpPost("cadastrar-endereco")]
        public async Task<IActionResult> RegisterAddress(CustomerModel customerModel)
        {
            var addressDTO = _mapper.Map<AddressDTO>(customerModel.Address);
            addressDTO.CustomerId = customerModel.Id;
            await _customerService.AddCustomerAddress(addressDTO);

            return View("AddressRegistration");
        }

        [HttpGet("atualizar-endereco")]
        public async Task<IActionResult> AddressUpdateScreen(int id)
        {
            var address = await _customerService.GetAddressById(id);

            return View("AddressUpdate", new CustomerModel() { Address = _mapper.Map<AddressModel>(address) });
        }

        [HttpPost("atualizar-endereco")]
        public async Task<IActionResult> AddressUpdate(CustomerModel customerModel)
        {
            var addressDTO = _mapper.Map<AddressDTO>(customerModel.Address);
            addressDTO.Address_1 = customerModel.Address.Address_1;
            addressDTO.Address_2 = customerModel.Address.Address_2;
            addressDTO.CustomerId = customerModel.Id;
            await _customerService.UpdateCustomerAddress(addressDTO);

            return View("AddressUpdate");
        }

        [HttpPost("excluir-endereco")]
        public async Task<IActionResult> AddressUpdate(int id)
        {
            var address = await _customerService.GetAddressById(id);
            await _customerService.DeleteAddress(address);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> RegisterCustomer(CustomerModel customerModel, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var userCredentials = _mapper.Map<UserCredentials>(customerModel.User);
                var accountCreation = await _identityService.CreateUserAccount(userCredentials, true);

                if (accountCreation.Succeeded)
                {
                    var userId = await _identityService.GetUserId(customerModel.User.Email);
                    var customer = _mapper.Map<Customer>(customerModel);
                    customer.UserId = userId;

                    await _customerService.AddCustomer(customer);

                    return LocalRedirect(returnUrl);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
