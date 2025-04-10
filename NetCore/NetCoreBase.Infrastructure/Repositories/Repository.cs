//using Microsoft.EntityFrameworkCore;
//using NetCoreBase.Domain.Interfaces.Common;
//using NetCoreBase.Infrastructure.Data.Postgresql;

//namespace NetCoreBase.Infrastructure.DataAccess
//{
//    public class Repository<T> : IRepository<T> where T : class
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly DbSet<T> _dbSet;

//        public Repository(ApplicationDbContext context)
//        {
//            _context = context;
//            _dbSet = context.Set<T>();
//        }

//        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
//        {
//            return await _dbSet.ToListAsync(cancellationToken);
//        }

//        public async Task<T> GetByIdAsync(int id)
//        {
//            var entity = await _dbSet.FindAsync(id);
//            if (entity == null)
//            {
//                throw new KeyNotFoundException($"Entity with ID {id} was not found.");
//            }
//            return entity;
//        }

//        public async Task<T> GetByIdAsyncNoTracking(int id)
//        {
//            var entity = await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
//            if (entity == null)
//            {
//                throw new KeyNotFoundException($"Entity with ID {id} was not found.");
//            }
//            return entity;
//        }

//        public async Task<T> AddAsync(T entity)
//        {
//            await _dbSet.AddAsync(entity);
//            await _context.SaveChangesAsync();
//            return entity;
//        }

//        public async Task<T> UpdateAsync(T entity)
//        {
//            _dbSet.Update(entity);
//            await _context.SaveChangesAsync();
//            return entity;
//        }

//        public async Task<bool> DeleteAsync(long id)
//        {
//            var entity = await _dbSet.FindAsync(id);
//            if (entity == null)
//            {
//                return false;
//            }

//            _dbSet.Remove(entity);
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        public async Task<(IEnumerable<T> Entities, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
//        {
//            var totalCount = await _dbSet.CountAsync();
//            var entities = await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
//            return (entities, totalCount);
//        }
//    }
//}