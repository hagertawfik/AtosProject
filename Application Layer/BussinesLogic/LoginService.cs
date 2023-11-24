using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Data_Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application_Layer.BussinesLogic
{
    public class LoginService : IloginService
    {
        private readonly UserManager<Student> _userManager;
      
        private readonly IConfiguration _configuration;
        public LoginService(UserManager<Student> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;

        }
        public async Task<AuthResult> Login(UserLoginRequestDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return   new AuthResult() { Token = null, message = "Invalid Email", Result = false } ;
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                return   new AuthResult() { Token = null, message = "Invalid password", Result = false } ;
            

            var userRole = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.Email),
               new Claim(ClaimTypes.NameIdentifier, user.Id),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userRole.SingleOrDefault() ?? "DefaultRole") 

            };

            string token = GenerateToken(authClaims);
            return new AuthResult() { Token = token, message = "Done", Result = true } ;
        }


        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwtconfig:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
    }

