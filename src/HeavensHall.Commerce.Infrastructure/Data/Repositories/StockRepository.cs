using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using HeavensHall.Commerce.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Stock> GetByProductId(int productId) => await _Context.Stock.Where(s => s.Product.Id == productId)
                                                                                                             .AsNoTracking()
                                                                                                      .FirstOrDefaultAsync();
    }
}
