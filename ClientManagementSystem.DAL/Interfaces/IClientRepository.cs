namespace ClientManagementSystem.DAL.Interfaces
{
    public interface IClientRepository: IGenericRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<IEnumerable<Client?>>GetClientByName(string name);
        Task<IEnumerable<Client>> GetClientsByGroupNameAsync(string groupName);
        Task<IEnumerable<Client>> GetClientsByCharacterNameAsync(string characterName);
    }
}
