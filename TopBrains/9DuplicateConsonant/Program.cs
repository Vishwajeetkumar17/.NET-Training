namespace _9DuplicateConsonant
{
    public class Program
    {
        public static bool IsVowel(char v)
        {
            if(v == 'a' || v == 'e' || v == 'i' || v == 'o' || v == 'u')
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] letter = input.ToLower().Split(' ');
            Dictionary<char, int> count = new Dictionary<char, int>();
            foreach (char letterChar in letter[0])
            {
                if(!IsVowel(letterChar))
                    count[letterChar] = 1;
            }
            foreach(char letterChar in letter[1])
            {
                if (count.ContainsKey(letterChar))
                {
                    count[letterChar] = 2;
                }
            }
            string result = "";
            foreach(char letterChar in letter[0])
            {
                if(!(count.ContainsKey(letterChar) && count[letterChar] == 2))
                {
                    result += letterChar;
                }
            }
            for (int i = 0;i<result.Length - 1;i++)
            {
                if (result[i] == result[i + 1])
                {
                    result = result.Remove(i + 1, 1);
                    i--;
                }
            }
            Console.WriteLine(result);
        }
    }
}
