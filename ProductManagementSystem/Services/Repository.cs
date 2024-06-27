using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Model;
using ProductManagementSystem.Model.Entities;

namespace ProductManagementSystem.Services
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EFContext _context;

        public Repository(EFContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            if (id != entity.Id)
                throw new ArgumentException("Entity ID mismatch");

            if (!await ExistsAsync(id))
                throw new InvalidOperationException("Entity does not exist");

            entity.ModificationDate = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id == id);
        }

        public async Task<bool> TrySaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch { }

            return false;
        }
    }
}
