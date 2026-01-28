namespace GOAIRSecurity
{
    public class EntryUtility
    {
        public bool validateEmployeeId(string employeeId)
        {
            if (employeeId[0..5] == "GOAIR" && employeeId[5] == '/' && employeeId[6..10].All(char.IsDigit))
            {
                return true;
            }
            throw new InvalidEntryException("Invalid Entry Detail.");
        }

        public bool validateDuration(int duration)
        {
            if (duration >= 1 && duration <= 5)
            {
                return true;
            }
            throw new InvalidEntryException("Invalid Entry Detail.");
        }
    }
    public class Program
    {
        
        static void Main(string[] args)
        {
            EntryUtility entryUtility = new EntryUtility();

            Console.WriteLine("Enter the number of entries");
            int numOfEntries = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numOfEntries; i++)
            {
                Console.WriteLine($"Enter entry {i+1} details");
                string input = Console.ReadLine();
                try
                {
                    if (entryUtility.validateEmployeeId(input))
                    {
                        Console.WriteLine("Valid entry details");
                    }
                }
                catch(InvalidEntryException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
