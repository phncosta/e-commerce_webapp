using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetAllRelationships()
        {
            return await _Context.Products.Include(p => p.Brand).Include(c => c.Category)
                                                                           .ToListAsync();
        }

        public async Task<decimal> GetPrice(int productId)
        {
            return await _Context.Products.Where(p => p.Id == productId)
                                          .Select(p => p.Price)
                                          .FirstOrDefaultAsync();

        }

        public async Task<Product> GetRelantionship(int id)
        {
            return await _Context.Products.Where(p => p.Id == id).Include(b => b.Brand).Include(c => c.Category)
                                                                                          .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProductStatus(int productId, bool status)
        {
            var product = new Product() { Id = productId, Is_Active = status };

            _Context.Products.Attach(product)
                             .Property(p => p.Is_Active)
                             .IsModified = true;

            await _Context.SaveChangesAsync();

            return status;
        }
    }
}
