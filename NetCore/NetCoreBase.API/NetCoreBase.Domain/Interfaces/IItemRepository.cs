using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Domain.Interfaces
{
    public interface IItemRepository
    {
        //Task<IEnumerable<Item>> GetAllAsync(int pageNumber, int pageSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Item> GetByIdAsync(int id);
        //Item GetById(int id);
        //void Add(Item item);
        //void Update(Item customer);
    }
}
