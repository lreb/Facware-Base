namespace NetCoreBase.Domain.Interfaces.Common
{
    /// <summary>
    ///  
    /// </summary>
    /// <typeparam name="T"></typeparam> <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Get all entities async
        /// </summary>
        /// <returns>
        /// <see cref="IEnumerable{T}"/>
        /// </returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);
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
        /// <summary>
        /// Update entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);
        /// <summary>
        ///  Delete entity async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);
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
        Task<(IEnumerable<T> Entities, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
    }
}