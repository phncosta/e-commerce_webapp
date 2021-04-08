using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class ProductDetailRepository : Repository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ProductDetail> GetProductRelationship(int productId)
        {
            return await _Context.ProductDetails.Where(d => d.Product.Id == productId)
                                                 .Include(p => p.Product.Brand)
                                                 .Include(p => p.Product.Category)
                                                 .FirstOrDefaultAsync();
        }

        public async Task<ProductDetail> GetByProductId(int productId)
        {
            return await _Context.ProductDetails.Where(p => p.Product.Id == productId)
                                                                 .FirstOrDefaultAsync();
        }

        public async Task<List<ProductDetail>> GetAllRelationships()
        {
            return await _Context.ProductDetails.Include(p => p.Product.Brand)
                                                 .Include(p => p.Product.Category)
                                                 .ToListAsync();
        }

        public async Task<List<ProductDetail>> GetAllActiveProductRelationshipByIndex(int startIndex, int maxRows)
        {
            return await _Context.ProductDetails.Skip(startIndex)
                                                 .Take(maxRows)
                                                 .Include(p => p.Product)
                                                 .Where(p => p.Product.Is_Active)
                                                 .OrderByDescending(p => p.Rating)
                                                 .ToListAsync();
        }
    }
}
