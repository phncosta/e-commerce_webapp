using HeavensHall.Commerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Repository
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        Task<List<ProductImage>> GetMainImageByProduct(int productId);
        Task<List<ProductImage>> GetAllFromProduct(int productId);
    }
}
