using ClientManagementSystem.BL.Common;
using ClientManagementSystem.BL.DTOs.Client;
using ClientManagementSystem.BL.Interfaces;
using ClientManagementSystem.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace ClientManagementSystem.BL.Services
{
    public class ClientService : IClientService
    {
        protected readonly ILogger<ClientService> _logger;
        protected readonly IClientRepository _clientRepository;

        public ClientService(ILogger<ClientService> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }
        public async Task<Result<ClientCreateDTO>> CreateClientAsync(ClientCreateDTO dto)
        {
            try
            {
                var client = new Client
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    Comment = dto.Comment,
                    ClientGroupId = dto.ClientGroupId
                };
                await _clientRepository.AddAsync(client);
                dto = new ClientCreateDTO
                {
                    Name = client.Name,
                    Code = client.Code,
                    Comment = client.Comment,
                    ClientGroupId = client.ClientGroupId,
                };
                return Result<ClientCreateDTO>.Ok(dto, "Client created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating client");
                return Result<ClientCreateDTO>.Fail("An error occurred while creating the client.");
            }
        }

        public async Task<Result<ClientDTO>> DeleteClientAsync(Guid id)
        {
            try
            {
                var client = await _clientRepository.GetByIdAsync(id);
                if (client == null)
                {
                    return Result<ClientDTO>.Fail("Client not found.");
                }
                await _clientRepository.DeleteAsync(client);
                var clientDto = new ClientDTO
                {
                    Id = client.Id,
                    Name = client.Name,
                    Code = client.Code,
                    Comment = client.Comment,
                    ClientGroupId = client.ClientGroupId,
                    GroupName = client.ClientGroup?.Name!
                };
                return Result<ClientDTO>.Ok(clientDto, "Client deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting client");
                return Result<ClientDTO>.Fail("An error occurred while deleting the client.");
            }
        }

        public async Task<Result<bool>> DeleteMultipleClientsAsync(IEnumerable<Guid> ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    var client = await _clientRepository.GetByIdAsync(id);
                    if (client != null)
                    {
                        await _clientRepository.DeleteAsync(client);
                    }
                }
                return Result<bool>.Ok(true, "Clients deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting multiple clients");
                return Result<bool>.Fail("An error occurred while deleting multiple clients.");
            }
        }

        public async Task<Result<IEnumerable<ClientDTO>>> GetAllClientsAsync(string? name = null)
        {
            try
            {
                var clients = string.IsNullOrEmpty(name)
                    ? await _clientRepository.GetAllClientsAsync()
                    : await _clientRepository.GetClientByName(name);

                var clientDtos = clients.Select(client => new ClientDTO
                {
                    Id = client.Id,
                    Name = client.Name,
                    Code = client.Code,
                    Comment = client.Comment,
                    ClientGroupId = client.ClientGroupId,
                    GroupName = client.ClientGroup?.Name!
                });
                return Result<IEnumerable<ClientDTO>>.Ok(clientDtos, "Clients retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving clients");
                return Result<IEnumerable<ClientDTO>>.Fail("An error occurred while retrieving clients.");
            }
        }

        public async Task<Result<ClientDTO>> GetClientByIdAsync(Guid id)
        {
            try
            {
                var client = await _clientRepository.GetByIdAsync(id);
                if (client == null)
                {
                    return Result<ClientDTO>.Fail("Client not found.");
                }
                var clientDto = new ClientDTO
                {
                    Id = client.Id,
                    Name = client.Name,
                    Code = client.Code,
                    Comment = client.Comment,
                    ClientGroupId = client.ClientGroupId,
                    GroupName = client.ClientGroup?.Name!
                };
                return Result<ClientDTO>.Ok(clientDto, "Client retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving client by ID");
                return Result<ClientDTO>.Fail("An error occurred while retrieving the client.");
            }
        }

        public async Task<Result<IEnumerable<ClientDTO>>> GetClientsByCharacterNameAsync(string? characterName=null)
        {
            try
            {

                var clients=string.IsNullOrEmpty(characterName)
                    ? await _clientRepository.GetAllClientsAsync()
                    : await _clientRepository.GetClientsByCharacterNameAsync(characterName);
                var clientDtos = clients.Select(client => new ClientDTO
                {
                    Id = client.Id,
                    Name = client.Name,
                    Code = client.Code,
                    Comment = client.Comment,
                    ClientGroupId = client.ClientGroupId,
                    GroupName = client.ClientGroup?.Name!
                });
                return Result<IEnumerable<ClientDTO>>.Ok(clientDtos, "Clients retrieved successfully.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving clients by character name");
                return Result<IEnumerable<ClientDTO>>.Fail("An error occurred while retrieving clients by character name.");
            }
        }

        public async Task<Result<IEnumerable<ClientDTO>>> GetClientsByGroupNameAsync(string groupName)
        {
            try
            {
                var clients = await _clientRepository.GetClientsByGroupNameAsync(groupName);
                var clientDtos = clients.Select(client => new ClientDTO
                {
                    Id = client.Id,
                    Name = client.Name,
                    Code = client.Code,
                    Comment = client.Comment,
                    ClientGroupId = client.ClientGroupId,
                    GroupName = client.ClientGroup?.Name!
                });
                return Result<IEnumerable<ClientDTO>>.Ok(clientDtos, "Clients retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving clients by group name");
                return Result<IEnumerable<ClientDTO>>.Fail("An error occurred while retrieving clients by group name.");
            }
        }

        public async Task<Result<ClientUpdateDTO>> UpdateClientAsync(ClientUpdateDTO dto)
        {
            try
            {
                var client = await _clientRepository.GetByIdAsync(dto.Id);
                if (client == null)
                {
                    return Result<ClientUpdateDTO>.Fail("Client not found.");
                }
                client.Name = dto.Name ?? client.Name;
                client.Code = dto.Code ?? client.Code;
                client.Comment = dto.Comment ?? client.Comment;
                client.ClientGroupId = dto.ClientGroupId;
                await _clientRepository.UpdateAsync(client);
                dto = new ClientUpdateDTO
                {
                    Id = client.Id,
                    Name = client.Name,
                    Code = client.Code,
                    Comment = client.Comment,
                    ClientGroupId = client.ClientGroupId
                };
                return Result<ClientUpdateDTO>.Ok(dto, "Client updated successfully.");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating client");
                return Result<ClientUpdateDTO>.Fail("An error occurred while updating the client.");

            }
        }
    }
}
