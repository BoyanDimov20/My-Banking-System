using MyBankAcoount.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAcoount.IO
{
    public class BankReader
    {
        private const string BankAccountsFile = "bankAccounts.json";

        public static bool Exist(string fileName)
        {
            return File.Exists(fileName);
        }

        public static double ReadBalance(string fileName)
        {
            var incomes = ReadIncomes(fileName);

            double amount = incomes.Sum(x => x.Value);
            return amount;
        }

        public static Income[] ReadIncomes(string fileName)
        {
            return File.ReadAllLines(fileName).Select(Income.Parse).ToArray();
        }

        private static User[] ReadAllUsers()
        {
            return File.ReadAllLines(BankAccountsFile).Select(User.Parse).ToArray();
        }

        public static string FindUserFileName(string username)
        {
            return ReadAllUsers().First(x => x.Username == username).FileName;
        }

        public static bool IsUserPasswordCorrect(string username, string password)
        {
            return ReadAllUsers().Any(x => x.Username == username && User.Hash(password) == x.HashPassoword);
        }

        public static bool DoesUsernameExist(string username)
        {
            return ReadAllUsers().Any(x => x.Username == username);
        }
    }
}
