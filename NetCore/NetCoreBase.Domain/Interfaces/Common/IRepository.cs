using NetCoreBase.Domain.Entities;
using System.Linq.Expressions;

namespace NetCoreBase.Domain.Interfaces.Common
{
    public interface IRepositoryRead<T>
    {
        /// <summary>
        /// Get all entities async
        /// </summary>
        /// <returns>
        /// <see cref="IEnumerable{T}"/>
        /// </returns>
        Task<IEnumerable<T>> GetAllAsyncAsNoTracking(Expression<Func<Item, bool>> predicate, CancellationToken cancellationToken);
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(long id, CancellationToken cancellationToken);
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsyncNoTracking(long id, CancellationToken cancellationToken);
    }

    public interface IRepositoryCreate<T> 
    {
        /// <summary>
        /// Add entity async
        /// </summary>
        /// <param name="entity">
        /// <see cref="T"/>
        /// </param>
        /// <returns>
        /// <see cref="T"/>
        /// </returns>
        Task<T> AddAsync(T entity);
    }

    public interface IRepositoryUpdate<T>
    {
        /// <summary>
        /// Update entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);
    }

    public interface IRepositoryPaginated<T>
    {
        /// <summary>
        /// Get paged entities async
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns> <summary>
        /// 
        /// </summary>
        /// <param name="Entities"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<(IEnumerable<T> Entities, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }

    public interface IRepositoryDelete<T>
    {
        /// <summary>
        ///  Delete entity async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(long id);
    }

    /// <summary>
    ///  
    /// </summary>
    /// <typeparam name="T"></typeparam> <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IRepositoryRead<T>, IRepositoryCreate<T>, IRepositoryUpdate<T>, IRepositoryDelete<T>, IRepositoryPaginated<T>
        where T : class
    {        
    }
}