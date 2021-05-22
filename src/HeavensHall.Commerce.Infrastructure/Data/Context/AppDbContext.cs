using HeavensHall.Commerce.Application.Extensions.EnumExtensions;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Domain.Enums;
using HeavensHall.Commerce.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeavensHall.Commerce.Infrastructure.Data.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            if (Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                Database.Migrate();
            }
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category[] {
                new Category{ Id = 1, Name = InstrumentCategory.STRING.GetDescription() },
                new Category{ Id = 2, Name = InstrumentCategory.PERCUSSION.GetDescription() },
                new Category{ Id = 3, Name = InstrumentCategory.WIND.GetDescription() },
            });
        }
    }
}
