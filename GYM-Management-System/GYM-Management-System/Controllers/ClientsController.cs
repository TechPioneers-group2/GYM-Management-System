using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GYM_Management_System.Data;
using GYM_Management_System.Models;
using GYM_Management_System.Models.Interfaces;
using GYM_Management_System.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace GYM_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClient _client;

        public ClientsController(IClient context)
        {
            _client = context;
        }

        // GET: api/Clients

        [Authorize(Policy = "readAdmin")]
        [Authorize(Policy = "readEmployee")]
        [HttpGet("{gymid}")]
        public async Task<ActionResult<IEnumerable<GetClientDTO>>> GetClients(int gymid)
        {
            return await _client.GetClients(gymid);
        }

        // GET: api/Clients/5

        [Authorize(Policy = "readAdmin")]
        [Authorize(Policy = "readEmployee")]
        [HttpGet("/api/client/{clientid}/gym/{gymid}")]
        public async Task<ActionResult<GetClientDTO>> GetClient(int clientid, int gymid)
        {
            return await _client.GetClient(clientid, gymid);
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize(Policy = "updateAdmin")]
        [Authorize(Policy = "updateEmployee")]
        [HttpPut("{gymid}/{clientid}")]
        public async Task<IActionResult> PutClient(int gymid, int clientid, UpdateClientDTO client)
        {
            var updatedClient = await _client.UpdateClient(gymid, clientid, client);
            return Ok(updatedClient);
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize(Policy = "createAdmin")]
        [Authorize(Policy = "createEmployee")]
        [HttpPost("{gymid}")]
        public async Task<ActionResult<Client>> PostClient(int gymid, PostClientDTO clientDto)
        {
            var createdClient = await _client.CreateClient(gymid, clientDto);

            
            if (createdClient != null)
            {
                // Set the properties of the clientDto object with the values returned from the CreateClient method
                clientDto.SubscriptionDate = createdClient.SubscriptionDate;
                clientDto.SubscriptionExpiry = createdClient.SubscriptionExpiry;

                return CreatedAtAction("GetClient", new { gymid = createdClient.GymID, clientid = createdClient.ClientID }, clientDto);
            }

            
            return BadRequest("Failed to create client");
        }

        // DELETE: api/Clients/5
        [Authorize(Policy = "deleteAdmin")]
        [Authorize(Policy = "deleteEmployee")]
        [HttpDelete("/api/Gym/{gymid}/Client/{clientid}")]
        public async Task<IActionResult> DeleteClient(int gymid, int clientid)
        {
            await _client.DeleteClient(gymid, clientid);
            return NoContent();
        }
    }
}
