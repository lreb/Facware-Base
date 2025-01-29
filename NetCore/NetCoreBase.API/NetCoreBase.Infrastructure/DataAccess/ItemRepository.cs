using Microsoft.EntityFrameworkCore;
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

        public async Task<Item> GetByIdAsync(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
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

        public void Delete(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<Item> GetAll(int pageNumber, int pageSize)
        {
            return _context.Items
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        }

        public async Task<IEnumerable<Item>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Items
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }
    }
}
