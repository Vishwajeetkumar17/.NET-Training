namespace Lecture1
{

    public class InfiniteEvenOdd
    {
        public bool calc(int num)
        {
            return num % 2 == 0;
        }

        public static void Infinite()
        {
            InfiniteEvenOdd pro = new InfiniteEvenOdd();

            while (true)
            {
                Console.WriteLine("Enter the Number for stopping write exit\n");
                string? input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }

                if (int.TryParse(input, out int num))
                {
                    bool n = pro.calc(num);
                    if (n == true)
                    {
                        Console.WriteLine("even");
                    }
                    else
                    {
                        Console.WriteLine("Odd");
                    }
                }
            }
        }
    }
}