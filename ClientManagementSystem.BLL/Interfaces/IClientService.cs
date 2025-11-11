using ClientManagementSystem.BL.Common;
using ClientManagementSystem.BL.DTOs.Client;

namespace ClientManagementSystem.BL.Interfaces
{
    public interface IClientService
    {
        Task<Result<ClientCreateDTO>> CreateClientAsync(ClientCreateDTO dto);
        Task<Result<ClientDTO>> GetClientByIdAsync(Guid id);
        Task<Result<IEnumerable<ClientDTO>>> GetAllClientsAsync(string? name = null);
        Task<Result<IEnumerable<ClientDTO>>> GetClientsByGroupNameAsync(string groupName);
        Task<Result<ClientUpdateDTO>> UpdateClientAsync(ClientUpdateDTO dto);
        Task<Result<ClientDTO>> DeleteClientAsync(Guid id);
        Task<Result<bool>> DeleteMultipleClientsAsync(IEnumerable<Guid> ids);
        Task<Result<IEnumerable<ClientDTO>>>GetClientsByCharacterNameAsync(string? characterName=null);    



    }
}
