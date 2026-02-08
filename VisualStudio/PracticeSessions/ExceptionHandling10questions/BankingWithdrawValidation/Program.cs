namespace BankingWithdrawValidation
{
    class BankAccount
    {
        static void Main()
        {
            int balance = 10000;

            Console.WriteLine("Enter withdrawal amount:");
            int amount = int.Parse(Console.ReadLine());
            try
            {
                // TODO:
                // 1. Throw exception if amount <= 0
                if (amount <= 0)
                {
                    throw new BankException("Amount should be greater than 0.");
                }
                // 2. Throw exception if amount > balance
                if (amount > balance)
                {
                    throw new BankException("Amount is greater than Balance");
                }
                // 3. Deduct amount if valid
                balance -= amount;
            }
            catch(BankException ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            // 4. Use finally block to log transaction
            finally
            {
                Console.WriteLine($"Transaction log: Remaining Balance = {balance}");
            }
        }
    }
}
