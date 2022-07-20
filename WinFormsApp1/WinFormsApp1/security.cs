using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Owin.Security.Infrastructure;

namespace WinFormsApp1
{
    internal class security
    {
       
        public static string HashSalt(string motdepasse)
        {
          
            var bytes = new UTF8Encoding().GetBytes(motdepasse + DateTime.Now);
            var hashBytes = SHA256.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
        public static string Hash(string motdepasse)
        {
            var bytes = new UTF8Encoding().GetBytes(motdepasse);
            var hashBytes = SHA256.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

    }
}
