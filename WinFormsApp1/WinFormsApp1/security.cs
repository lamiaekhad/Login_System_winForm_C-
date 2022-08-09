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
            string salt = "6Q!98A#K8/L$";
            var bytes = new UTF8Encoding().GetBytes(motdepasse + salt);
            var hashBytes = SHA256.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
       

    }
}
