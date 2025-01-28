using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Domain.Interfaces
{
    public interface IItemRepository
    {
        Item GetById(int id);
        void Add(Item customer);
        void Update(Item customer);
    }
}
