
using HeavensHall.Commerce.Domain.Entities;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Repository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Brand GetByName(string brand);
        Task<Brand> GetOrInsert(string brand);
    }
}
