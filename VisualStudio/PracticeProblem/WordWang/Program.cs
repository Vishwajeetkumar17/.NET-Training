namespace WordWang
{
    public class Program
    {
        public static void EvenLength(string[] arrMan)
        {
            string revName = "";
            for(int i=arrMan.Length-1; i>=0; i--)
            {
                revName += arrMan[i];
                if (i == 0) continue;
                else
                    revName += " ";
            }
            Console.WriteLine(revName);
        }

        public static void OddLength(string[] arrMan)
        {
            string revWords = "";
            foreach(var item in arrMan)
            {
                string rev = "";
                char[] chars = item.ToCharArray();
                for(int i=chars.Length-1; i>=0; i--)
                {
                    rev += chars[i];
                }
                revWords += rev;
                revWords += " ";
            }
            Console.WriteLine(revWords);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Sentence");
            string man = Console.ReadLine();

            string[] arrMan = man.Split(' ');
            int length = arrMan.Length;
            Console.WriteLine("Word Count: " + length);

            if (length % 2 == 0)
            {
                EvenLength(arrMan);
            }
            else
            {
                OddLength(arrMan);
            }
        }
    }
}
