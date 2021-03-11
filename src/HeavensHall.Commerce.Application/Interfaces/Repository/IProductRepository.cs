using HeavensHall.Commerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetRelantionship(int id);
        Task<List<Product>> GetAllRelationships();
    }
}
