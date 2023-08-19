using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using GYM_Management_System.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GYM_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser userService;
        public UserController(IUser user)
        {
            userService = user;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LogInDTO loginDto)
        {
            var user = await userService.LogIn(loginDto.UserName, loginDto.Password);
            if (user == null)
            {
                return Unauthorized();

            }
            return Ok(user);
        }

       // [Authorize(Roles = "Admin")]
        [HttpPost("AdminRegister")]
        public async Task<ActionResult<UserDTO>> RegisterAdmin(RegisterAdminDTO Data)
        {
            var user = await userService.RegisterAdmin(Data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [Authorize(Roles = "Admin, Employee")]
        [HttpPost("EmployeeRegister")]
        public async Task<ActionResult<UserDTO>> RegisterEmployee(RegisterEmployeeDTO Data)
        {
            var user = await userService.RegisterEmployee(Data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [AllowAnonymous]
        [HttpPost("ClientRegister")]
        public async Task<ActionResult<UserDTO>> ClientRegister(RegisterClientDTO Data)
        {
            var user = await userService.RegisterUser(Data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }
    }
}
