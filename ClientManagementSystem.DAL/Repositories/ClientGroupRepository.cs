using Microsoft.EntityFrameworkCore;
using ClientManagementSystem.DAL.Contexts;
using ClientManagementSystem.DAL.Interfaces;
using ClientManagementSystem.DAL.Models.Concretes;

namespace ClientManagementSystem.DAL.Repositories
{
    public class ClientGroupRepository : GenericRepository<ClientGroup>, IClientGroupRepository
    {
        public ClientGroupRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ClientGroup>> GetAllClients()
        {
            return await _table
                .Include(c=>c.ParentGroup)
                .Include(c=>c.ChildGroups)
                .ToListAsync();
        }

        public async Task<IEnumerable<ClientGroup?>> GetClientsByName(string name)
        {
            return await _table
                .Include(c=>c.ParentGroup)
                .Where(cg=>cg.Name==name)
                .ToListAsync();
        }
    }
}
