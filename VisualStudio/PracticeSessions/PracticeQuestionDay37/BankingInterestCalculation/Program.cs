using System.Transactions;
using System.Xml.Linq;

namespace BankingInterestCalculation
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine("Deposit Successful\nCurrent Balance: " + Balance);
        }
        public void WithDraw(decimal amount)
        {
            if(Balance > amount)
            {
                Balance -= amount;
                Console.WriteLine("Withdraw Successful\nCurrent Balance:" + Balance);
            }
            else
            {
                Console.WriteLine("Amount is greater than Balance");
                return;
            }
        }
    }
    public class SavingsAccount : BankAccount
    {
        public void CalcInterset(int interest)
        {
            Balance = Balance + (interest * Balance / 100);
            Console.WriteLine("Balance after Interest: " + Balance);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());
            BankAccount account = new BankAccount() { Balance = balance };
            SavingsAccount savingAccount = new SavingsAccount() { Balance = balance };
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Interest");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.WriteLine("Enter the Choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        
                        Console.WriteLine("Enter Amount to Deposit: ");
                        decimal dAmount = decimal.Parse(Console.ReadLine());
                        account.Deposit(dAmount);
                        break;
                    case 2:
                        Console.WriteLine("Enter amount to withdraw");
                        decimal wAmount = decimal.Parse(Console.ReadLine());
                        account.WithDraw(wAmount);
                        break;
                    case 3:
                        Console.WriteLine("Enter the interest(%)");
                        int interest = int.Parse(Console.ReadLine());
                        Console.WriteLine("Total Balance after Interest");
                        savingAccount.CalcInterset(interest);
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }
}
