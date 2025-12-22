using System;

namespace Lecture1
{
    // Summary: Checks admission eligibility based on Math, Physics, and Chemistry marks
    // using individual thresholds and combined totals.
    public class AdmEligibility
    {
        public static void Eligilibity()
        {
            Console.Write("Enter the Marks of Math : ");
            string? input1 = Console.ReadLine();
            Console.Write("Enter the Marks of Phy : ");
            string? input2 = Console.ReadLine();
            Console.Write("Enter the Marks of Che : ");
            string? input3 = Console.ReadLine();
            int total = 0;

            if (int.TryParse(input1, out int math) && int.TryParse(input2, out int phy) && int.TryParse(input3, out int che) && (math >= 0 && math <= 100) && (che >= 0 && che <= 100) && (phy >= 0 && phy <= 100))
            {
                total = math + phy + che;
                if (math >= 65 && phy >= 55 && che >= 50 && (total >= 180 || ((math + phy) >= 140)))
                {
                    Console.WriteLine("You are Eligible");
                }
                else
                {
                    Console.WriteLine("You are not Eligible");
                }
            }
            else
            {
                Console.WriteLine("Enter a Valid Number");
            }
        }
    }
}