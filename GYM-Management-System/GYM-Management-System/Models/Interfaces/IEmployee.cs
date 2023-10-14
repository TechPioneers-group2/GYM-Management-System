using gym_management_system_front_end.Models.Models.DTOs;

namespace gym_management_system_front_end.Models.Models.Interfaces
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
        Task<List<GetEmployeesByGymId>> GetEmployeesByGymId(int gymId);
        // Update Employee Data
        Task<EmployeeDTO> Update(UpdateEmployeeDTO updateEmployeeDTO, int employeeId);

        // Delete Employee
        Task Delete(int employeeId);

    }
}
