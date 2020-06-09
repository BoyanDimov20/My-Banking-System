using MyBankAcoount.IO;
using MyBankAcoount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAcoount.Core
{
    public class Engine
    {
        private string FileName = "money.json";
        private Account account;
        
        private void ManageAccounts()
        {
            bool isLoginSuccessful = false;
            while (!isLoginSuccessful)
            {
                Console.WriteLine("Commands: Login, Register");
                var command = Console.ReadLine();

                if (command == "Login")
                {
                    isLoginSuccessful = Login();
                }
                else if (command == "Register")
                {
                    isLoginSuccessful = Register();
                }
            }
        }
        
        public void Run()
        {
            ManageAccounts();
            if (BankReader.Exist(FileName))
            {
                double initialBalance = BankReader.ReadBalance(FileName);
                this.account = new Account(initialBalance);
            }
            else
            {
                Console.Write("Starting deposit: ");
                var startingDeposit = double.Parse(Console.ReadLine());
                BankWriter.Append(FileName, startingDeposit);
                this.account = new Account(startingDeposit);
            }

            Console.WriteLine($"Total money in your bank Account: {account.Balance:f2}");

            Console.WriteLine("Commands: New Deposit, New Withdraw, Create Report, Total Balance, Clear, Quit.");
            while (true)
            {
                Console.Write("Command: ");
                var command = Console.ReadLine();

                if (command == "New Deposit")
                {
                    Console.Write("Enter deposit value: ");
                    double deposit = double.Parse(Console.ReadLine());
                    if (deposit <= 0)
                    {
                        Console.WriteLine("Invalid operation");
                        continue;
                    }

                    this.account.NewDeposit(deposit);
                    BankWriter.Append(FileName, deposit);
                    Console.WriteLine($"You deposited {deposit:f2} lv.");
                }
                else if (command == "New Withdraw")
                {
                    Console.Write("Enter value to withdraw: ");
                    var funds = double.Parse(Console.ReadLine());
                    if (funds <= 0)
                    {
                        Console.WriteLine("Invalid operation");
                        continue;
                    }

                    try
                    {
                        account.Withdraw(funds);
                    }
                    catch (ArgumentException ae) 
                    {
                        Console.WriteLine(ae.Message);
                        continue;
                    }

                    BankWriter.Append(FileName, -funds);
                    Console.WriteLine($"You withdrew {funds:f2} lv.");
                }
                else if (command == "Create Report")
                {
                    var incomes = BankReader.ReadIncomes(FileName);
                    HtmlGenerator.CreateReport(incomes);

                    Console.WriteLine($"report_{DateTime.Now.ToString("yyyy-MM-ddTimeHH-mm")}.html Created Successfully");

                }
                else if (command == "Total Balance")
                {
                    Console.WriteLine($"Total money in your bank Account: {account.Balance:f2}");
                }
                else if (command == "Clear")
                {
                    Console.WriteLine($"Are you sure, you want to clear your wallet?");
                    while (true)
                    {
                        var key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Enter)
                        {
                            this.account.Clear();
                            BankWriter.Clear(FileName);
                            Console.WriteLine("You reseted your balance!");
                            break;
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            Console.WriteLine("Clear denied.");
                            break;
                        }
                    }
                }
                else if (command == "Quit")
                {
                    break;
                }
            }
        }

        private bool Register()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            if(BankReader.DoesUsernameExist(username))
            {
                Console.WriteLine("Username already taken.");
                return Register();
            }

            Console.Write("Password: ");
            var password = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Full Name: ");
            var fullName = Console.ReadLine();

            this.FileName = Guid.NewGuid().ToString();
            BankWriter.CreateAccount(username, fullName, email, password, this.FileName);
            return true;
        }

        private bool Login()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            if (BankReader.IsUserPasswordCorrect(username, password))
            {
                FileName = BankReader.FindUserFileName(username);
                return true;
            }

            return false;
        }
    }
}
