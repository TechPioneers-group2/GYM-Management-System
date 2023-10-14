using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Management_System.Controllers
{
    /// <summary>
    /// API controller for managing gyms in the gym management system.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GymsController : ControllerBase
    {
        private readonly IGym _gym;

        /// <summary>
        /// Initializes a new instance of the <see cref="GymsController"/> class.
        /// </summary>
        /// <param name="context">The gym data access context.</param>
        public GymsController(IGym context)
        {
            _gym = context;
        }

        /// <summary>
        /// Retrieves a list of gyms for gym managers.
        /// </summary>
        /// <returns>A list of gyms managed by users with manager roles.</returns>
        /// 

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<GetManagerGymDTO>>> GetGymManager()
        {
            return Ok(await _gym.GetGymManger());
        }

        /// <summary>
        /// Retrieves a list of gyms (accessible to all users).
        /// </summary>
        /// <returns>A list of gyms.</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserGymDTO>>> GetGyms()
        {
            return Ok(await _gym.GetGyms());
        }

        /// <summary>
        /// Retrieves gym details by its ID (accessible to all users).
        /// </summary>
        /// <param name="id">The ID of the gym.</param>
        /// <returns>The gym details.</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserGymDTO>> GetGym(int id)
        {
            var gym = await _gym.GetGym(id);

            if (gym != null)
            {
                return Ok(gym);
            }

            return NotFound();
        }

        /// <summary>
        /// Updates gym details by its ID (accessible to Admin role).
        /// </summary>
        /// <param name="id">The ID of the gym to update.</param>
        /// <param name="gym">The updated gym data.</param>
        /// <returns>The updated gym data.</returns>
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGym(int id, PutGymDTO gym)
        {
            var updatedGym = await _gym.UpdateGym(id, gym);
            return Ok(updatedGym);
        }

        /// <summary>
        /// Creates a new gym (accessible to Admin role).
        /// </summary>
        /// <param name="gym">The gym data to create.</param>
        /// <returns>The created gym data.</returns>

        [Authorize(Roles = "Admin")]
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

        /// <summary>
        /// Deletes a gym by its ID (accessible to Admin role).
        /// </summary>
        /// <param name="id">The ID of the gym to delete.</param>
        /// <returns>No content if the gym was successfully deleted.</returns>
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGym(int id)
        {
            await _gym.DeleteGym(id);
            return NoContent();
        }

        /// <summary>
        /// Adds supplements to a gym (accessible to Admin and Employee roles).
        /// </summary>
        /// <param name="gymId">The ID of the gym.</param>
        /// <param name="supplementId">The ID of the supplement to add.</param>
        /// <param name="newGymSupplement">The gym supplement data to add.</param>
        /// <returns>The added gym supplement data.</returns>
        /// 

        //[Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        [Route("{gymId}/Supplement/{SupplementId}")]
        public async Task<ActionResult<string>> AddSupplementsToGym(int gymId, int SupplementId, UpdateGymSupplementDTO newGymSupplement)
        {
            try
            {
                await _gym.AddSupplementToGym(gymId, SupplementId, newGymSupplement);


                string successMessage = "Supplement was added successfully.";

                return Ok(successMessage);
            }
            catch (Exception ex)
            {

                string errorMessage = "An error occurred while adding the supplement.";

                return StatusCode(500, errorMessage);
            }
        }



        /// <summary>
        /// Updates gym supplement details (accessible to Admin and Employee roles).
        /// </summary>
        /// <param name="gymId">The ID of the gym.</param>
        /// <param name="supplementId">The ID of the supplement to update.</param>
        /// <param name="updateGymSupplemen">The updated gym supplement data.</param>
        /// <returns>The updated gym supplement data.</returns>
        [Authorize(Roles = "Admin, Employee")]
        [HttpPut]
        [Route("{gymId}/Supplement/{supplementId}")]
        public async Task<ActionResult<string>> UpdateSupplementForGym(int gymId, int supplementId, UpdateGymSupplementDTO updateGymSupplement)
        {
            try
            {
                var gymSupplement = await _gym.UpdateSupplementForGym(gymId, supplementId, updateGymSupplement);

                if (gymSupplement == null)
                {
                    return NotFound();
                }

                return Ok("Updated successfully!");
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while updating the supplement.";

                return StatusCode(500, errorMessage);
            }
        }



        /// <summary>
        /// Removes a supplement from a gym (accessible to Admin and Employee roles).
        /// </summary>
        /// <param name="gymId">The ID of the gym.</param>
        /// <param name="supplementId">The ID of the supplement to remove.</param>
        /// <returns>No content if the supplement was successfully removed.</returns>
        [Authorize(Roles = "Admin, Employee")]
        [HttpDelete]
        [Route("{gymId}/Supplement/{supplementId}")]
        public async Task<IActionResult> RemoveSupplementFromGym(int gymId, int supplementId)
        {
            await _gym.RemoveSupplementFromGym(gymId, supplementId);
            return NoContent();
        }
    }
}
