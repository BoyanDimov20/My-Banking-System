using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MyBankAcoount
{
    public class User
    {
        public string Username { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string HashPassoword { get; set; }

        public static string Login(string username, string password)
        {
            throw new NotImplementedException();
            // TO DO
        }

        private static string Hash(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
