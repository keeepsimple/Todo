using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Services.BaseServices
{
    public interface IBaseServices<T>
    {
        int Add(T entity);

        Task<int> AddAsync(T entity);

        bool Update(T entity);

        Task<bool> UpdateAsync(T entity);

        bool Delete(Guid id);

        Task<bool> DeleteAsync(Guid id);

        bool Delete(T entity);

        Task<bool> DeleteAsync(T entity);

        T GetById(Guid id);

        Task<T> GetByIdAsync(Guid id);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();
    }
}
