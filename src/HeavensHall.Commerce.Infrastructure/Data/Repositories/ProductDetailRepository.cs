using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using HeavensHall.Commerce.Application.Interfaces.Repository;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class ProductDetailRepository : Repository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ProductDetail> GetProductRelationship(int productId)
        {
            return await _Context.Product_Details.Where(d => d.Product.Id == productId)
                                                 .Include(p => p.Product.Brand)
                                                 .Include(p => p.Product.Category)
                                                 .FirstOrDefaultAsync();
        }

        public async Task<ProductDetail> GetByProductId(int productId)
        {
            return await _Context.Product_Details.Where(p => p.Product.Id == productId)
                                                                 .FirstOrDefaultAsync();
        }

        public async Task<List<ProductDetail>> GetAllRelationships()
        {
            return await _Context.Product_Details.Include(p => p.Product.Brand)
                                                 .Include(p => p.Product.Category)
                                                 .ToListAsync();
        }

        public async Task<List<ProductDetail>> GetAllActiveProductRelationshipByPage(int startIndex, int maxRows)
        {
            return await _Context.Product_Details.Skip(startIndex)
                                                 .Take(maxRows)
                                                 .Where(p => p.Is_Active)
                                                 .Include(p => p.Product.Brand)
                                                 .Include(p => p.Product.Category)
                                                 .OrderByDescending(p => p.Rating)
                                                 .ToListAsync();
        }
    }
}
