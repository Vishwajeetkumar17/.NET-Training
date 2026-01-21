namespace _8BankTransactionProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Balance");
            string input1 = Console.ReadLine();
            string input2;
            List<int> transactions = new List<int>();
            bool debit = true;
            while (debit)
            {
                Console.WriteLine("Enter 'Q/q' to exit");
                input2 = Console.ReadLine();
                if(input2.ToUpper() == "Q")
                {
                    debit = false;
                    break;
                }
                transactions.Add(int.Parse(input2));
            }
            if(decimal.TryParse(input1, out decimal deposit))
            {
                foreach(int tran in transactions)
                {
                    if(deposit + tran < 0)
                    {
                        continue;
                    }
                    deposit += tran;

                }
                Console.WriteLine("Your Remaining Balance: " + deposit);
            }
        }
    }
}
