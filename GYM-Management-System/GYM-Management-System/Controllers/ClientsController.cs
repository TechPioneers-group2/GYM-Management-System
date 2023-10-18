using GYM_Management_System.Models;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Management_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsController"/> class.
        /// </summary>
        /// <param name="context">The client data access context.</param>
        public ClientsController(IClient context)
        {
            _client = context;
        }

        // GET: api/Clients

        /// <summary>
        /// Retrieves a list of clients associated with a specific gym.
        /// </summary>
        /// <param name="gymid">The ID of the gym to retrieve clients for.</param>
        /// <returns>A list of clients.</returns>

        //[Authorize(Roles = "Admin, Employee")]
        [HttpGet("gym/{gymid}")]
        public async Task<ActionResult<IEnumerable<GetClientDTO>>> GetClients(int gymid)
        {
            return Ok(await _client.GetClients(gymid));
        }
        // GET: api/Clients/5

        /// <summary>
        /// Retrieves a client's details by their ID and associated gym ID.
        /// </summary>
        /// <param name="clientid">The ID of the client.</param>
        /// <param name="gymid">The ID of the gym the client is associated with.</param>
        /// <returns>The client's details.</returns>

        //[Authorize(Roles = "Admin, Employee")]
        [HttpGet("{clientid}/gym/{gymid}")]
        public async Task<ActionResult<GetClientDTO>> GetClient(int clientid, int gymid)
        {
            return Ok(await _client.GetClient(clientid, gymid));
        }

        // PUT: api/Clients/5

        /// <summary>
        /// Updates a client's details by their ID and associated gym ID.
        /// </summary>
        /// <param name="clientid">The ID of the client to update.</param>
        /// <param name="gymid">The ID of the gym the client is associated with.</param>
        /// <param name="client">The updated client data.</param>
        /// <returns>The updated client data.</returns>




        // [Authorize(Roles = "Admin, Employee")]

        [HttpPut("{clientid}/gym/{gymid}")]
        public async Task<IActionResult> PutClient(int clientid, int gymid, UpdateClientDTO client)
        {
            var updatedClient = await _client.UpdateClient(clientid, gymid, client);
            return Ok(updatedClient);
        }



        // POST: api/Clients

        /// <summary>
        /// Creates a new client associated with a specific gym.
        /// </summary>
        /// <param name="gymid">The ID of the gym to associate the client with.</param>
        /// <param name="clientDto">The client data to create.</param>
        /// <returns>The created client data.</returns>



        [Authorize(Roles = "Admin, Employee")]
        [HttpPost("Deprecated/{gymid}")]
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

        /// <summary>
        /// Deletes a client by their ID and associated gym ID.
        /// </summary>
        /// <param name="clientid">The ID of the client to delete.</param>
        /// <param name="gymid">The ID of the gym the client is associated with.</param>
        /// <returns>No content if the client was successfully deleted.</returns>

       // [Authorize(Roles = "Admin, Employee")]
        [HttpDelete("{clientid}/gym/{gymid}")]
        public async Task<IActionResult> DeleteClient(int clientid, int gymid)
        {
            await _client.DeleteClient(clientid, gymid);
            return NoContent();
        }
    }

}
