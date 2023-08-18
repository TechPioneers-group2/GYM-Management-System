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
    public class GymsController : ControllerBase
    {
        private readonly IGym _gym;

        public GymsController(IGym context)
        {
            _gym = context;
        }

        // GET: api/Gyms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserGymDTO>>> GetGyms()
        {
            return await _gym.GetGyms();
        }

        // GET: api/Gyms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserGymDTO>> GetGym(int id)
        {
            var gym = await _gym.GetGym(id);

            if (gym != null)
            {
                return gym;
            }
            return NotFound();
        }

        // PUT: api/Gyms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGym(int id, PutGymDTO gym)
        {
            var updatedgym = await _gym.UpdateGym(id, gym);
            return Ok(updatedgym);
        }

        // POST: api/Gyms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostGymDTO>> PostGym(PostGymDTO gym)
        {
            var newGym = await _gym.CreateGym(gym);
            if (newGym == null)
            {
                return BadRequest();
            }
            return Ok(newGym);
        }


        // DELETE: api/Gyms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGym(int id)
        {
            await _gym.DeleteGym(id);
            return NoContent();
        }

        [HttpPost]
        [Route("{gymId}/Supplement/{SupplementId}")]
        public async Task<IActionResult> AddSupplementsToGym(int gymId, int SupplementId, int quantity)
        {
            await _gym.AddSupplementToGym(gymId, SupplementId, quantity);

            return Ok();
        }
        [HttpPut]
        [Route("{gymId}/Supplement/{supplementId}")]
        public async Task<IActionResult> UpdateSupplementForGym(int gymId, int supplementId, UpdateGymSupplementDTO updateGymSupplemen)
        {
            var gymSupplement = await _gym.UpdateSupplementForGym(gymId, supplementId, updateGymSupplemen);

            return Ok();

        }

        [HttpDelete]
        [Route("{gymId}/Supplement/{supplementId}")]
        public async Task<IActionResult> RemoveSupplementFromGym(int gymId, int supplementId)
        {
            await _gym.RemoveSupplementFromGym(gymId, supplementId);

            return NoContent();
        }
    }
}
