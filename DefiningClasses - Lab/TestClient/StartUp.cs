using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccount   
{
    public class StartUp    
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
            while ((command = Console.ReadLine())!= "End")
            {
                string[] input = command.Split();
                string commandType = input[0];
                switch (commandType)
                {
                    case"Create":
                        Create(input, accounts);    
                        break;
                    case "Deposit":
                        Deposit(input, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(input, accounts);
                        break;
                    case "Print":
                        Print(input, accounts);
                        break;
                }
            }
        }

        private static void Print(string[] input, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(input[1]);

            if (accounts.ContainsKey(id))
            {
                var acc = accounts.First(x => x.Key == id);
                Console.WriteLine(acc.Value);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(string[] input, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(input[1]);
            decimal amount = decimal.Parse(input[2]);

            if (accounts.ContainsKey(id))
            {
                var acc = accounts.First(x => x.Key == id);
                if (acc.Value.Balance < amount)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    acc.Value.Withdraw(amount);
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(string[] input, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(input[1]);
            decimal amount = decimal.Parse(input[2]);

            if (accounts.ContainsKey(id) == false)
            {
                Console.WriteLine("Account does not exist");               
            }
            else
            {
                var acc = accounts.First(x => x.Key == id);
                acc.Value.Deposit(amount);
            }
        }

        private static void Create(string[] input, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(input[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.Id = id;
                accounts.Add(id, acc);
            }
        }
    }
}
