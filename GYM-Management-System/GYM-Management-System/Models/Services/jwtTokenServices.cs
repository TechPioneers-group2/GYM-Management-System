using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GYM_Management_System.Models.Services

{
    /// <summary>
    /// Service for generating JWT tokens for user authentication.
    /// </summary>
    public class jwtTokenServices
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="jwtTokenServices"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="manager">The SignInManager for user sign-in.</param>
        public jwtTokenServices(IConfiguration config, SignInManager<ApplicationUser> manager, UserManager<ApplicationUser> userManager)
        {
            _configuration = config;
            _signInManager = manager;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets the token validation parameters.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The token validation parameters.</returns>
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

        /// <summary>
        /// Gets the security key for signing tokens.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The security key.</returns>
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

        /// <summary>
        /// Generates a JWT token for a user with the specified expiration time.
        /// </summary>
        /// <param name="User">The user for whom the token is generated.</param>
        /// <param name="expiresIn">The token expiration time.</param>
        /// <returns>The generated JWT token.</returns>
        public async Task<string> GetToken(ApplicationUser User, TimeSpan expiresIn)
        {
            var Principle = await _signInManager.CreateUserPrincipalAsync(User);

            if (Principle == null)
            {
                return null;
            }

            var signinkey = GetSecurityKey(_configuration);

            var claims = new List<Claim>(Principle.Claims);

            // Add role claims
            var roles = await _userManager.GetRolesAsync(User);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken
            (
                expires: DateTime.UtcNow + expiresIn,
                signingCredentials: new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256),
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
