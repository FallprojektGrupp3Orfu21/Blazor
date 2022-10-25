using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Economiq.Server.Service
{
    public class AuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly EconomiqContext _context;
        public AuthenticationService(IConfiguration config, EconomiqContext context)
        {
            _configuration = config;
            _context = context;
        }

        private User? Authenticate(Credentials credentials)
        {
            User? currentUser = _context.Users.FirstOrDefault(u => u.UserName.ToLower() == credentials.Username.ToLower() && u.Password == credentials.Password);
            return currentUser;
        }



        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt")["Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };
            var token = new JwtSecurityToken(
                _configuration.GetSection("Jwt")["Issuer"],
                _configuration.GetSection("Jwt")["Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
