﻿using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Management_System.Controllers
{
    /// <summary>
    /// API controller for managing gym equipment in the gym management system.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GymEquipmentsController : ControllerBase
    {
        private readonly IGymEquipment _equipment;

        private readonly IAzureBlobStorageService _azureBlobStorageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GymEquipmentsController"/> class.
        /// </summary>
        /// <param name="context">The gym equipment data access context.</param>
        public GymEquipmentsController(IGymEquipment context, IAzureBlobStorageService azureBlobStorageService)
        {
            _equipment = context;
            _azureBlobStorageService = azureBlobStorageService;
        }

        /// <summary>
        /// Retrieves a list of gym equipment.
        /// </summary>
        /// <returns>A list of gym equipment.</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDTO>>> GetBackEnd()
        {
            var equipmentDTOs = await _equipment.GetGymEquipments();
            return Ok(equipmentDTOs);
        }

        /// <summary>
        /// Retrieves gym equipment details by its ID.
        /// </summary>
        /// <param name="id">The ID of the gym equipment.</param>
        /// <returns>The gym equipment details.</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentDTO>> GetGymEquipmentBackEnd(int id)
        {
            var equipment = await _equipment.GetEquipmentById(id);
            return Ok(equipment);
        }

        /// <summary>
        /// Updates gym equipment details by its ID (accessible to Admin and Employee roles).
        /// </summary>
        /// <param name="id">The ID of the gym equipment to update.</param>
        /// <param name="gymEquipment">The updated gym equipment data.</param>
        /// <returns>The updated gym equipment data.</returns>
       // [Authorize(Roles = "Admin, Employee")]
        [HttpPut("{id}")]
        public async Task<ActionResult<EquipmentDTO>> PutGymEquipmentBackEnd(int id, EquipmentDTOPutservice gymEquipment)
        {
            var updatedEquipment = await _equipment.UpdateGymEquipment(id, gymEquipment);

            if (updatedEquipment == null)
            {
                return NotFound();
            }

            return Ok(updatedEquipment);
        }

        /// <summary>
        /// Creates new gym equipment (accessible to Admin and Employee roles).
        /// </summary>
        /// <param name="gymEquipment">The gym equipment data to create.</param>
        /// <returns>The created gym equipment data.</returns>
        //[Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        public async Task<ActionResult<EquipmentDTO>> PostGymEquipmentBackEnd(CreatEquipmentDTO gymEquipment)
        {
            var createdEquipment = await _equipment.Create(gymEquipment);

            return Ok(createdEquipment);
        }

        /// <summary>
        /// Deletes gym equipment by its ID (accessible to Admin role).
        /// </summary>
        /// <param name="id">The ID of the gym equipment to delete.</param>
        /// <returns>No content if the gym equipment was successfully deleted.</returns>
       // [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymEquipmentBackEnd(int id)
        {
            await _equipment.DeleteGymEquipment(id);

            return NoContent();
        }
    }
}
