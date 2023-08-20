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
using Microsoft.AspNetCore.Authorization;

namespace GYM_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        // GET: api/Employees
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var emloyees = await _employee.GetEmployees();

            if (emloyees == null)
            {
                return NotFound();
            }
            return Ok(emloyees);
        }

        // GET: api/Employees/5
        [Authorize(Roles = "Admin, Employee")]
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _employee.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDTO>> PutEmployee(UpdateEmployeeDTO updateEmployeeDTO, int id)
        {
            var updatedEmployee = await _employee.Update(updateEmployeeDTO, id);
            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee(CreatEmployeeDTO creatEmployeeDTO)
        {
            var employee = await _employee.Create(creatEmployeeDTO);
            if (employee == null)
            {
                return BadRequest();
            }
            return Ok(employee);
        }

        // DELETE: api/Employees/5

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employee.Delete(id);

            return NoContent();


        }


        [Authorize(Roles = "Admin")]
        [Route("/api/Employees/Gym/{gymId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmployeesByGymId>>> GetEmployeesByGymId(int gymId)
        {
            var emloyees = await _employee.GetEmployeesByGymId(gymId);

            if (emloyees == null)
            {
                return NotFound();
            }
            return Ok(emloyees);
        }

    }
}
