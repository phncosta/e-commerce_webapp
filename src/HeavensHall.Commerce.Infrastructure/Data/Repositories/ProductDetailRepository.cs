
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using HeavensHall.Commerce.Application.Interfaces.Repository;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class ProductDetailRepository : Repository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
