using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GYM_Management_System.Models.Services
{
    public class UserService : IUser
    {
        private UserManager<ApplicationUser> userManager;
        public UserService(UserManager<ApplicationUser> manager)
        {
            userManager = manager;

        }
        public  async Task<UserDTO> LogIn(string UserName, string Password)
        {
            var user = await userManager.FindByNameAsync(UserName);
            bool vaildtionOfPassword = await userManager.CheckPasswordAsync(user, Password);
            if (vaildtionOfPassword)
            {
                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                };
            }
            return null;
        }

        public async Task<UserDTO> Register(RegisterUserDTO registerDTO, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerDTO.UserName,
                PhoneNumber = registerDTO.Phone,
                Email = registerDTO.Email,

            };
            var result = await userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                };

            }
            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(registerDTO.Password) :
                     error.Code.Contains("Email") ? nameof(registerDTO.Email) :
                      error.Code.Contains("UserName") ? nameof(registerDTO.UserName) : "";
                modelState.AddModelError(errorKey, error.Description);

            }
            return null;
        }
    }
}
