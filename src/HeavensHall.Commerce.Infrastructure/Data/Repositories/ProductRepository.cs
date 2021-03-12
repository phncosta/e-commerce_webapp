﻿using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using HeavensHall.Commerce.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

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

        public async Task<Product> GetRelantionship(int id)
        {
            return await _Context.Products.Where(p => p.Id == id).Include(b => b.Brand).Include(c => c.Category)
                                                                                          .FirstOrDefaultAsync();
        }
    }
}
