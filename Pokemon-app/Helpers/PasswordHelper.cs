using System.Security.Cryptography;
using System.Text;

namespace Pokemon_app.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);  // Retourne le mot de passe haché sous forme de chaîne
            }
        }
    }
}
