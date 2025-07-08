using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Helpers
{
    public static class CommonHelper
    {
        /// <summary>
        /// Hash a plain password using SHA256.
        /// </summary>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// Generate a unique customer number like CUST202507061005.
        /// </summary>
        public static string GenerateCustomerNumber()
        {
            string dayCode = DateTime.Now.ToString("ddHH"); 
            return $"CUST{dayCode}";
        }

        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return HashPassword(inputPassword) == hashedPassword;
        }
    }
}
