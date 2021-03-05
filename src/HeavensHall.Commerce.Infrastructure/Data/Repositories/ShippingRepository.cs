
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using HeavensHall.Commerce.Application.Interfaces.Repository;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class ShippingRepository : Repository<Shipping>, IShippingRepository
    {
        public ShippingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
