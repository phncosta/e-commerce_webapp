using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using HeavensHall.Commerce.Application.Interfaces.Repository;
using System.Linq;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Category GetByName(string categoryName)
        {
            return _Context.Categories.Where(c => c.Name == categoryName).FirstOrDefault();
        }
    }
}
