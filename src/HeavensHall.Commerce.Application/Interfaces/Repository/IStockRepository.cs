using HeavensHall.Commerce.Domain.Entities;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Repository
{
    public interface IStockRepository : IRepository<Stock>
    {
        Task<Stock> GetByProductId(int productId);
    }
}
