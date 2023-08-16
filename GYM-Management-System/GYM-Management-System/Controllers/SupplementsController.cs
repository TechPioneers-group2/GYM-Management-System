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
        public async Task<ActionResult<IEnumerable<GetSupplementDTO>>> GetSupplements()
        {
            return await _supplements.GetAllSupplements();
        }

        // GET: api/Supplements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSupplementDTO>> GetSupplement(int id)
        {
            return await _supplements.GetSupplementById(id);
        }

        // PUT: api/Supplements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplement(int id, UpdateSupplementDTO supplement)
        {
            var updatedSupplement = await _supplements.UpdateSupplement(id, supplement);

            return Ok(updatedSupplement);
        }




        // POST: api/Supplements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetSupplementDTO>> PostSupplement(GetSupplementDTO supplement)
        {
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
