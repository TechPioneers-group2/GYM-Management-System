using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Common;

namespace GYM_Management_System.Models.Services
{
    public class IdentityUserService : IUser
    {
        private UserManager<ApplicationUser> _userManager;
        
        private jwtTokenServices _tokenServices;

        public IdentityUserService(UserManager<ApplicationUser> manager, jwtTokenServices tokenServices)
        {
            _userManager = manager;
            _tokenServices = tokenServices;
        }
        
        public  async Task<UserDTO> LogIn(string UserName, string Password)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            bool vaildtionOfPassword = await _userManager.CheckPasswordAsync(user, Password);
            if (vaildtionOfPassword)
            {
                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenServices.GetToken(user, System.TimeSpan.FromMinutes(15))

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
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenServices.GetToken(user, System.TimeSpan.FromMinutes(15))
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

        public async Task<UserDTO> Authenticate(string userName, string password)
        {
           

            var user = await _userManager.FindByNameAsync(userName);
            bool validPassword = await _userManager.CheckPasswordAsync(user, password);
            if (validPassword)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenServices.GetToken(user, System.TimeSpan.FromMinutes(15))

                };
            }
            return null;
        }
    }
}
