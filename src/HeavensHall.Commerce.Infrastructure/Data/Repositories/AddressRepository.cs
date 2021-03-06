using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public async Task ChangeStatus(int addressId, bool status)
        {
            var address = new Address() { Id = addressId, Active = status };

            _Context.Addresses.Attach(address)
                             .Property(p => p.Active)
                             .IsModified = true;

            await _Context.SaveChangesAsync();
        }

        public async Task<List<Address>> GetAllByCustomerId(int customerId)
        {
            return await _Context.Addresses.Where(p => p.Customer.Id == customerId)
                                                                     .ToListAsync();
        }
    }
}
