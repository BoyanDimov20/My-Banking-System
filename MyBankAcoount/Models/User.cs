using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace MyBankAcoount
{
    public class User
    {
        public string Username { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string HashPassoword { get; set; }

        public string FileName { get; set; }

        public static User Parse(string json)
        {
            User user = new User();
            JObject jObject = JObject.Parse(json);
            user.Username = (string)jObject["Username"];
            user.FullName = (string)jObject["FullName"];
            user.Email = (string)jObject["Email"];
            user.HashPassoword = (string)jObject["HashPassoword"];
            user.FileName = (string)jObject["FileName"];
            return user;
        }

        public static string Hash(string password)
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
