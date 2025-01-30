namespace NetCoreBase.Domain.Interfaces.Common
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<(IEnumerable<T> Entities, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
    }
}