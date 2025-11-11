using ClientManagementSystem.DAL.Models.Concretes;

namespace ClientManagementSystem.DAL.Interfaces
{
    public interface IClientGroupRepository: IGenericRepository<ClientGroup>
    {
        Task<IEnumerable<ClientGroup?>> GetClientsByName(string name);
        Task<IEnumerable<ClientGroup>> GetAllClients();
    }
}
