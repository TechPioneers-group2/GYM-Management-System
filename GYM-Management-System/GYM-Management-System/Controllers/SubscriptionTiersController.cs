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
    public class SubscriptionTiersController : ControllerBase
    {
        private readonly ISubscriptionTier _SubscriptionTier;

        public SubscriptionTiersController(ISubscriptionTier context)
        {
            _SubscriptionTier = context;
        }

        // GET: api/SubscriptionTiers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionTierDTO>>> GetSubscriptionTiers()
        {
          return await _SubscriptionTier.GetAllSubscriptionTier();
        }

        // GET: api/SubscriptionTiers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionTierDTO>> GetSubscriptionTier(int id)
        {
          return await _SubscriptionTier.GetSubscriptionTier(id);
        }

        // PUT: api/SubscriptionTiers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionTier(int id, SubscriptionTierDTO subscriptionTier)
        {
            var updatedsubtier = await _SubscriptionTier.UpdateSubscriptionTier(id, subscriptionTier);
            return Ok(updatedsubtier);
        }

        // POST: api/SubscriptionTiers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubscriptionTier>> PostSubscriptionTier(SubscriptionTierDTO subscriptionTier)
        {
            var createdsubtier = await _SubscriptionTier.Create(subscriptionTier);
            return CreatedAtAction("GetSubscriptionTier",
                new { id = subscriptionTier.SubscriptionTierID }, subscriptionTier);

         }

        // DELETE: api/SubscriptionTiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionTier(int id)
        {
            await _SubscriptionTier.DeleteSubscriptionTier(id);
            return NoContent();
        }

        
    }
}
