using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    #region Extension Methods

    /// <summary>
    /// Provides extension methods for working with strings, including word counting and palindrome detection.
    /// </summary>
    /// <remarks>This static class contains utility methods that extend the functionality of the <see
    /// cref="string"/> type. The methods are intended to simplify common string operations and can be called as
    /// extension methods on any string instance.</remarks>
    public static class StringExtensions
    {
        #region WordCount

        /// <summary>
        /// Returns the number of words in the specified string, using spaces as word separators.
        /// </summary>
        /// <remarks>This method considers a word to be any sequence of characters separated by spaces.
        /// Multiple consecutive spaces and leading or trailing spaces may affect the result. The method does not
        /// account for punctuation or other whitespace characters as word boundaries.</remarks>
        /// <param name="str">The string to count words in. Cannot be null.</param>
        /// <returns>The number of words found in the input string. Returns 1 if the string contains no spaces.</returns>
        public static int WordCount(this string str)
        {
            char[] chars = str.ToCharArray();
            int count = 1;
            foreach (var item in chars)
            {
                if (item.Equals(' '))
                    count++;
            }

            return count;
        }

        #endregion

        #region IsPalindrome

        /// <summary>
        /// Determines whether the specified string is a palindrome.
        /// </summary>
        /// <remarks>The comparison is case-sensitive and considers all characters, including whitespace
        /// and punctuation. An empty string is considered a palindrome.</remarks>
        /// <param name="str">The string to evaluate for palindrome status. Cannot be null.</param>
        /// <returns>true if the string reads the same backward as forward; otherwise, false.</returns>
        public static bool IsPalindrome(this string str)
        {
            int l = 0;
            int r = str.Length - 1;
            while (l < r)
            {
                if (str[l] != str[r])
                    return false;
                l++;
                r--;
            }
            return true;
        }

        #endregion
    }
    #endregion
}
