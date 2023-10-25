using GYM_Management_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace GYM_Management_System.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> RegisterAdmin(RegisterAdminDTO registerAdminDTO, ModelStateDictionary modelState);
        public Task<UserDTO> RegisterEmployee(RegisterEmployeeDTO registerEmployeeDTO, ModelStateDictionary modelState);
        public Task<UserDTO> RegisterUser(RegisterClientDTO registerClientDTO, ModelStateDictionary modelState);
        public Task<UserDTO> LogIn(string UserName, string Password);
    }
}
