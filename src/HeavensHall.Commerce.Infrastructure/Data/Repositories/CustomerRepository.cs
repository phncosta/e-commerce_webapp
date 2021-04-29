using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetByUserId(string userId) => await _Context.Customers.Where(p => p.UserId == userId)
                                                                                                  .SingleOrDefaultAsync();

        public int GetIdFromUserId(string userId) => _Context.Customers.Where(p => p.UserId == userId)
                                                                                    .Select(p => p.Id)
                                                                                    .SingleOrDefault();
    }
}
