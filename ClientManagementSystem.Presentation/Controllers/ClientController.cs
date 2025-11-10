using ClientManagementSystem.BL.DTOs.Client;
using ClientManagementSystem.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagementSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        protected readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet("getallclients")]
        public async Task<IActionResult> GetAllClients(string? name = null)
        {
            var clients = await _clientService.GetAllClientsAsync(name);
            return Ok(clients);
        }
        [HttpPost("create-client")]
        public async Task<IActionResult> CreateClient([FromBody] ClientCreateDTO clientCreateDTO)
        {
            var createdClient = await _clientService.CreateClientAsync(clientCreateDTO);
            return Ok(createdClient);
        }
        [HttpPut("update-client")]
        public async Task<IActionResult> UpdateClient([FromBody] ClientUpdateDTO clientUpdateDTO)
        {
            var updatedClient = await _clientService.UpdateClientAsync(clientUpdateDTO);
            return Ok(updatedClient);
        }
        [HttpDelete("delete-client/{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var result = await _clientService.DeleteClientAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(new { message = $"Client with {id} deleted succesffully." });
        }
        [HttpDelete("delete-multipleclients")]
        public async Task<IActionResult> DeleteMultipleClients([FromBody] IEnumerable<Guid> ids)
        {
            var result = await _clientService.DeleteMultipleClientsAsync(ids);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(new { message = "Clients deleted successfully." });
        }

    }
}
