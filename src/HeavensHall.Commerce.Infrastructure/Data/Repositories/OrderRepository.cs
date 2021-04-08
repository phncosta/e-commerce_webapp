
using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
