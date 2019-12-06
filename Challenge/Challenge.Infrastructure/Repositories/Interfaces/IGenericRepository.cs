using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //Sync
        IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "");
        IEnumerable<T> GetAllByFilter(Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        void Create(T entity);
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);


        //Async
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<IEnumerable<T>> GetAllByFilterAsync(Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task CreateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
