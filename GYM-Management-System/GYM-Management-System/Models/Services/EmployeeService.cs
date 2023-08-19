using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System.Models.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly GymDbContext _db;

        public EmployeeService(GymDbContext db)
        {
            _db = db;
        }

		public async Task<EmployeeDTO> Create(CreatEmployeeDTO creatEmployeeDTO)
		{
			var gym = await _db.Gyms.FindAsync(creatEmployeeDTO.GymID);
			if(gym==null)
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
				EmployeeID= newEmployee.EmployeeID,
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

        public async Task Delete(int employeeId)
        {
            Employee employee = await _db.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
                await _db.SaveChangesAsync();
            }

        }

        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            var employee = await _db.Employees
                .FirstOrDefaultAsync(em => em.EmployeeID == id);
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

            return employeeDTO;
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            List<Employee> employees = await _db.Employees
                .Include(em => em.Gym).ToListAsync();
            if (employees != null)
            {
                List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
                foreach (Employee employee in employees)
                {
                    EmployeeDTO employeeDTO = new EmployeeDTO()
                    {
                        EmployeeID = employee.EmployeeID,
                        GymID = employee.GymID,
                        Name = employee.Name,
                        JobDescription = employee.JobDescription,
                        WorkingDays = employee.WorkingDays,
                        WorkingHours = employee.WorkingHours,
                        Salary = employee.Salary,
                        IsAvailable = employee.IsAvailable
                    };
                    employeeDTOs.Add(employeeDTO);
                }
                return employeeDTOs;
            }
            return null;
        }

        public async Task<List<GetEmployeesByGymId>> GetEmployeesByGymId(int gymId)
        {
            List<Employee> employees = await _db.Employees
                .Where(em => em.GymID == gymId)
                .ToListAsync();
            if (employees != null)
            {
                List<GetEmployeesByGymId> employeesByIds = new List<GetEmployeesByGymId>();
                foreach (Employee employee in employees)
                {
                    GetEmployeesByGymId em = new GetEmployeesByGymId()
                    {
                        EmployeeID = employee.EmployeeID,
                        Name = employee.Name,
                        JobDescription = employee.JobDescription,
                        IsAvailable = employee.IsAvailable,
                        WorkingDays = employee.WorkingDays,
                        WorkingHours = employee.WorkingHours,
                        Salary = employee.Salary,
                    };
                    employeesByIds.Add(em);
                }
                return employeesByIds;
            }
            return null;
        }


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
