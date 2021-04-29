
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Repository
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<List<Address>> GetAllByCustomerId(int customerId);
    }
}
