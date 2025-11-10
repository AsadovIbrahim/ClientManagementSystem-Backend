namespace ClientManagementSystem.DAL.Interfaces
{
    public interface IClientRepository: IGenericRepository<Client>
    {
        Task<IEnumerable<Client?>>GetClientByName(string name);
        Task<IEnumerable<Client>> GetAllClientsAsync();
    }
}
