using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Todo.Data.Infrastructure.Repositories
{
    public class CoreRepository<T> : ICoreRepository<T> where T : class
    {
        protected readonly TodoContext _context;
        private readonly DbSet<T> dbSet;

        public CoreRepository(TodoContext context)
        {
            _context = context;
            
            var typeOfDbSet = typeof(DbSet<T>);
            foreach (var item in context.GetType().GetProperties())
            {
                if (typeOfDbSet == item.PropertyType)
                {
                    dbSet = item.GetValue(context, null) as DbSet<T>;
                    break;
                }
            }
            if (dbSet == null)
            {
                dbSet = context.Set<T>();
            }
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public IQueryable<T> GetQuery()
        {
            return dbSet;
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual T GetById(Guid id)
        {
            return dbSet.Find(id);
        }
    }
}
