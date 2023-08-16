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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetClientDTO>>> GetClients()
        {
            return await _client.GetClients();
        }

        // GET: api/Clients/5
        [HttpGet("{gymid}/{clientid}")]
        public async Task<ActionResult<GetClientDTO>> GetClient(int gymid, int clientid)
        {
            return await _client.GetClient(gymid, clientid);
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int gymid, int clientid, UpdateClientDTO client)
        {
            var updatedClient = await _client.UpdateClient(gymid, clientid, client);
            return Ok(updatedClient);

        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(PostClientDTO client)
        {
            await _client.CreateClient(client);
            return CreatedAtAction("GetClient", new { gymid = client.GymID, clientid = client.ClientID }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int gymid, int clientid)
        {
            await _client.DeleteClient(gymid, clientid);
            return NoContent();
        }

    }
}
