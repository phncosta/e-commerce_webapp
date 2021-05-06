using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Service
{
    public interface ICustomerService
    {
        Task AddCustomer(Customer customer);
        Task<List<Address>> GetCustomerAddresses(int customerId);
        Task<Customer> GetCustomerByUserId(string userId);
        Task AddCustomerAddress(AddressDTO addressDto);
        int GetCustomerIdFromUser(string userId);
        Task<Address> GetAddressById(int id);
        Task DeleteAddress(Address address);
        Task UpdateCustomerAddress(AddressDTO addressDto);
    }
}
