using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace sycXF.Services.Database
{
    public interface IDataRepository<T> where T : IDatabaseItem, new()
    {
        Task<T> GetById(int id);
        Task<int> DeleteAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<int> SaveAsync(T item);
        SQLiteAsyncConnection Database { get; }
    }
}
