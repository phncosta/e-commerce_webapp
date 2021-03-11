using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using System.Threading.Tasks;
using System.Linq;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }

        public Brand GetByName(string brand) => _Context.Brands.Where(b => b.Name == brand).FirstOrDefault();

        public async Task<Brand> GetOrInsert(string brandName)
        {
            Brand brand = GetByName(brandName);

            if (brand is null || brand.Id == 0)
            {
                brand = new Brand() { Name = brandName };

                await Add(brand);
            }

            return brand;
        }
    }
}
