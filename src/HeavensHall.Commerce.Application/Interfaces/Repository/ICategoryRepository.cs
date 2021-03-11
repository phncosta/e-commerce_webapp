
using HeavensHall.Commerce.Domain.Entities;
using System;

namespace HeavensHall.Commerce.Application.Interfaces.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByName(string categoryName);
    }
}
