
using HeavensHall.Commerce.Domain.Entities;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByName(string categoryName);
    }
}
