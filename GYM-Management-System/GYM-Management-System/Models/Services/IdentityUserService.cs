﻿using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GYM_Management_System.Models.Services

{
    /// <summary>
    /// Service for managing user-related operations using Identity.
    /// </summary>
    public class IdentityUserService : IUser
    {
        private readonly GymDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private jwtTokenServices _tokenServices;
        private ISubscriptionTier _subscriptionTier;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityUserService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="manager">The UserManager for managing users.</param>
        /// <param name="tokenServices">The JWT token service.</param>
        /// <param name="subscriptionTier">The subscription tier service.</param>
        public IdentityUserService(GymDbContext context, UserManager<ApplicationUser> manager, jwtTokenServices tokenServices, ISubscriptionTier subscriptionTier, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = manager;
            _tokenServices = tokenServices;
            _subscriptionTier = subscriptionTier;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Logs a user in.
        /// </summary>
        /// <param name="UserName">The username of the user.</param>
        /// <param name="Password">The password of the user.</param>
        /// <returns>The logged-in user data.</returns>
        public async Task<UserDTO> LogIn(string UserName, string Password)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            bool vaildtionOfPassword = await _userManager.CheckPasswordAsync(user, Password);
            if (vaildtionOfPassword)
            {
                var role = (List<string>)await _userManager.GetRolesAsync(user);
                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenServices.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = role
                };
            }
            return null;
        }

        /// <summary>
        /// Registers an admin user.
        /// </summary>
        /// <param name="registerAdminDTO">The admin user data to register.</param>
        /// <param name="modelState">The ModelStateDictionary to store validation errors.</param>
        /// <param name="User">The ClaimsPrincipal user.</param>
        /// <returns>The registered admin user data.</returns>
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

                var Roles = new List<string>
            {
                "Admin"
            };

                await _userManager.AddToRolesAsync(user, Roles);
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenServices.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = (List<string>)await _userManager.GetRolesAsync(user)
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

        /// <summary>
        /// Registers an employee user.
        /// </summary>
        /// <param name="registerEmployeeDTO">The employee user data to register.</param>
        /// <param name="modelState">The ModelStateDictionary to store validation errors.</param>
        /// <param name="claimsPrincipal">The ClaimsPrincipal user.</param>
        /// <returns>The registered employee user data.</returns>
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

                List<string> Roles = new List<string>
                {
                    "Employee"
                };

                await _userManager.AddToRolesAsync(user, Roles);
                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenServices.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = (List<string>)await _userManager.GetRolesAsync(user),
                };
            }
            return null;
        }

        /// <summary>
        /// Registers a client user.
        /// </summary>
        /// <param name="registerClientDTO">The client user data to register.</param>
        /// <param name="modelState">The ModelStateDictionary to store validation errors.</param>
        /// <param name="claimsPrincipal">The ClaimsPrincipal user.</param>
        /// <returns>The registered client user data.</returns>
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

                var Roles = new List<string>
            {
                "Client"
            };

                await _userManager.AddToRolesAsync(user, Roles);
                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenServices.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = (List<string>)await _userManager.GetRolesAsync(user),
                };
            }
            return null;
        }
    }
}
