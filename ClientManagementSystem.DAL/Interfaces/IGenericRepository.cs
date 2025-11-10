using ClientManagementSystem.DAL.Models.Common;

namespace ClientManagementSystem.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteById(Guid id);
        Task SaveChangesAsync();
    }
}
