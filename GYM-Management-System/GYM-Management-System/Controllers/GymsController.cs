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
            return await _gym.GetGym(id);
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
        public async Task<ActionResult<Gym>> PostGym(PostGymDTO gym)
        {
            await _gym.CreateGym(gym);
            return CreatedAtAction("GetGym", new { id = gym.GymID }, gym);
        }

        // DELETE: api/Gyms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGym(int id)
        {
            await _gym.DeleteGym(id);
            return NoContent();
        }
        //// POST : api/Rooms/5/Amenity/5
        //[HttpPost]
        //[Route("{roomId}/Amenity/{amenityId}")]
        //public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        //{
        //    await _room.AddAmenityToRoom(roomId, amenityId);

        //    return NoContent();
        //}
        [HttpPost]
        [Route("{gymId}/Supplement/{SupplementId}")]
        public async Task<IActionResult> AddSupplementsToGym(int gymId, int SupplementId)
        {
            await _gym.AddSupplementToGym(gymId, SupplementId);

            return Ok();
        }
        [HttpPut]
        [Route("{gymId}/Supplement/{supplementId}")]
        public async Task<IActionResult> UpdateSupplementForGym(int gymId, int supplementId, UpdateGymSupplementDTO updateGymSupplemen)
        {
            var gymSupplement=await _gym.UpdateSupplementForGym(gymId, supplementId, updateGymSupplemen);

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
