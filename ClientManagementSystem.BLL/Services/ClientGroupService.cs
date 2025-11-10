using ClientManagementSystem.BL.Common;
using ClientManagementSystem.BL.DTOs.ClientGroup;
using ClientManagementSystem.BL.Interfaces;
using ClientManagementSystem.DAL.Interfaces;
using ClientManagementSystem.DAL.Models.Concretes;
using Microsoft.Extensions.Logging;

namespace ClientManagementSystem.BL.Services
{
    public class ClientGroupService : IClientGroupService
    {
        protected readonly ILogger<ClientGroupService> _logger;
        protected readonly IClientGroupRepository _clientGroupRepository;
        public ClientGroupService(ILogger<ClientGroupService> logger, IClientGroupRepository clientGroupRepository)
        {
            _logger = logger;
            _clientGroupRepository = clientGroupRepository;
        }
        public async Task<Result<ClientGroupCreateDTO>> CreateClientGroupAsync(ClientGroupCreateDTO dto)
        {
            try
            {
                var clientGroup = new ClientGroup
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    Comment = dto.Comment
                };
                await _clientGroupRepository.AddAsync(clientGroup);
                dto = new ClientGroupCreateDTO
                {
                    Name = clientGroup.Name,
                    Code = clientGroup.Code,
                    Comment = clientGroup.Comment
                };
                return Result<ClientGroupCreateDTO>.Ok(dto, "Client group created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating client group");
                return Result<ClientGroupCreateDTO>.Fail("An error occurred while creating the client group.");
            }
        }

        public async Task<Result<ClientGroupDTO>> DeleteClientGroupAsync(Guid id)
        {
            try
            {
                var clientGroup = await _clientGroupRepository.GetByIdAsync(id);
                if (clientGroup == null)
                {
                    return Result<ClientGroupDTO>.Fail("Client group not found.");
                }
                await _clientGroupRepository.DeleteAsync(clientGroup);
                var clientGroupDto = new ClientGroupDTO
                {
                    Id = clientGroup.Id,
                    Name = clientGroup.Name,
                    Code = clientGroup.Code,
                    Comment = clientGroup.Comment
                };
                return Result<ClientGroupDTO>.Ok(clientGroupDto, "Client group deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting client group");
                return Result<ClientGroupDTO>.Fail("An error occurred while deleting the client group.");
            }
        }

        public async Task<Result<IEnumerable<ClientGroupDTO>>> GetAllClientGroupsAsync()
        {
            var clientGroups = await _clientGroupRepository.GetAllAsync();
            var clientGroupDtos = clientGroups.Select(cg => new ClientGroupDTO
            {
                Id = cg.Id,
                Name = cg.Name,
                Code = cg.Code,
                Comment = cg.Comment
            });
            return Result<IEnumerable<ClientGroupDTO>>.Ok(clientGroupDtos, "Client groups retrieved successfully.");
        }

        public async Task<Result<ClientGroupDTO>> GetClientGroupByIdAsync(Guid id)
        {
            try
            {
                var clientGroup = await _clientGroupRepository.GetByIdAsync(id);
                if (clientGroup == null)
                {
                    return Result<ClientGroupDTO>.Fail("Client group not found.");
                }
                var clientGroupDto = new ClientGroupDTO
                {
                    Id = clientGroup.Id,
                    Name = clientGroup.Name,
                    Code = clientGroup.Code,
                    Comment = clientGroup.Comment
                };
                return Result<ClientGroupDTO>.Ok(clientGroupDto, "Client group retrieved successfully.");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving client group");
                return Result<ClientGroupDTO>.Fail("An error occurred while retrieving the client group.");
            }
        }

        public async Task<Result<ClientGroupUpdateDTO>> UpdateClientGroupAsync(ClientGroupUpdateDTO dto)
        {
            try
            {
                var clientGroup = await _clientGroupRepository.GetByIdAsync(dto.Id);
                if (clientGroup == null)
                {
                    return Result<ClientGroupUpdateDTO>.Fail("Client group not found.");
                }
                clientGroup.Name = dto.Name ?? clientGroup.Name;
                clientGroup.Code = dto.Code ?? clientGroup.Code;
                clientGroup.Comment = dto.Comment ?? clientGroup.Comment;
                await _clientGroupRepository.UpdateAsync(clientGroup);
                dto = new ClientGroupUpdateDTO
                {
                    Id = clientGroup.Id,
                    Name = clientGroup.Name,
                    Code = clientGroup.Code,
                    Comment = clientGroup.Comment
                };
                return Result<ClientGroupUpdateDTO>.Ok(dto, "Client group updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating client group");
                return Result<ClientGroupUpdateDTO>.Fail("An error occurred while updating the client group.");
            }
        }
    }
}
