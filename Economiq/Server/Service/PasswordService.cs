using System.Security.Cryptography;
using System.Text;

namespace Economiq.Server.Service
{
    public class PasswordService
    {
        public string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            byte[] passwordBytes = Encoding.Default.GetBytes(password);
            byte[] hashedPassword = hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedPassword);
        }
        public string CreateSalt()
        {
            RNGCryptoServiceProvider random = new();
            byte[] buff = new byte[16];
            random.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
    }
}
