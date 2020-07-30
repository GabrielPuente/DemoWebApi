using System;
using System.Security.Cryptography;
using System.Text;

namespace TurtlePizzaria.Core.Util
{
    public static class Password
    {
        public static string PasswordHash(string password)
        {
            string savedPasswordHash;
            byte[] salt;
            byte[] hashBytes = new byte[36];

            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static bool CheckPassword(string passwordSent, string passwordSave)
        {
            bool result = true;
            string savedPasswordHash = passwordSave;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(passwordSent, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    result = false;

            return result;
        }

        public static string GenerateForgotPassword()
        {
            bool digit = true;
            bool lowercase = true;
            bool uppercase = true;

            StringBuilder password = new StringBuilder();
            Random random = new Random();
            var length = new Random().Next(5, 10);

            while (password.Length < length)
            {
                char c = (char)random.Next(32, 126);

                if (char.IsLetterOrDigit(c))
                    password.Append(c);

                if (char.IsDigit(c))
                    digit = false;
                else if (char.IsLower(c))
                    lowercase = false;
                else if (char.IsUpper(c))
                    uppercase = false;
            }
            if (digit)
                password.Append((char)random.Next(48, 58));
            if (lowercase)
                password.Append((char)random.Next(97, 123));
            if (uppercase)
                password.Append((char)random.Next(65, 91));
            return password.ToString();
        }
    }
}
