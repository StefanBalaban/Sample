using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, IEnumerable<string> properties);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAllAsync(IEnumerable<string> properties);
        Task<T> AddAsync(T entity);
        Task UpdateAsync();
        Task DeleteAsync(T entity);
    }
}
