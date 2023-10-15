using gym_management_system.Models.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;


namespace gym_management_system.Models.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> RegisterAdmin(RegisterAdminDTO registerAdminDTO, ModelStateDictionary modelState, ClaimsPrincipal claimsPrincipal);
        public Task<UserDTO> RegisterEmployee(RegisterEmployeeDTO registerEmployeeDTO, ModelStateDictionary modelState);
        public Task<UserDTO> RegisterUser(RegisterClientDTO registerClientDTO, ModelStateDictionary modelState, ClaimsPrincipal claimsPrincipal);
        public Task<UserDTO> LogIn(string UserName, string Password);

        //public Task<UserDTO> Authenticate(string UserName, string Password);

        // public Task<ActionResult<UserDTO>> RegisterAgent(RegisterUserDTO registerDTO, ModelStateDictionary modelState);
    }
}
