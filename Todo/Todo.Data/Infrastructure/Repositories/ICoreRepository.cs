using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Todo.Data.Infrastructure.Repositories
{
    public interface ICoreRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);

        T GetById(Guid id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        IQueryable<T> GetQuery();

        IQueryable<T> GetQuery(Expression<Func<T, bool>> where);
    }
}
