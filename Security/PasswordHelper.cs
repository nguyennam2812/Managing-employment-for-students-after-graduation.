using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLySinhVien.Security
{
    public static class PasswordHelper
    {
        // Format: {salt}.{hash}
        private const int SaltSize = 16; // 128 bit
        private const int KeySize = 32;  // 256 bit
        private const int Iterations = 10000;
        
        public static string HashPassword(string password)
        {
            // Use PBKDF2 with HMACSHA256 (requires .NET 4.6.2+)
            using (var algorithm = new Rfc2898DeriveBytes(password, SaltSize, Iterations, HashAlgorithmName.SHA256))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);
                return $"{salt}.{key}";
            }
        }

        public static bool VerifyPassword(string hash, string password)
        {
            if (string.IsNullOrEmpty(hash) || !hash.Contains("."))
                return false;

            var parts = hash.Split('.');
            if (parts.Length != 2)
                return false;

            var salt = Convert.FromBase64String(parts[0]);
            var key = parts[1];

            using (var algorithm = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                var keyToCheck = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                return keyToCheck == key;
            }
        }
        
        // Helper to identify if a string is likely our hash
        public static bool IsHashed(string storedPassword)
        {
             // Simple check: Length > 20 and contains '.'
             // Our hash: 24 chars (salt) + 1 char (.) + 44 chars (key) = ~69 chars
             return !string.IsNullOrEmpty(storedPassword) && storedPassword.Contains(".") && storedPassword.Length > 20;
        }
    }
}
