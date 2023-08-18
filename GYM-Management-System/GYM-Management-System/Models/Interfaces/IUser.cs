﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO registerDTO, ModelStateDictionary modelState);
        public Task<UserDTO> LogIn(string UserName, string Password);
       // public Task<ActionResult<UserDTO>> RegisterAgent(RegisterUserDTO registerDTO, ModelStateDictionary modelState);
    }
}
