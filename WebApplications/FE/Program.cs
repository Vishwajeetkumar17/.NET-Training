using BL;

namespace FE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = BL.UserBL.RevName();
            Console.WriteLine(name);
        }
    }
}
