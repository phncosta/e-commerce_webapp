using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetByName(string categoryName)
        {
            return await _Context.Categories.Where(c => c.Name == categoryName).FirstOrDefaultAsync();
        }
    }
}
