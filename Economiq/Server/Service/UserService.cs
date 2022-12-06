using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Economiq.Server.Service
{
    public class UserService
    {
        private readonly EconomiqContext _context;
        private readonly int _minimumPasswordLength;
        private readonly PasswordService _pwService;

        public UserService(EconomiqContext context, ExpenseCategoryService categoryService, PasswordService pwService)
        {
            _context = context;
            _minimumPasswordLength = 8;
            _pwService = pwService;
        }

        public async Task RegisterUser(UserDTO newUser)
        {
            if (!IsPasswordOk(newUser.password))
            {
                throw new Exception("Password is too weak");
            }
            if (DoesUserExist(newUser.Username))
            {
                throw new Exception("Username already exists");
            }

            List<Email> Emails = new();
            Emails.Add(new() { Mail = newUser.email.ToLower() });

            string salt = _pwService.CreateSalt();
            string hashedPW = _pwService.HashPassword(newUser.password + salt);

            _context.Users.Add(new User
            {
                Fname = newUser.Fname,
                Lname = newUser.Lname,
                UserName = newUser.Username,
                Password = hashedPW,
                Emails = Emails,
                Salt = salt,
                CreationDate = DateTime.Now
            });
            await _context.SaveChangesAsync();
        }

        public bool DoesUserExist(string userName)
        {
            return (_context.Users.Any(user => user.UserName.ToLower() == userName.ToLower()));
        }

        private bool IsPasswordOk(string password)
        {
            return password.Length >= _minimumPasswordLength;
        }

        public User? GetCurrentUser(string jwt)
        {
            var actualToken = jwt.Split(" ")[1];
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken token = tokenHandler.ReadJwtToken(actualToken);
            var IsParsed = int.TryParse(token.Subject, out int idAsInt);
            if (IsParsed)
            {
                return _context.Users.FirstOrDefault(u => u.Id == idAsInt);
            }
            return null;
        }
    }
}