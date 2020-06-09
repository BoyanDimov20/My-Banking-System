using MyBankAcoount.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MyBankAcoount.IO
{
    public class BankWriter
    {
        private const string BankAccountsFile = "bankAccounts.json";

        public static void Append(string fileName, double value)
        {
            using (var stream = new StreamWriter(fileName, append: true))
            {
                var json = new JavaScriptSerializer().Serialize(new Income(value));
                stream.WriteLine(json);
            }
        }

        public static void Clear(string fileName)
        {
            using (var stream = new StreamWriter(fileName))
            {
                stream.Write("0");
            }
        }

        public static void CreateAccount(string username, string fullName, string email, string password, string fileName)
        {
            User user = new User
            {
                Username = username,
                FullName = fullName,
                Email = email,
                HashPassoword = User.Hash(password),
                FileName = fileName,
            };

            using (var stream = new StreamWriter(BankAccountsFile, append: true))
            {
                var json = new JavaScriptSerializer().Serialize(user);
                stream.WriteLine(json);
            }
        }

    }
}
