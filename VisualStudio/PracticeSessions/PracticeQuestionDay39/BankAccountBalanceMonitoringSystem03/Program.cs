using System;
using System.Collections.Generic;

namespace BankAccountBalanceMonitoringSystem03
{

    class Program
    {
        static void Main(string[] args)
        {
            AccountUtility utility = new AccountUtility();

            utility.AddAccount(new Account("A101", "John", 5000));

            while (true)
            {
                Console.WriteLine("1 -> Display Accounts");
                Console.WriteLine("2 -> Deposit");
                Console.WriteLine("3 -> Withdraw");
                Console.WriteLine("4 -> Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            utility.DisplayAccounts();
                            break;

                        case 2:
                            Console.WriteLine("Enter Account Number:");
                            string depAcc = Console.ReadLine();

                            Console.WriteLine("Enter Deposit Amount:");
                            decimal depAmount = decimal.Parse(Console.ReadLine());

                            utility.Deposit(depAcc, depAmount);
                            Console.WriteLine("Deposit Successful");
                            break;

                        case 3:
                            Console.WriteLine("Enter Account Number:");
                            string witAcc = Console.ReadLine();

                            Console.WriteLine("Enter Withdraw Amount:");
                            decimal witAmount = decimal.Parse(Console.ReadLine());

                            utility.Withdraw(witAcc, witAmount);
                            Console.WriteLine("Withdrawal Successful");
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
