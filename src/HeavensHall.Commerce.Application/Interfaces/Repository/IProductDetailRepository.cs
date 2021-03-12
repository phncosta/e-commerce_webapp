using HeavensHall.Commerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Repository
{
    public interface IProductDetailRepository : IRepository<ProductDetail>
    {
        Task<ProductDetail> GetProductRelationship(int productId);
        Task<ProductDetail> GetByProductId(int productId);
        Task<List<ProductDetail>> GetAllRelationships();
        Task<List<ProductDetail>> GetAllActiveProductRelationshipByPage(int startIndex, int maxRows);
    }
}
