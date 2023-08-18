using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Common;

namespace GYM_Management_System.Models.Services
{
    public class IdentityUserService : IUser
    {
        private readonly GymDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        private jwtTokenServices _tokenServices;

        private ISubscriptionTier _subscriptionTier;


        public IdentityUserService(GymDbContext context, UserManager<ApplicationUser> manager, jwtTokenServices tokenServices, ISubscriptionTier subscriptionTier)
        {
            _context = context;
            _userManager = manager;
            _tokenServices = tokenServices;
            _subscriptionTier = subscriptionTier;
        }

        public async Task<UserDTO> LogIn(string UserName, string Password)
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

        public async Task<UserDTO> RegisterAdmin(RegisterAdminDTO registerAdminDTO, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerAdminDTO.UserName,
                Email = registerAdminDTO.Email,
                PhoneNumber = registerAdminDTO.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, registerAdminDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, registerAdminDTO.Roles);
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenServices.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }
            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(registerAdminDTO.Password) :
                     error.Code.Contains("Email") ? nameof(registerAdminDTO.Email) :
                      error.Code.Contains("UserName") ? nameof(registerAdminDTO.UserName) : "";
                modelState.AddModelError(errorKey, error.Description);

            }
            return null;
        }

        public async Task<UserDTO> RegisterEmployee(RegisterEmployeeDTO registerEmployeeDTO, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerEmployeeDTO.UserName,
                PhoneNumber = registerEmployeeDTO.PhoneNumber,
                Email = registerEmployeeDTO.Email,
            };

            var result = await _userManager.CreateAsync(user, registerEmployeeDTO.Password);

            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(registerEmployeeDTO.Password) :
                     error.Code.Contains("Email") ? nameof(registerEmployeeDTO.Email) :
                      error.Code.Contains("UserName") ? nameof(registerEmployeeDTO.UserName) : "";
                modelState.AddModelError(errorKey, error.Description);
            }

            if (result.Succeeded)
            {
                {
                    var newEmployee = new Employee()
                    {
                        UserId = user.Id,
                        GymID = registerEmployeeDTO.GymID,
                        Name = registerEmployeeDTO.Name,
                        JobDescription = registerEmployeeDTO.JobDescription,
                        IsAvailable = registerEmployeeDTO.IsAvailable,
                        WorkingDays = registerEmployeeDTO.WorkingDays,
                        WorkingHours = registerEmployeeDTO.WorkingHours,
                        Salary = registerEmployeeDTO.Salary
                    };

                    _context.Employees.Add(newEmployee);
                    await _context.SaveChangesAsync();

                }
                await _userManager.AddToRolesAsync(user, registerEmployeeDTO.Roles);
                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenServices.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = await _userManager.GetRolesAsync(user),
                };
            }
            return null;
        }

        public async Task<UserDTO> RegisterUser(RegisterClientDTO registerClientDTO, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerClientDTO.UserName,
                PhoneNumber = registerClientDTO.PhoneNumber,
                Email = registerClientDTO.Email,
            };

            var result = await _userManager.CreateAsync(user, registerClientDTO.Password);

            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(registerClientDTO.Password) :
                     error.Code.Contains("Email") ? nameof(registerClientDTO.Email) :
                      error.Code.Contains("UserName") ? nameof(registerClientDTO.UserName) : "";
                modelState.AddModelError(errorKey, error.Description);
            }

            if (result.Succeeded)
            {
                {
                    var subscriptionTier = await _subscriptionTier.GetSubscriptionTier(registerClientDTO.SubscriptionTierID);
                    var currentDate = DateTime.UtcNow;
                    var subscriptionExpiry = currentDate.AddMonths(subscriptionTier.Length);

                    var newClient = new Client()
                    {
                        UserId = user.Id,
                        GymID = registerClientDTO.GymID,
                        Name = registerClientDTO.Name,
                        SubscriptionDate = currentDate,
                        SubscriptionExpiry = subscriptionExpiry,
                        SubscriptionTierID = registerClientDTO.SubscriptionTierID,
                        InGym = registerClientDTO.InGym
                    };

                    _context.Clients.Add(newClient);
                    await _context.SaveChangesAsync();

                }
                await _userManager.AddToRolesAsync(user, registerClientDTO.Roles);
                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenServices.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = await _userManager.GetRolesAsync(user),
                };
            }
            return null;
        }
    }
}
