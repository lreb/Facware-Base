using NetCoreBase.Domain.Entities;
using NetCoreBase.Domain.Interfaces;
using NetCoreBase.Infrastructure.Data.Postgresql;

namespace NetCoreBase.Infrastructure.DataAccess
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Item item)
        {
            _context.Items.Add(item);
        }

        public Item GetById(int id)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception($"Item with id {id} not found.");
            }
            return item;
        }

        public void Update(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }

        // create a new method to get all items 
    }
}
