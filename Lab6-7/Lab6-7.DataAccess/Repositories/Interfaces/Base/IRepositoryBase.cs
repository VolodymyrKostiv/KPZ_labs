using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Repositories.Interfaces.Base
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        
        Task CreateAsync(T entity);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        T GetFirst(Expression<Func<T, bool>> predicate = null);

        Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null);

        T GetFirstOrDefault(Expression<Func<T, bool>> predicate = null);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null);

        void Update(T entity);

        void Delete(T entity);

        void Save();

        Task SaveAsync();
    }
}
