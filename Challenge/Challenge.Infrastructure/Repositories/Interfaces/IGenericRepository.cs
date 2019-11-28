using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllByFilter(Expression<Func<T, bool>> expression);

        //Sync
        void Create(T entity);
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);


        //Async
        Task CreateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
