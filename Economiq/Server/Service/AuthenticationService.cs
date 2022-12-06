using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Economiq.Server.Service
{
    public class AuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly EconomiqContext _context;
        private readonly PasswordService _pwService;
        
        public AuthenticationService(IConfiguration config, EconomiqContext context, PasswordService pwService)
        {
            _configuration = config;
            _context = context;
            _pwService = pwService;
        }

        public async Task<User?> Authenticate(Credentials credentials)
        {
            bool userFound = await _context.Users.AnyAsync(u => u.UserName.ToLower().Equals(credentials.Username.ToLower()));
            if(userFound)
            {
                User? userToLogin = await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(credentials.Username.ToLower()));
                if(_pwService.HashPassword($"{credentials.Password}{userToLogin.Salt}").Equals(userToLogin.Password))
                {
                    return userToLogin;
                }
            }
            return null;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt")["Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Fname)
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
