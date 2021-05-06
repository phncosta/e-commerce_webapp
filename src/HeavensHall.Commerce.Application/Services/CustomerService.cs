using AutoMapper;
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IAddressRepository addressRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task AddCustomer(Customer customer) => await _customerRepository.Add(customer);

        public async Task<Address> GetAddressById(int id) => await _addressRepository.GetById(id);

        public async Task<List<Address>> GetCustomerAddresses(int customerId) => await _addressRepository.GetAllByCustomerId(customerId);

        public async Task<Customer> GetCustomerByUserId(string userId) => await _customerRepository.GetByUserId(userId);

        public int GetCustomerIdFromUser(string userId) => _customerRepository.GetIdFromUserId(userId);

        public async Task AddCustomerAddress(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            var customer = await _customerRepository.GetById(addressDto.CustomerId);
            address.Customer = customer;
            await _addressRepository.Add(address);
        }

        public async Task UpdateCustomerAddress(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            //var address = await _addressRepository.GetById(updatedAddress.Id);
            //address = updatedAddress;
            await _addressRepository.Update(address);
        }

        public Task DeleteAddress(Address address) => _addressRepository.Remove(address);
    }
}
