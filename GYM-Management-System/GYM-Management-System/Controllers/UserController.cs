using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Management_System.Controllers
{
    /// <summary>
    /// API controller for user-related operations in the gym management system.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="user">The user service.</param>
        public UserController(IUser user)
        {
            userService = user;
        }

        /// <summary>
        /// Logs in a user with the provided credentials.
        /// </summary>
        /// <param name="loginDto">The login data.</param>
        /// <returns>The user's data or Unauthorized if login fails.</returns>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(LogInDTO loginDto)
        {
            var user = await userService.LogIn(loginDto.UserName, loginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }

        /// <summary>
        /// Registers a new admin user (accessible to users with the 'Admin' role).
        /// </summary>
        /// <param name="Data">The admin user registration data.</param>
        /// <returns>The registered admin user's data.</returns>
        //[Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<ActionResult<UserDTO>> RegisterAdmin(RegisterAdminDTO Data)
        {
            var user = await userService.RegisterAdmin(Data, this.ModelState, User);
            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        /// <summary>
        /// Registers a new employee user (accessible to users with the 'Admin' and 'Employee' roles).
        /// </summary>
        /// <param name="Data">The employee user registration data.</param>
        /// <returns>The registered employee user's data.</returns>
        //[Authorize(Roles = "Admin, Employee")]

        [HttpPost]
        public async Task<ActionResult<UserDTO>> RegisterEmployee(RegisterEmployeeDTO Data)
        {
            var user = await userService.RegisterEmployee(Data, this.ModelState);
            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        /// <summary>
        /// Registers a new client user.
        /// </summary>
        /// <param name="Data">The client user registration data.</param>
        /// <returns>The registered client user's data.</returns>

        [AllowAnonymous]
        [HttpPost]

        public async Task<ActionResult<UserDTO>> ClientRegister(RegisterClientDTO Data)
        {
            var user = await userService.RegisterUser(Data, this.ModelState, User);
            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }
    }
}
