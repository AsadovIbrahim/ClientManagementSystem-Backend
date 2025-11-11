using ClientManagementSystem.BL.Common;
using ClientManagementSystem.BL.DTOs.ClientGroup;

namespace ClientManagementSystem.BL.Interfaces
{
    public interface IClientGroupService
    {
        Task<Result<ClientGroupCreateDTO>> CreateClientGroupAsync(ClientGroupCreateDTO dto);
        Task<Result<ClientGroupDTO>> GetClientGroupByIdAsync(Guid id);
        Task<Result<IEnumerable<ClientGroupDTO>>> GetAllClientGroupsAsync(string?name=null);
        Task<Result<ClientGroupUpdateDTO>> UpdateClientGroupAsync(ClientGroupUpdateDTO dto);
        Task<Result<ClientGroupDTO>> DeleteClientGroupAsync(Guid id);

    }
}
