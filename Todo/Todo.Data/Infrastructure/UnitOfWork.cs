using System.Threading.Tasks;
using Todo.Data.Infrastructure.Repositories;
using Todo.Models;

namespace Todo.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _dbContext;

        public TodoContext DataContext => _dbContext;

        public UnitOfWork(TodoContext dbContext)
        {
            _dbContext = dbContext;
        }

        private ICoreRepository<TodoP> _todoRepository;

        public ICoreRepository<TodoP> TodoRepository => _todoRepository ?? new CoreRepository<TodoP>(_dbContext);

        public ICoreRepository<T> CoreRepository<T>() where T : class
        {
            return new CoreRepository<T>(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
