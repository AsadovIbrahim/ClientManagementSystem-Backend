using Microsoft.AspNetCore.Mvc;
using ClientManagementSystem.BL.Interfaces;
using ClientManagementSystem.BL.DTOs.ClientGroup;


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
        public async Task<IActionResult> GetAllClientGroups(string? name = null)
        {
            var clientGroups = await _clientGroupService.GetAllClientGroupsAsync(name);
            return Ok(clientGroups);
        }
        [HttpGet("getallclientgroupsbycharacter")]
        public async Task<IActionResult> GetAllClientGroupByCharacter(string? character=null)
        {
            var clientGroups = await _clientGroupService.GetAllClientGroupsByCharacterAsync(character);
            return Ok(clientGroups);
        }
        [HttpGet("getallclientgrouptree")]
        public async Task<IActionResult> GetAllClientGroupTree()
        {
            var clientGroupTree = await _clientGroupService.GetClientGroupTreeAsync();
            return Ok(clientGroupTree);
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
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(new { message = $"Client Group with {id} deleted succesffully." });

        }
    }
}
