using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM
{
    class HashCode
    {
        public string PassHash(string data)
        {
            using (SHA1  sha1 = SHA1.Create()) 
            {
                byte [] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));
                StringBuilder returnValue = new StringBuilder();

                for (int i = 0;  i < hashData.Length && i < 50; i++ ) 
                {
                    returnValue.Append(hashData[i]. ToString("x2"));
                }
                return returnValue.ToString();
            }
        }
    }  
}
