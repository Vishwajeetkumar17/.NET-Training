namespace CustomExceptionLoginAttempts
{
    class LoginSystem
    {
        static void Main()
        {
            int attempts = 3;
            string password = "Vishwajeet";
            int inputCount = 0;
            // TODO:
            // 1. Allow only 3 login attempts
            try
            {
                while (true)
                {
                    Console.WriteLine("Enter the Password");
                    string input = Console.ReadLine();
                    if (password == input)
                    {
                        Console.WriteLine("Hurray! Correct Password");
                        break;
                    }
                    else
                    {
                        if (attempts == inputCount + 1)
                        {
                            throw new LoginAttempt("You have reached the limits.");
                        }
                        inputCount++;
                        Console.WriteLine($"Remaining Attempts: {attempts - inputCount}");
                    }
                }
                // 2. Create and throw custom exception after limit
                // 3. Handle exception and terminate application
            }
            catch(LoginAttempt ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
