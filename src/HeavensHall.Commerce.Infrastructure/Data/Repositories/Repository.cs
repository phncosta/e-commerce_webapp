using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public virtual void SetModified(T entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void SetRemoved(T entity)
        {
            _Context.Entry(entity).State = EntityState.Deleted;
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
