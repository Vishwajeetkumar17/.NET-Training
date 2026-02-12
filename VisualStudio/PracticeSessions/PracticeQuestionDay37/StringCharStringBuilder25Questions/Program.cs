using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace StringCharStringBuilder25Questions
{
    class Program
    {
        static Dictionary<string, int> CountWords(string input)
        {
            input = input.ToLower();
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!char.IsLetterOrDigit(chars[i]) && chars[i] != ' ')
                    chars[i] = ' ';
            }
            string cleaned = new string(chars);
            string[] words = cleaned.Split(' ');
            Dictionary<string, int> count = new Dictionary<string, int>();
            foreach (string w in words)
            {
                if (count.ContainsKey(w))
                    count[w]++;
                else
                    count[w] = 1;
            }
            return count;
        }

        static string RunLengthEncode(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";
            StringBuilder result = new StringBuilder();
            int count = 1;
            for (int i = 1; i <= s.Length; i++)
            {
                if (i < s.Length && s[i] == s[i - 1])
                {
                    count++;
                }
                else
                {
                    result.Append(s[i - 1]);
                    result.Append(count);
                    count = 1;
                }
            }
            return result.ToString();
        }

        static int LongestUniqueSubstring(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int start = 0;
            int maxLen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]) && map[s[i]] >= start)
                    start = map[s[i]] + 1;
                map[s[i]] = i;
                int len = i - start + 1;
                if (len > maxLen)
                    maxLen = len;
            }
            return maxLen;
        }

        static bool AreAnagrams(string str1, string str2)
        {
            str1 = str1.ToLower();
            str2 = str2.ToLower();
            if (str1.Length != str2.Length)
                return false;
            Dictionary<char, int> count = new Dictionary<char, int>();
            foreach (char c in str1)
            {
                if (count.ContainsKey(c))
                    count[c]++;
                else
                    count[c] = 1;
            }
            foreach (char c in str2)
            {
                if (!count.ContainsKey(c))
                    return false;
                count[c]--;
                if (count[c] < 0)
                    return false;
            }
            return true;
        }

        static string ReverseWords(string s)
        {
            string[] words = s.Split(' ');
            Array.Reverse(words);
            return string.Join(" ", words);
        }

        static string RemoveDuplicates(string s)
        {
            HashSet<char> seen = new HashSet<char>();
            StringBuilder result = new StringBuilder();
            foreach (char c in s)
            {
                if (!seen.Contains(c))
                {
                    seen.Add(c);
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        static HashSet<string> FindPalindromes(string s)
        {
            HashSet<string> result = new HashSet<string>();

            for (int mid = 0; mid < s.Length; mid++)
            {
                int left = mid;
                int right = mid;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    result.Add(s.Substring(left, right - left + 1));
                    left--;
                    right++;
                }
                left = mid;
                right = mid + 1;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    result.Add(s.Substring(left, right - left + 1));
                    left--;
                    right++;
                }
            }
            return result;
        }

        static string ReplaceIgnoreCase(string text, string oldWord, string newWord)
        {
            string lowerText = text.ToLower();
            string lowerOld = oldWord.ToLower();
            StringBuilder result = new StringBuilder();
            int i = 0;
            while (i < text.Length)
            {
                if (i + oldWord.Length <= text.Length &&
                   lowerText.Substring(i, oldWord.Length) == lowerOld)
                {
                    result.Append(newWord);
                    i += oldWord.Length;
                }
                else
                {
                    result.Append(text[i]);
                    i++;
                }
            }
            return result.ToString();
        }

        static string MaskEmail(string email)
        {
            int atIndex = email.IndexOf('@');
            if (atIndex <= 1)
                return email;
            string first = email.Substring(0, 1);
            string domain = email.Substring(atIndex);
            return first + "***" + domain;
        }

        static bool IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                        return false;
                    char top = stack.Pop();
                    if ((c == ')' && top != '(') ||
                       (c == '}' && top != '{') ||
                       (c == ']' && top != '['))
                        return false;
                }
            }
            return stack.Count == 0;
        }
        static void Main()
        {
            //1. Word Frequency Counter – Count occurrences ignoring case and punctuation.
            //Console.WriteLine("Enter text:");
            //string input = Console.ReadLine();
            //Dictionary<string, int> result = CountWords(input);

            //foreach (var item in result)
            //    Console.WriteLine(item.Key + " : " + item.Value);


            //2. Longest substring without repeating characters.
            //Console.WriteLine("Enter string:");
            //string input = Console.ReadLine();
            //int result = LongestUniqueSubstring(input);
            //Console.WriteLine("Longest substring Length: " + result);


            //3. Run-length encoding (e.g., "aaabbcccc" → "a3b2c4").
            //Console.WriteLine("Enter string:");
            //string input = Console.ReadLine();
            //string encoded = RunLengthEncode(input);
            //Console.WriteLine(encoded);


            //4. Anagram checker without built-in sort.
            //Console.WriteLine("Enter first string:");
            //string s1 = Console.ReadLine();
            //Console.WriteLine("Enter second string:");
            //string s2 = Console.ReadLine();
            //string result = AreAnagrams(s1, s2) ? "Input Strings are Anagram" : "Input Strings are not Anagram";
            //Console.WriteLine(result);


            //5. Reverse words but not characters.
            //Console.WriteLine("Enter sentence:");
            //string input = Console.ReadLine();
            //string result = ReverseWords(input);
            //Console.WriteLine(result);


            //6. Remove duplicate characters while preserving order.
            //Console.WriteLine("Enter string:");
            //string input = Console.ReadLine();
            //string output = RemoveDuplicates(input);
            //Console.WriteLine(output);


            //7. Find all palindromic substrings.
            //Console.WriteLine("Enter string:");
            //string input = Console.ReadLine();
            //var palindromes = FindPalindromes(input);
            //foreach (string p in palindromes)
            //    Console.WriteLine(p);


            //8. Case-insensitive replace without regex.
            //Console.WriteLine("Enter text:");
            //string text = Console.ReadLine();
            //Console.WriteLine("Enter word to replace:");
            //string oldWord = Console.ReadLine();
            //Console.WriteLine("Enter replacement:");
            //string newWord = Console.ReadLine();
            //string output = ReplaceIgnoreCase(text, oldWord, newWord);
            //Console.WriteLine(output);


            //9. Email masking ("john.doe@gmail.com" → "j***@gmail.com").
            //Console.WriteLine("Enter email:");
            //string input = Console.ReadLine();
            //string result = MaskEmail(input);
            //Console.WriteLine(result);


            //10. Balanced parentheses validator.
            //Console.WriteLine("Enter expression:");
            //string input = Console.ReadLine();
            //string result = IsBalanced(input) ? "Balanced" : "Not Balanced";
            //Console.WriteLine(result);
        }
    }

}
