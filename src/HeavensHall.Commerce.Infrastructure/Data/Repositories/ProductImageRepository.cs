using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<ProductImage>> GetAllFromProduct(int productId) => await _Context.ProductImages
                                                                                  .Where(img => img.Product.Id == productId)
                                                                                  .ToListAsync();

        public async Task<List<ProductImage>> GetMainImageByProduct(int productId) => await _Context.ProductImages
                                                                                      .Where(img => img.Product.Id == productId && img.Main)
                                                                                      .ToListAsync();
    }
}
