using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SADVO.Core.Application.Helpers
{
    public class PasswordEncryptation
    {

        public static string ComputeSha25Hash(string password) 
        {

            using (SHA256 sha256 = SHA256.Create()) 
            {

                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                //Hacemos la conversion  a string 

                StringBuilder sb = new StringBuilder();
                foreach (var item in bytes)
                {
                    sb.Append(item.ToString("X2"));
                }

                return sb.ToString();


            }
           
        
        }
    }
}
