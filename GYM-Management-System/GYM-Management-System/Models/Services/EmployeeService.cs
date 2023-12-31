﻿using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System.Models.Services
{
    /// <summary>
    /// Service for managing employee-related operations in the gym management system.
    /// </summary>
    public class EmployeeService : IEmployee
    {
        private readonly GymDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="db">The database context.</param>
        public EmployeeService(GymDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Creates a new employee in the gym.
        /// </summary>
        /// <param name="creatEmployeeDTO">The employee data to create.</param>
        /// <returns>The created employee data.</returns>
        public async Task<EmployeeDTO> Create(CreatEmployeeDTO creatEmployeeDTO)
        {
            var gym = await _db.Gyms.FindAsync(creatEmployeeDTO.GymID);
            if (gym == null)
            {
                return null;
            }
            var newEmployee = new Employee()
            {
                GymID = creatEmployeeDTO.GymID,
                Name = creatEmployeeDTO.Name,
                JobDescription = creatEmployeeDTO.JobDescription,
                IsAvailable = creatEmployeeDTO.IsAvailable,
                WorkingDays = creatEmployeeDTO.WorkingDays,
                WorkingHours = creatEmployeeDTO.WorkingHours,
                Salary = creatEmployeeDTO.Salary,
            };
            await _db.AddAsync(newEmployee);
            await _db.SaveChangesAsync();
            EmployeeDTO employeeDTO = new EmployeeDTO()
            {
                EmployeeID = newEmployee.EmployeeID,
                GymID = creatEmployeeDTO.GymID,
                Name = creatEmployeeDTO.Name,
                JobDescription = creatEmployeeDTO.JobDescription,
                IsAvailable = creatEmployeeDTO.IsAvailable,
                WorkingDays = creatEmployeeDTO.WorkingDays,
                WorkingHours = creatEmployeeDTO.WorkingHours,
                Salary = creatEmployeeDTO.Salary,
            };
            return employeeDTO;
        }

        /// <summary>
        /// Deletes an employee from the gym.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to delete.</param>
        /// <returns>An asynchronous task.</returns>
        public async Task Delete(int employeeId)
        {
            Employee employee = await _db.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retrieves an employee's data by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The employee's data.</returns>
        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            var employee = await _db.Employees
               .Select(emp=> new EmployeeDTO
               {
				   EmployeeID = emp.EmployeeID,
				   GymID = emp.GymID,
				   Name = emp.Name,
				   JobDescription = emp.JobDescription,
				   IsAvailable = emp.IsAvailable,
				   WorkingDays = emp.WorkingDays,
				   WorkingHours = emp.WorkingHours,
				   Salary = emp.Salary,
                   gymBaseDto= new GymBaseDto() { 
                   GymID=emp.GymID,
                   Name=emp.Name
                   }
			   })
                .FirstOrDefaultAsync(em => em.EmployeeID == id);
            if (employee == null)
            {
                return null;
            }
            var employeeDTO = new EmployeeDTO()
            {
                EmployeeID = employee.EmployeeID,
                GymID = employee.GymID,
                Name = employee.Name,
                JobDescription = employee.JobDescription,
                IsAvailable = employee.IsAvailable,
                WorkingDays = employee.WorkingDays,
                WorkingHours = employee.WorkingHours,
                Salary = employee.Salary,
            };
            return employee;
        }

        /// <summary>
        /// Retrieves a list of all employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var employees = await _db.Employees
                .Select(emp => new EmployeeDTO
                {
                    EmployeeID = emp.EmployeeID,
                    GymID = emp.GymID,
                    Name = emp.Name,
                    JobDescription = emp.JobDescription,
                    IsAvailable = emp.IsAvailable,
                    WorkingDays = emp.WorkingDays,
                    WorkingHours = emp.WorkingHours,
                    Salary = emp.Salary,
                    gymBaseDto = new GymBaseDto()
                    {
                        GymID = emp.Gym.GymID,
                        Name = emp.Gym.Name
                    }
                })
                .ToListAsync();
            if (employees != null)
            {
                //List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
                //foreach (Employee employee in employees)
               // {
                 //   EmployeeDTO employeeDTO = new EmployeeDTO()
                 //   {
                      //  EmployeeID = employee.EmployeeID,
                      //  GymID = employee.GymID,
                      //  Name = employee.Name,
                      ////  JobDescription = employee.JobDescription,
                      ///  WorkingDays = employee.WorkingDays,
                      //  WorkingHours = employee.WorkingHours,
                     //   Salary = employee.Salary,
                     //   IsAvailable = employee.IsAvailable
                    ///};
                   // employeeDTOs.Add(employeeDTO);
              //  }
                return employees;
            }
            return null;
        }

        /// <summary>
        /// Retrieves a list of employees by gym ID.
        /// </summary>
        /// <param name="gymId">The ID of the gym.</param>
        /// <returns>A list of employees in the specified gym.</returns>
        public async Task<List<EmployeeDTO>> GetEmployeesByGymId(int gymId)
        {
            var employees = await _db.Employees
				 .Select(emp => new EmployeeDTO
				{
					EmployeeID = emp.EmployeeID,
					GymID = emp.GymID,
					Name = emp.Name,
					JobDescription = emp.JobDescription,
					IsAvailable = emp.IsAvailable,
					WorkingDays = emp.WorkingDays,
					WorkingHours = emp.WorkingHours,
					Salary = emp.Salary,
					gymBaseDto = new GymBaseDto()
					{
						GymID = emp.Gym.GymID,
						Name = emp.Gym.Name
					}
				})
				.Where(em => em.GymID == gymId)
                .ToListAsync();
            if (employees != null)
            {
                //List<GetEmployeesByGymId> employeesByIds = new List<GetEmployeesByGymId>();
                //foreach (Employee employee in employees)
               // {
                   // GetEmployeesByGymId em = new GetEmployeesByGymId()
                   // {
                        //EmployeeID = employee.EmployeeID,
                       // Name = employee.Name,
                       // JobDescription = employee.JobDescription,
                       // IsAvailable = employee.IsAvailable,
                       // WorkingDays = employee.WorkingDays,
                      //  WorkingHours = employee.WorkingHours,
                      //  Salary = employee.Salary,
                  //  };
                  //  employeesByIds.Add(em);
               // }
                return employees;
            }
            return null;
        }

        /// <summary>
        /// Updates an employee's data.
        /// </summary>
        /// <param name="updateEmployeeDTO">The updated employee data.</param>
        /// <param name="employeeId">The ID of the employee to update.</param>
        /// <returns>The updated employee's data.</returns>
        public async Task<EmployeeDTO> Update(UpdateEmployeeDTO updateEmployeeDTO, int employeeId)
        {
            Employee employee = await _db.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                employee.GymID = updateEmployeeDTO.GymID;
                employee.Name = updateEmployeeDTO.Name;
                employee.JobDescription = updateEmployeeDTO.JobDescription;
                employee.WorkingDays = updateEmployeeDTO.WorkingDays;
                employee.WorkingHours = updateEmployeeDTO.WorkingHours;
                employee.Salary = updateEmployeeDTO.Salary;
                employee.IsAvailable = updateEmployeeDTO.IsAvailable;
                _db.Entry(employee).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                EmployeeDTO employeeDTO = new EmployeeDTO()
                {
                    EmployeeID = employeeId,
                    GymID = updateEmployeeDTO.GymID,
                    Name = updateEmployeeDTO.Name,
                    JobDescription = updateEmployeeDTO.JobDescription,
                    IsAvailable = updateEmployeeDTO.IsAvailable,
                    WorkingDays = updateEmployeeDTO.WorkingDays,
                    WorkingHours = updateEmployeeDTO.WorkingHours,
                    Salary = updateEmployeeDTO.Salary,
                };

                return employeeDTO;
            }
            return null;
        }
    }
}
