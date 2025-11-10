using ClientManagementSystem.BL.DTOs.ClientGroup;
using ClientManagementSystem.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagementSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientGroupController : ControllerBase
    {
        protected readonly IClientGroupService _clientGroupService;
        public ClientGroupController(IClientGroupService clientGroupService)
        {
            _clientGroupService = clientGroupService;
        }
        [HttpGet("getallclientgroups")]
        public async Task<IActionResult> GetAllClientGroups()
        {
            var clientGroups = await _clientGroupService.GetAllClientGroupsAsync();
            return Ok(clientGroups);
        }
        [HttpPost("create-clientgroup")]
        public async Task<IActionResult> CreateClientGroup([FromBody] ClientGroupCreateDTO clientGroupCreateDTO)
        {
            var createdClientGroup = await _clientGroupService.CreateClientGroupAsync(clientGroupCreateDTO);
            return Ok(createdClientGroup);
        }
        [HttpPut("update-clientgroup")]
        public async Task<IActionResult> UpdateClientGroup([FromBody] ClientGroupUpdateDTO clientGroupUpdateDTO)
        {
            var updatedClientGroup = await _clientGroupService.UpdateClientGroupAsync(clientGroupUpdateDTO);
            return Ok(updatedClientGroup);
        }
        [HttpDelete("delete-clientgroup/{id}")]
        public async Task<IActionResult> DeleteClientGroup(Guid id)
        {

            var result = await _clientGroupService.DeleteClientGroupAsync(id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(new {message=$"Client Group with {id} deleted succesffully."});

        }
    }
}
