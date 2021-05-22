using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Domain.Enums;
using HeavensHall.Commerce.Application.Extensions.EnumExtensions;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Sdk;

namespace HeavensHall.Commerce.IntegrationTests
{
    public class IntegrationTests
    {
        [Fact]
        public void Should_Insert_Product()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                              .UseInMemoryDatabase(databaseName: "heavenshall_test_db")
                              .Options;

            using var dbContext = new AppDbContext(options);

            // Act
            dbContext.Products.Add(new Product()
            {
                Id = 1,
                Price = 1100,
                Description = "Product description",
                Name = "Guitar Les Paul",
                Brand = new Brand() { Id = 1, Name = "Gibson" },
                Category = new Category() { Id = 1, Name = InstrumentCategory.STRING.GetDescription() }
            });

            // Assert
            Assert.True(dbContext.SaveChanges() > 0);
        }
    }
}
