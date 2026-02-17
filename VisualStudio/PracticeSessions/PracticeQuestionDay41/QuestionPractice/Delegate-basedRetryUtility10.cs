using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionPractice
{
    public class Delegate_basedRetryUtility10
    {
        private static int _tries = 0;                    // Simulation counter

        public static void Main()
        {
            // A function that fails twice, then succeeds
            int result = ExecuteWithRetry(() =>
            {
                _tries++;
                if (_tries <= 2) throw new InvalidOperationException("Temporary failure");
                return 999;
            }, maxAttempts: 3);

            Console.WriteLine(result);                    // Expected: 999
        }

        // ✅ TODO: Students implement only this function
        public static T ExecuteWithRetry<T>(Func<T> work, int maxAttempts)
        {
            // TODO:
            // 1) Validate inputs
            // 2) Try executing work
            // 3) If exception occurs and attempts remain, retry
            // 4) If attempts exhausted, throw last exception

            
            if (work == null)
                throw new ArgumentNullException("Invalid Input.");
            if(maxAttempts <= 0)
            {
                throw new Exception("Max Attempts should be greater than 0.");
            }

            Exception? lastException = null;
            for (int i = 1; i <= maxAttempts; i++)
            {
                try
                {
                    Console.WriteLine($"{i} try");
                    return work();
                }
                catch(Exception ex)
                {
                    lastException = ex;
                }
            }
            throw new Exception("All tries expired: ", lastException);
        }
    }
}
