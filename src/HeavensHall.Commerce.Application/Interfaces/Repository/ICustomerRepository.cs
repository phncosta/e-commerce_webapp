using HeavensHall.Commerce.Domain.Entities;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByUserId(string userId);
        int GetIdFromUserId(string userId);
    }
}
