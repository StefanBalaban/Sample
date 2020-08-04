using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.Models;
using Sample.Services.Interfaces;

namespace Sample.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class, IBaseModel 
    {
        protected readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(int id, IEnumerable<string> properties)
        {
            var set = _dbContext.Set<T>().AsQueryable();
            foreach (var property in properties)
            {
                set = set.Include(property);
            }
            return (await set.ToListAsync()).SingleOrDefault(x => x.Id == id );
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(IEnumerable<string> properties)
        {
            var set = _dbContext.Set<T>().AsQueryable();
            foreach (var property in properties)
            {
                set = set.Include(property);
            }
            return await set.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
