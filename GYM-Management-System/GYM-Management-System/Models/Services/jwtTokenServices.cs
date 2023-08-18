using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace GYM_Management_System.Models.Services
{
    public class jwtTokenServices

    {
        private SignInManager<ApplicationUser> _signInManager;
        private IConfiguration _configuration;

        public jwtTokenServices(IConfiguration config, SignInManager<ApplicationUser> manager)
        {
            _configuration = config;
            _signInManager = manager;

        }

        public static TokenValidationParameters GetValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = false,
                ValidateAudience = false

            };


        }

        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {

            var Secret = configuration["JWT:Secret"];
            if (Secret == null)
            {
                throw new InvalidOperationException("JWT:secret key is not exist");
            }



            var secretBytes = Encoding.UTF8.GetBytes(Secret);

            return new SymmetricSecurityKey(secretBytes);
        }
        public async Task<string> GetToken(ApplicationUser User, TimeSpan expiresIn)
        {
            var Principle = await _signInManager.CreateUserPrincipalAsync(User);

            if (Principle == null)
            {
                return null;
            }

            var signinkey = GetSecurityKey(_configuration);

            var token = new JwtSecurityToken
                (
                  expires: DateTime.UtcNow + expiresIn,
                  signingCredentials: new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256),
                  claims: Principle.Claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}


