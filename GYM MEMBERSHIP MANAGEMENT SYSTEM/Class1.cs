using System;
using System.Security.Cryptography;
using System.Text;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    public class HashCode
    {
        public string hash(string input)
        {
            // Convert the input string to a byte array and compute the hash
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
