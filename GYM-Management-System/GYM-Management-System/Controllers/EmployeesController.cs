using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Management_System.Controllers
{
    /// <summary>
    /// API controller for managing employees in the gym management system.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employee;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="employee">The employee data access context.</param>
        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        /// <summary>
        /// Retrieves a list of employees (accessible to Admin role).
        /// </summary>
        /// <returns>A list of employees.</returns>
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await _employee.GetEmployees();

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        /// <summary>
        /// Retrieves an employee's details by their ID (accessible to Admin and Employee roles).
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The employee's details.</returns>
        //[Authorize(Roles = "Admin, Employee")]
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

        /// <summary>
        /// Updates an employee's details by their ID (accessible to Admin role).
        /// </summary>
        /// <param name="updateEmployeeDTO">The updated employee data.</param>
        /// <param name="id">The ID of the employee to update.</param>
        /// <returns>The updated employee data.</returns>
       // [Authorize(Roles = "Admin")]
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

        /// <summary>
        /// Creates a new employee (accessible to Admin role).
        /// </summary>
        /// <param name="createEmployeeDTO">The employee data to create.</param>
        /// <returns>The created employee data.</returns>
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee(CreatEmployeeDTO createEmployeeDTO)
        {
            var employee = await _employee.Create(createEmployeeDTO);

            if (employee == null)
            {
                return BadRequest();
            }

            return Ok(employee);
        }

        /// <summary>
        /// Deletes an employee by their ID (accessible to Admin role).
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>No content if the employee was successfully deleted.</returns>
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employee.Delete(id);

            return NoContent();
        }

        /// <summary>
        /// Retrieves a list of employees by a gym's ID (accessible to Admin role).
        /// </summary>
        /// <param name="gymId">The ID of the gym to retrieve employees for.</param>
        /// <returns>A list of employees.</returns>
        //[Authorize(Roles = "Admin")]
        //[Route("/api/Employees/Gym/{gymId}")]
        [HttpGet("{gymId}")]
        public async Task<ActionResult<IEnumerable<GetEmployeesByGymId>>> GetEmployeesByGymId(int gymId)
        {
            var employees = await _employee.GetEmployeesByGymId(gymId);

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }
    }
}
