using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface IEmployee
    {
		// Create an Employee
		Task<EmployeeDTO> Create(CreatEmployeeDTO creatEmployeeDTO);

		// GET All Employees
		Task<List<EmployeeDTO>> GetEmployees();
		// GET Employee By ID
		Task<Employee> GetEmployee(int id);

		// Get Employees by GymId

		Task<List<GetEmployeesByGymId>> GetEmployeesByGymId(int gymId);
		// Update Employee Data
		Task<EmployeeDTO> Update(UpdateEmployeeDTO updateEmployeeDTO, int employeeId);

		// Delete Employee
		Task Delete(int employeeId);
		////Get All Employees in Gym
		//Task<List<EmployeeInGymDTO>> GetEmployeesinGym(int gymId);
		//// Get an Emplyee in Gym
		//Task<Employee> GetEmployeeinGym(int gymId,int employeeId);




	}
}
