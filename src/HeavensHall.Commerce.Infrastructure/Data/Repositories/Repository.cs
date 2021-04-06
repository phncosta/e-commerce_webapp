using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Infrastructure.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected readonly AppDbContext _Context;

        protected Repository(AppDbContext context)
        {
            _Context = context;
        }

        public async Task Add(T entity)
        {
            await _Context.Set<T>().AddAsync(entity);
            await _Context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            _Context.Set<T>().Remove(entity);
            await _Context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _Context.Set<T>().Update(entity);
            await _Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _Context?.Dispose();
        }
    }
}
