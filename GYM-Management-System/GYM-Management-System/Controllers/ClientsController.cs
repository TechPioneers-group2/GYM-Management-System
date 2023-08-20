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

        [Authorize(Roles = "Admin, Employee")]
        [HttpGet("{gymid}")]
        public async Task<ActionResult<IEnumerable<GetClientDTO>>> GetClients(int gymid)
        {
            return await _client.GetClients(gymid);
        }

        // GET: api/Clients/5

        [Authorize(Roles = "Admin, Employee")]
        [HttpGet("{clientid}/gym/{gymid}")]
        public async Task<ActionResult<GetClientDTO>> GetClient(int clientid, int gymid)
        {
            return await _client.GetClient(clientid, gymid);
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize(Roles = "Admin, Employee")]
        [HttpPut("{clientid}/gym/{gymid}")]
        public async Task<IActionResult> PutClient(int clientid, int gymid, UpdateClientDTO client)
        {
            var updatedClient = await _client.UpdateClient(clientid, gymid, client);
            return Ok(updatedClient);
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

       [Authorize(Roles = "Admin, Employee")]
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
        [Authorize(Roles = "Admin, Employee")]
        [HttpDelete("{clientid}/gym/{gymid}")]
        public async Task<IActionResult> DeleteClient(int clientid, int gymid)
        {
            await _client.DeleteClient(clientid, gymid);
            return NoContent();
        }
    }
}
