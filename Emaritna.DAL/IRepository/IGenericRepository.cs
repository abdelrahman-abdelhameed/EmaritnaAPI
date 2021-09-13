using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emaritna.DAL.IRepository
{
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        /// Get all entities from db
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
         Task<IQueryable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Get with filter data 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        //List<TEntity> GetWith(
        //   Expression<Func<TEntity, bool>> filter , params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Get with filter data with out includes
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> GetWith(
           Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Get query for entity
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        /// <summary>
        /// Get single entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetById(object id);

        /// <summary>
        /// Get first or default entity by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<TEntity> GetFirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Insert entity to db
        /// </summary>
        /// <param name="entity"></param>
        Task Insert(TEntity entity);

        Task<TEntity> Add(TEntity entity);

        Task  Insert(List<TEntity> entity);

        /// <summary>
        /// Update entity in db
        /// </summary>
        /// <param name="entity"></param>
        Task Update(TEntity entity);

        /// <summary>
        /// Delete entity from db by primary key
        /// </summary>
        /// <param name="id"></param>
        Task Delete(object id);



        Task<List<TEntity>> FindPaged(Expression<Func<TEntity, bool>> filter,int page, int pageSize);

    }
}
