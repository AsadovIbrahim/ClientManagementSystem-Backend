using ClientManagementSystem.DAL.Contexts;
using ClientManagementSystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementSystem.DAL.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _table
                .Include(c => c.ClientGroup)
                .ToListAsync();
        }

        public async Task<IEnumerable<Client?>> GetClientByName(string name)
        {
            return await _table
                .Include(c => c.ClientGroup)
                .Where(c => c.ClientGroup.Name == name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsByGroupNameAsync(string groupName)
        {
            return await _table
                .Include(c => c.ClientGroup)
                .Where(c => c.ClientGroup.Name == groupName)
                .ToListAsync();
        }
    }
}
