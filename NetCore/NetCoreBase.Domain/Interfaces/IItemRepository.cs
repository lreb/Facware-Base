using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Domain.Interfaces
{
    public interface IItemRepository
    {
        /// <summary>
        /// Get Item by id 
        /// </summary>
        /// <param name="id">item id number</param>
        /// <returns>Items<see cref="Item"/></returns>
        Task<Item> GetByIdAsync(int id);
    }
}
