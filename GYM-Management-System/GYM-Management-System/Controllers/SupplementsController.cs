﻿using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Management_System.Controllers
{
    /// <summary>
    /// API controller for managing supplements in the gym management system.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplementsController : ControllerBase
    {
        private readonly ISupplement _supplements;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplementsController"/> class.
        /// </summary>
        /// <param name="supplements">The supplement data access context.</param>
        public SupplementsController(ISupplement supplements)
        {
            _supplements = supplements;
        }

        /// <summary>
        /// Retrieves a list of supplements (accessible to all users).
        /// </summary>
        /// <returns>A list of supplements.</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplementDTO>>> GetSupplementsBackEnd()
        {
            var supplements = await _supplements.GetAllSupplements();
            if (supplements == null || !supplements.Any())
            {
                return NotFound("No supplements found.");
            }

            return Ok(supplements);
        }

        /// <summary>
        /// Retrieves supplement details by its ID (accessible to all users).
        /// </summary>
        /// <param name="id">The ID of the supplement.</param>
        /// <returns>The supplement details.</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplementDTO>> GetSupplementBackEnd(int id)
        {
            var supplement = await _supplements.GetSupplementById(id);
            if (supplement == null)
            {
                return NotFound("Supplement not found.");
            }

            return Ok(supplement);
        }

        /// <summary>
        /// Updates supplement details by its ID (accessible to Admin role).
        /// </summary>
        /// <param name="id">The ID of the supplement to update.</param>
        /// <param name="supplement">The updated supplement data.</param>
        /// <returns>The updated supplement data.</returns>
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<SupplementDTO>> PutSupplementBackEnd(int id, CreatSupplementDTO supplement)
        {
            var updatedSupplement = await _supplements.UpdateSupplement(id, supplement);

            if (updatedSupplement == null)
            {
                return NotFound("Supplement not found.");
            }

            return Ok(updatedSupplement);
        }

        /// <summary>
        /// Creates a new supplement (accessible to Admin role).
        /// </summary>
        /// <param name="supplement">The supplement data to create.</param>
        /// <returns>The created supplement data.</returns>
       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<SupplementDTO>> PostSupplementBackEnd(CreatSupplementDTO supplement)
        {
            try
            {
                var supplementDto = await _supplements.CreateSupplement(supplement);
                return CreatedAtAction(nameof(GetSupplementBackEnd), new { id = supplementDto.SupplementID }, supplementDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the supplement.");
            }
        }

        /// <summary>
        /// Deletes a supplement by its ID (accessible to users with the 'deleteAdmin' policy).
        /// </summary>
        /// <param name="id">The ID of the supplement to delete.</param>
        /// <returns>A message indicating the deletion status.</returns>
       // [Authorize(Policy = "deleteAdmin")]
        [HttpDelete("{id}")]
        public async Task<string> DeleteSupplementBackEnd(int id)
        {
            bool result = await _supplements.DeleteSupplement(id);
            if (result == true)
            {
                return "Deleted Successfully!";
            }
            return "Action Failed";
        }
    }
}
