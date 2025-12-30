using System;
using System.Text.RegularExpressions;

namespace RegexSample
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = "Error : TIMEOUT while getting API";
            string pattern = @"timeout";

            var rex = new Regex(pattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(150));

            try
            {
                Console.WriteLine(rex.IsMatch(input) ? "Found" : "Not Found");
            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("Regex timed out");
            }
        }
    }
}
