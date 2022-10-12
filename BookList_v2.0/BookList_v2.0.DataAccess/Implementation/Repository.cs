using BookList_v2._0.DataAccess.Contracts;
using BookList_v2._0.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookList_v2._0.DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(ApplicationDbContext dbContext) => dbSet = dbContext.Set<T>();

        public T Get(Guid id) => dbSet.Find(id);

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                query = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                query = includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return query.FirstOrDefault();
        }

        public void Add(T entity) => dbSet.Add(entity);

        public void Remove(Guid id)
        {
            var entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(T entity) => dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => dbSet.RemoveRange(entities);

        //


        private readonly DbSet<T> dbSet;
    }
}
