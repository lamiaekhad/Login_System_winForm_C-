using System;
using System.Collections.Generic;
using System.Text;
//using System.Security.Cryptography;

namespace WinFormsApp1
{
    internal class security
    {
        public static string Hash(string motdepasse)
        {
            var bytes = new UTF8Encoding().GetBytes(motdepasse);
            var hashBytes = System.Security.Cryptography.SHA256.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
