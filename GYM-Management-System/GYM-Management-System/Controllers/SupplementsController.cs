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
                return NotFound("No supplements found.");
            }

            var supplements = await _supplements.GetAllSupplements();
            if (supplements == null || !supplements.Any())
            {
                return NotFound("No supplements found.");
            }

            return supplements;
        }

        // GET: api/Supplements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplementDTO>> GetSupplement(int id)
        {
            if (_supplements == null)
            {
                return NotFound("Supplements data not available.");
            }

            var supplement = await _supplements.GetSupplementById(id);
            if (supplement == null)
            {
                return NotFound("Supplement not found.");
            }

            return supplement;
        }


        // PUT: api/Supplements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<SupplementDTO>> PutSupplement(int id, CreatSupplementDTO supplement)
        {
            var updatedSupplement = await _supplements.UpdateSupplement(id, supplement);

            if (updatedSupplement == null)
            {
                return NotFound("Supplement not found.");
            }

            return updatedSupplement;
        }





        // POST: api/Supplements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SupplementDTO>> PostSupplement(CreatSupplementDTO supplement)
        {
            try
            {
                var supplementDto = await _supplements.CreateSupplement(supplement);
                return CreatedAtAction(nameof(GetSupplement), new { id = supplementDto.SupplementID }, supplementDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the supplement.");
            }
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
