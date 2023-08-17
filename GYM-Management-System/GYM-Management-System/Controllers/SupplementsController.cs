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
    public class SupplementsController : ControllerBase
    {
        private readonly ISupplement _supplements;

        public SupplementsController(ISupplement supplements)
        {
            _supplements = supplements;
        }

        // GET: api/Supplements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplementDTO>>> GetSupplements()
        {
            if (_supplements == null)
            {
                return NotFound();
            }
            return await _supplements.GetAllSupplements();
        }

        // GET: api/Supplements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplementDTO>> GetSupplement(int id)
        {
            if (_supplements == null)
            {
                return NotFound();
            }
            var supplements = await _supplements.GetSupplementById(id);
            if (supplements == null)
            {
                return NotFound();
            }
            return supplements;
        }

        // PUT: api/Supplements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplement([FromRoute] int id, [FromBody] SupplementDTO supplement)
        {
            if (id != supplement.SupplementID)
            {
                return BadRequest();
            }
            var updatedSupplement = await _supplements.UpdateSupplement(id, supplement);

            return Ok(updatedSupplement);
        }




        // POST: api/Supplements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SupplementDTO>> PostSupplement(SupplementDTO supplement)
        {

            if (_supplements == null)
            {
                return Problem("Entity set 'GymDbContext.Supplement'  is null.");
            }
            await _supplements.CreateSupplement(supplement);
            return CreatedAtAction("GetSupplement", new
            {
                id = supplement.SupplementID,
            }, supplement);
        }

        // DELETE: api/Supplements/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteSupplement(int id)
        {

            var result = await _supplements.DeleteSupplement(id);
            if (result == true)
            {
                return "Deleted Succesfully!";
            }
            return "Action Failed";
        }


    }
}
