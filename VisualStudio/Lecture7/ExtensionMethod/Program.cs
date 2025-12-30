using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    /// <summary>
    /// Provides the entry point for the application.
    /// </summary>
    /// <remarks>This class contains the Main method, which demonstrates the usage of string extension methods
    /// such as WordCount and IsPalindrome. The application outputs the word count of a sample string and checks whether
    /// given strings are palindromes.</remarks>
    public class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello Extension Method";
            int count = str.WordCount();
            Console.WriteLine($"Word Count: {count}");

            string palindromeStr = "madam";
            bool isPalindrome = palindromeStr.IsPalindrome();
            Console.WriteLine($"Is '{palindromeStr}' a palindrome? {isPalindrome}");

            string nonPalindromeStr = "hello";
            bool isNonPalindrome = nonPalindromeStr.IsPalindrome();
            Console.WriteLine($"Is '{nonPalindromeStr}' a palindrome? {isNonPalindrome}");
        }
    }
}
