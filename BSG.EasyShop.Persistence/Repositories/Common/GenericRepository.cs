using BSG.EasyShop.Application.Contracts.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace BSG.EasyShop.Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EasyShopDbContext _context;
        public GenericRepository(EasyShopDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<bool> Exist(long id)
        {
            var exists = await GetItemByKey(id);
            return exists != null;
        }

        public async Task<IReadOnlyList<T>> GetAllItems()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetItemByKey(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
                
    }
}
