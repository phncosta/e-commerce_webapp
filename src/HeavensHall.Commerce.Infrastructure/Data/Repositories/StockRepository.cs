using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
