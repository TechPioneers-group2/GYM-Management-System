﻿using System;
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
    public class GymEquipmentsController : ControllerBase
    {
        private readonly IGymEquipment _equipment;
        public GymEquipmentsController(IGymEquipment context)
        {
            _equipment = context;
        }

        // GET: api/GymEquipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDTO>>> GetGymEquipments()
        {
            var equipmentDTOs = await _equipment.GetGymEquipments();
            return Ok(equipmentDTOs);
        }

        // GET: api/GymEquipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentDTO>> GetGymEquipment(int id)
        {
            var equipment = await _equipment.GetEquipmentById(id);
            return Ok(equipment);
        }

        // PUT: api/GymEquipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<EquipmentDTO>> PutGymEquipment(int id, EquipmentDTOPutservice gymEquipment)
        {
            var updatedEq = await _equipment.UpdateGymEquipment(id, gymEquipment);
            if (updatedEq == null)
            {
                return NotFound();
                //return BadRequest("the id not matches");
            }

            return updatedEq;
        }

        // POST: api/GymEquipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentDTO>> PostGymEquipment(CreatEquipmentDTO gymEquipment)
        {
            var gymEq = await _equipment.Create(gymEquipment);

            return gymEq;

        }

        // DELETE: api/GymEquipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymEquipment(int id)
        {

            await _equipment.DeleteGymEquipment(id);

            return NoContent();
        }


    }
}
