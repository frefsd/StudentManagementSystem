using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace StudentManagementSystem.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            const int iterations = 100000;
            var subkey = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterations,
                numBytesRequested: 256 / 8);

            var hash = new StringBuilder();
            hash.Append(iterations).Append("s");
            hash.Append(Convert.ToBase64String(salt)).Append("$");
            hash.Append(Convert.ToBase64String(subkey));

            return hash.ToString();
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword) || !hashedPassword.Contains('$'))
                return false;

            var parts = hashedPassword.Split('$');
            if (parts.Length != 2) return false;

            var prefixParts = parts[0].Split('s');
            if (prefixParts.Length != 2) return false;

            if (!int.TryParse(prefixParts[0], out int iterations))
                return false;

            var salt = Convert.FromBase64String(prefixParts[1]);
            var expectedSubkey = Convert.FromBase64String(parts[1]);

            var actualSubkey = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterations,
                numBytesRequested: 256 / 8);

            return CryptographicOperations.FixedTimeEquals(
                new ReadOnlySpan<byte>(actualSubkey),
                new ReadOnlySpan<byte>(expectedSubkey));
        }
    }
}