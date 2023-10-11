using GYM_Management_System.Controllers;
using GYM_Management_System.Models;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using GYM_Management_System.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gym_System_test
{
    public class UserTest : Mock
    {

        [Fact]
        public async Task Register_User_As_Admin()
        {
            // Arrange
            var userMock = new Mock<IUser>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(MockBehavior.Strict, null, null, null, null, null, null, null, null);
            var jwtTokenServiceMock = new Mock<jwtTokenServices>(null, null);

            var roles = new List<Claim> { new Claim(ClaimTypes.Role, "Admin") };
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(roles));

            var controller = new UserController(userMock.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = userPrincipal
                }
            };

            var registerDto = new RegisterAdminDTO
            {
                UserName = "TestAdmin",
                Email = "test@example.com",
                PhoneNumber = "123456789",
                Password = "P@ssw0rd",
                Roles = new List<string> { "Admin" }
            };

            var expectedResult = new UserDTO
            {
                Id = "UserId",
                UserName = registerDto.UserName,
                Token = "MockedToken",
                Roles = new List<string> { "Admin" }
            };

            userMock.Setup(u => u.RegisterAdmin(It.IsAny<RegisterAdminDTO>(), It.IsAny<ModelStateDictionary>(), It.IsAny<ClaimsPrincipal>()))
                            .ReturnsAsync(expectedResult);

            // Act
            var result = await controller.RegisterAdmin(registerDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
            var userDto = Assert.IsType<UserDTO>(actionResult.Value);

            Assert.Equal(expectedResult.UserName, userDto.UserName);
            Assert.Equal(expectedResult.Roles, userDto.Roles);

        }

        [Fact]
        public async Task Register_User_As_Employee()
        {
            // Arrange
            var userMock = new Mock<IUser>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(MockBehavior.Strict, null, null, null, null, null, null, null, null);
            var jwtTokenServiceMock = new Mock<jwtTokenServices>(null, null);

            var roles = new List<Claim> { new Claim(ClaimTypes.Role, "Employee") };
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(roles));

            var controller = new UserController(userMock.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = userPrincipal
                }
            };

            var registerDto = new RegisterEmployeeDTO
            {
                UserName = "TestEmployee",
                Email = "test@example.com",
                PhoneNumber = "123456789",
                Password = "P@ssw0rd",
                Roles = new List<string> { "Employee" }
            };

            var expectedResult = new UserDTO
            {
                Id = "UserId",
                UserName = registerDto.UserName,
                Token = "MockedToken",
                Roles = new List<string> { "Employee" }
            };

            userMock.Setup(u => u.RegisterEmployee(It.IsAny<RegisterEmployeeDTO>(), It.IsAny<ModelStateDictionary>(), It.IsAny<ClaimsPrincipal>()))
                            .ReturnsAsync(expectedResult);

            // Act
            var result = await controller.RegisterEmployee(registerDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
            var userDto = Assert.IsType<UserDTO>(actionResult.Value);

            Assert.Equal(expectedResult.UserName, userDto.UserName);
            Assert.Equal(expectedResult.Roles, userDto.Roles);

        }

        [Fact]
        public async Task Register_User_As_Client()
        {
            // Arrange
            var userMock = new Mock<IUser>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(MockBehavior.Strict, null, null, null, null, null, null, null, null);
            var jwtTokenServiceMock = new Mock<jwtTokenServices>(null, null);

            var roles = new List<Claim> { new Claim(ClaimTypes.Role, "Client") };
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(roles));

            var controller = new UserController(userMock.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = userPrincipal
                }
            };

            var registerDto = new RegisterClientDTO
            {
                UserName = "TestClient",
                Email = "test@example.com",
                PhoneNumber = "123456789",
                Password = "P@ssw0rd",
                Roles = new List<string> { "Client" }
            };

            var expectedResult = new UserDTO
            {
                Id = "UserId",
                UserName = registerDto.UserName,
                Token = "MockedToken",
                Roles = new List<string> { "Client" }
            };

            userMock.Setup(u => u.RegisterUser(It.IsAny<RegisterClientDTO>(), It.IsAny<ModelStateDictionary>(), It.IsAny<ClaimsPrincipal>()))
                            .ReturnsAsync(expectedResult);

            // Act
            var result = await controller.ClientRegister(registerDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
            var userDto = Assert.IsType<UserDTO>(actionResult.Value);

            Assert.Equal(expectedResult.UserName, userDto.UserName);
            Assert.Equal(expectedResult.Roles, userDto.Roles);

        }

        [Fact]
        public async Task SignIn_User_Successfully()
        {
            // Arrange

            var expectedResult = new UserDTO
            {
                Id = "UserId",
                UserName = "TestUser",
                Token = "MockedToken",
                Roles = new List<string> { "Admin" }
            };

            var userMock = SetupUserMock(expectedResult);
            var controller = new UserController(userMock);

            var loginDto = new LogInDTO
            {
                UserName = "TestUser",
                Password = "P@ssw0rd"
            };

            // Act

            var result = await controller.Login(loginDto);

            // Assert

            var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
            var userDto = Assert.IsType<UserDTO>(actionResult.Value);

            Assert.Equal(expectedResult.UserName, userDto.UserName);
            Assert.Equal(expectedResult.Roles, userDto.Roles);
        }
    }
}