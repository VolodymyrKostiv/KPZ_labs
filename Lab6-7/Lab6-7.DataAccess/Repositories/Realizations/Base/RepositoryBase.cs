using Lab6_7.DataAccess.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Repositories.Realizations.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected LabDbContext LabDbContext { get; set; }

        public RepositoryBase(LabDbContext labDbContext)
        {
            LabDbContext = labDbContext;
        }

        public void Create(T entity)
        {
            LabDbContext.Set<T>().Add(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await LabDbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            LabDbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            var query = LabDbContext.Set<T>().AsNoTracking().ToList();

            return query;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = await LabDbContext.Set<T>().AsNoTracking().ToListAsync();

            return query;
        }

        public T GetFirst(Expression<Func<T, bool>> predicate = null)
        {
            var query = LabDbContext.Set<T>().AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.First();
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null)
        {
            var query = LabDbContext.Set<T>().AsNoTracking();
            
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.FirstAsync();
        }

        public void Update(T entity)
        {
            LabDbContext.Set<T>().Update(entity);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            var query = LabDbContext.Set<T>().AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.FirstOrDefault();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null)
        {
            var query = LabDbContext.Set<T>().AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.FirstOrDefaultAsync();
        }

        public void Save()
        {
            LabDbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await LabDbContext.SaveChangesAsync();
        }
    }
}
