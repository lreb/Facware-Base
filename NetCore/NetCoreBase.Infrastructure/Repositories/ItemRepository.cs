using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Domain.Interfaces;
using NetCoreBase.Infrastructure.Data.Postgresql;

namespace NetCoreBase.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsyncAsNoTracking(Expression<Func<Item, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Items
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Get Item by id 
        /// </summary>
        /// <param name="id">item id number</param>
        /// <returns>Items<see cref="Item"/></returns>
        public async Task<Item> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            Item? item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            //if (item == null)
            //{
            //    throw new Exception($"{typeof(Item)} with id {id} not found.");
            //    //throw new NotFoundException($"{typeof(Item)} with id {id} not found.");
            //    //throw new OperationResponse().NotFoundOperation($"{typeof(Item)} with id {id} not found.");
            //}
            return item;
        }

        public async Task<Item> GetByIdAsyncNoTracking(long id, CancellationToken cancellationToken)
        {
            var item = await _context.Items.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            //if (item == null)
            //{
            //    throw new Exception($"{typeof(Item)} with id {id} not found.");
            //    //throw new NotFoundException($"{typeof(Item)} with id {id} not found.");
            //    //throw new OperationResponse().NotFoundOperation($"{typeof(Item)} with id {id} not found.");
            //}
            return item;
        }

        public async Task<Item> AddAsync(Item entity)
        {
            _context.Items.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Item> UpdateAsync(Item entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }


        //public async Task<(IEnumerable<Item> Entities, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        //{
        //    var totalCount = await _context.Items.CountAsync();
        //    var items = await _context.Items
        //        .AsNoTracking()
        //        .Skip((pageNumber - 1) * pageSize)
        //    .Take(pageSize)
        //        .ToListAsync(cancellationToken);
        //}
        public async Task<(IEnumerable<Item> Entities, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var totalCount = await _context.Items.CountAsync();
            var items = await _context.Items
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return (items, totalCount);
        }
    }
}
