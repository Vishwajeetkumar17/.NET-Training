using System;
using ScienceLib;
using MathsLib;

namespace Subjects
{
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Algebra algebra = new Algebra();
            int sum = algebra.Add(5, 3);
            int difference = algebra.Subtract(10, 4);
            Console.WriteLine($"Sum: {sum}, Difference: {difference}");

            AeroScience aeroScience = new AeroScience();

            string info = aeroScience.GetInfoPub();
            Console.WriteLine($"AeroScience Info: {info}");


            SciLogin sciLogin = new SciLogin();
            sciLogin.Login("vishwajeet", "pass123");
        }
    }
}
