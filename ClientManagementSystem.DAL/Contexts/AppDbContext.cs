using Microsoft.EntityFrameworkCore;
using ClientManagementSystem.DAL.Models.Concretes;

namespace ClientManagementSystem.DAL.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientGroup> ClientGroups { get; set; }
    }
}
