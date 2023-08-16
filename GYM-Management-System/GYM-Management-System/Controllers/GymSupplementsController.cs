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
    public class GymSupplementsController : ControllerBase
    {
        private readonly IGymSupplement _gymSupplements;

        public GymSupplementsController(IGymSupplement gymSupplemet)
        {
            _gymSupplements = gymSupplemet;
        }

        // GET: api/GymSupplements
        [HttpGet("{gymId}")]
        public async Task<ActionResult<IEnumerable<GetGymSupplementDTO>>> GetGymSupplements(int gymId)
        {
            return await _gymSupplements.GetAllGymSupplements(gymId);

        }

        // GET: api/GymSupplements/5
        [HttpGet("{gymId}/{supplementId}")]
        public async Task<ActionResult<GetGymSupplementDTO>> GetGymSupplement(int gymId, int supplementId)
        {
            return await _gymSupplements.GetGymSupplementById(gymId, supplementId);
        }

        // PUT: api/GymSupplements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{gymId}/{supplementId}")]
        public async Task<IActionResult> PutGymSupplement(int gymId, int supplementId, PostGymSupplementDTO updatedGymSupplementDTO)
        {
            var updatedGym = await _gymSupplements.UpdateGymSupplement(gymId, supplementId, updatedGymSupplementDTO);
            return Ok(updatedGym);
        }

        // POST: api/GymSupplements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{gymId}/{supplementId}")]
        public async Task<ActionResult<PostGymSupplementDTO>> PostGymSupplement(int gymId, int supplementId, PostGymSupplementDTO gymSupplementDTO)
        {
            await _gymSupplements.CreateGymSupplement(gymId, supplementId, gymSupplementDTO);
            return CreatedAtAction("GetGymSupplement", new
            {
                gymId = gymSupplementDTO.GymID,
                supplementId = gymSupplementDTO.SupplementID,
            }, gymSupplementDTO);
        }

        // DELETE: api/GymSupplements/5
        [HttpDelete("{gymId}/{supplementId}")]
        public async Task<string> DeleteGymSupplement(int gymId, int supplementId)
        {
            var result = await _gymSupplements.DeleteGymSupplement(gymId, supplementId);
            if (result == true)
            {
                return "Deleted Succesfully!";
            }
            return "Action Failed";
        }


    }
}
