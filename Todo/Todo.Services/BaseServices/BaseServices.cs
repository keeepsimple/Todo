using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Todo.Data.Infrastructure;

namespace Todo.Services.BaseServices
{
    public class BaseServices<T> : IBaseServices<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.CoreRepository<T>().Add(entity);
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.CoreRepository<T>().Add(entity);
            return await _unitOfWork.SaveChangesAsync();
        }

        public bool Delete(Guid id)
        {
            var entity = _unitOfWork.CoreRepository<T>().GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.CoreRepository<T>().Delete(entity);
            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            _unitOfWork.CoreRepository<T>().Delete(entity);
            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = _unitOfWork.CoreRepository<T>().GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.CoreRepository<T>().Delete(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _unitOfWork.CoreRepository<T>().Delete(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.CoreRepository<T>().GetQuery().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.CoreRepository<T>().GetQuery().ToListAsync();
        }

        public T GetById(Guid id)
        {
            return _unitOfWork.CoreRepository<T>().GetById(id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.CoreRepository<T>().GetByIdAsync(id);
        }

        public bool Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.CoreRepository<T>().Update(entity);
            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.CoreRepository<T>().Update(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
