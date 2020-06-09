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
    }
}
