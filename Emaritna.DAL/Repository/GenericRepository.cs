using Microsoft.EntityFrameworkCore;
using Emaritna.DAL.Context;
using Emaritna.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emaritna.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private EmaritnaContext context;
        private DbSet<TEntity> dbSet;

        public GenericRepository(EmaritnaContext _context)
        {
            this.context = _context;
            this.dbSet = context.Set<TEntity>();
        }

        public async virtual Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public async virtual Task<IQueryable<TEntity>> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public async Task<TEntity> GetById(object id)
        {
            return dbSet.Find(id);
        }

        public async virtual Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(filter);
        }

        public virtual async Task Insert(TEntity entity)
        {
            dbSet.Add(entity);
          
        }

        public virtual async Task Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }



        public async Task<IQueryable<TEntity>> GetWith(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.Where(filter);
        }

        public async Task Insert(List<TEntity> entity)
        {
            dbSet.AddRange(entity);
        }


        public async Task<List<TEntity>> FindPaged(Expression<Func<TEntity, bool>> filter ,int page, int pageSize)
        {
            return await dbSet.Where(filter).Skip(page * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            dbSet.Add(entity);
            return entity;
        }
    }
}
