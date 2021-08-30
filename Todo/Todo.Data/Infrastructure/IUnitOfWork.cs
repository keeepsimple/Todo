using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.Infrastructure.Repositories;
using Todo.Models;

namespace Todo.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        TodoContext DataContext { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        ICoreRepository<T> CoreRepository<T>() where T : class;

        ICoreRepository<TodoP> TodoRepository { get; }
    }
}
