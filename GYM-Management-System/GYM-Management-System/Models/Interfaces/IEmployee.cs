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
        Task<EmployeeDTO> GetEmployee(int id);

        // Get Employees by GymId
        Task<List<EmployeeDTO>> GetEmployeesByGymId(int gymId);
        // Update Employee Data
        Task<EmployeeDTO> Update(UpdateEmployeeDTO updateEmployeeDTO, int employeeId);

        // Delete Employee
        Task Delete(int employeeId);

    }
}
