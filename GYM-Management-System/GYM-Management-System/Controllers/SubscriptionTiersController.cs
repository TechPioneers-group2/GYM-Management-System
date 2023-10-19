using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Management_System.Controllers
{
    /// <summary>
    /// API controller for managing subscription tiers in the gym management system.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubscriptionTiersController : ControllerBase
    {
        private readonly ISubscriptionTier _SubscriptionTier;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionTiersController"/> class.
        /// </summary>
        /// <param name="context">The subscription tier data access context.</param>
        public SubscriptionTiersController(ISubscriptionTier context)
        {
            _SubscriptionTier = context;
        }

        /// <summary>
        /// Retrieves a list of subscription tiers (accessible to all users).
        /// </summary>
        /// <returns>A list of subscription tiers.</returns>
        //[AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSubscriptionTierDTO>>> GetSubscriptionTiersBackEnd()
        {
            return await _SubscriptionTier.GetAllSubscriptionTier();
        }

        /// <summary>
        /// Retrieves subscription tier details by its ID (accessible to all users).
        /// </summary>
        /// <param name="id">The ID of the subscription tier.</param>
        /// <returns>The subscription tier details.</returns>
        //[AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSubscriptionTierDTO>> GetSubscriptionTierBackEnd(int id)
        {
            return Ok(await _SubscriptionTier.GetSubscriptionTier(id));
        }

        /// <summary>
        /// Updates subscription tier details by its ID (accessible to Admin and Employee roles).
        /// </summary>
        /// <param name="id">The ID of the subscription tier to update.</param>
        /// <param name="subscriptionTier">The updated subscription tier data.</param>
        /// <returns>The updated subscription tier data.</returns>
       // [Authorize(Roles = "Admin, Employee")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionTierBackEnd(int id, UpdateSubscriptionTierDTO subscriptionTier)
        {
            var updatedSubTier = await _SubscriptionTier.UpdateSubscriptionTier(id, subscriptionTier);
            return Ok(updatedSubTier);
        }

        /// <summary>
        /// Creates a new subscription tier (accessible to Admin role).
        /// </summary>
        /// <param name="subscriptionTier">The subscription tier data to create.</param>
        /// <returns>The created subscription tier data.</returns>
      //  [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<PostSubscriptionTierDTO>> PostSubscriptionTierBackEnd(CreatSubscriptionTierDTO subscriptionTier)
        {
            var createdSubTier = await _SubscriptionTier.Create(subscriptionTier);

            return Ok(createdSubTier);
        }

        /// <summary>
        /// Deletes a subscription tier by its ID (accessible to Admin role).
        /// </summary>
        /// <param name="id">The ID of the subscription tier to delete.</param>
        /// <returns>No content if the subscription tier was successfully deleted.</returns>
       // [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionTierBackEnd(int id)
        {
            await _SubscriptionTier.DeleteSubscriptionTier(id);
            return NoContent();
        }
    }
}
