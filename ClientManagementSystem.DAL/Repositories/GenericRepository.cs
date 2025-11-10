using ClientManagementSystem.DAL.Contexts;
using ClientManagementSystem.DAL.Interfaces;
using ClientManagementSystem.DAL.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementSystem.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected readonly DbSet<T> _table;
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var entity=_table.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _table.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _table.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
