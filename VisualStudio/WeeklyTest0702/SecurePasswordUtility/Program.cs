using System;
using System.Security.Cryptography;

namespace SecurePasswordUtility
{
    public static class PasswordUtil
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100000;

        public static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

            using var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256);

            byte[] hash = pbkdf2.GetBytes(KeySize);

            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            int iterations = int.Parse(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] expectedHash = Convert.FromBase64String(parts[2]);

            using var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256);

            byte[] actualHash = pbkdf2.GetBytes(expectedHash.Length);

            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            string stored = PasswordUtil.HashPassword(password);

            Console.WriteLine("\nStored Hash:");
            Console.WriteLine(stored);

            Console.Write("\nRe-enter password to verify: ");
            string check = Console.ReadLine()!;

            bool ok = PasswordUtil.VerifyPassword(check, stored);

            Console.WriteLine(ok ? "\nPassword VALID" : "\nPassword INVALID");
        }
    }
}
