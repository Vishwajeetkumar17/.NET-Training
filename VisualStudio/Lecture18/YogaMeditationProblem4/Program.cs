using System;
using System.Collections;
using System.Collections.Generic;

namespace YogaMeditationProblem4
{
    /// <summary>
    /// Represents a yoga meditation center member
    /// and stores health-related details.
    /// </summary>
    public class MeditationCenter
    {
        #region Properties

        // Gets or sets the member id
        public int MemberId { get; set; }

        // Gets or sets the age of the member
        public int Age { get; set; }

        // Gets or sets the weight of the member
        public double Weight { get; set; }

        // Gets or sets the height of the member
        public double Height { get; set; }

        // Gets or sets the fitness goal
        public string Goal { get; set; }

        // Gets or sets the calculated BMI
        public double BMI { get; set; }

        #endregion
    }

    /// <summary>
    /// Manages yoga members, calculates BMI,
    /// and determines yoga fees.
    /// </summary>
    public class Program
    {
        #region Fields

        // Stores the list of yoga members
        public static ArrayList memberList = new ArrayList();

        #endregion

        #region Member Management Methods

        // Adds a yoga member using provided details
        public void AddYogaMember(int memberId, int age, double weight, double height, string goal)
        {
            MeditationCenter member = new MeditationCenter
            {
                MemberId = memberId,
                Age = age,
                Weight = weight,
                Height = height,
                Goal = goal
            };

            memberList.Add(member);
        }

        #endregion

        #region Calculation Methods

        // Calculates and returns BMI for a given member
        public double CalculateBMI(int memberId)
        {
            foreach (MeditationCenter member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    double bmi = member.Weight / (member.Height * member.Height);
                    bmi = Math.Floor(bmi * 100) / 100;
                    member.BMI = bmi;
                    return bmi;
                }
            }
            return 0;
        }

        // Calculates and returns yoga fee based on BMI and goal
        public int CalculateYogaFee(int memberId)
        {
            foreach (MeditationCenter member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    if (member.Goal.Equals("Weight Loss"))
                    {
                        if (member.BMI >= 25 && member.BMI < 30)
                            return 2000;
                        else if (member.BMI >= 30 && member.BMI < 35)
                            return 2500;
                        else if (member.BMI >= 35)
                            return 3000;
                    }
                    else if (member.Goal.Equals("Weight Gain"))
                    {
                        return 2500;
                    }
                }
            }
            return 0;
        }

        #endregion

        #region UI Methods

        // Takes user input and adds a yoga member
        public void AddYogaMember()
        {
            Console.Write("Enter Member Id: ");
            if (!int.TryParse(Console.ReadLine(), out int memberId))
            {
                Console.WriteLine("Invalid Member Id");
                return;
            }

            Console.Write("Enter Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid Age");
                return;
            }

            Console.Write("Enter Weight: ");
            if (!double.TryParse(Console.ReadLine(), out double weight))
            {
                Console.WriteLine("Invalid Weight");
                return;
            }

            Console.Write("Enter Height: ");
            if (!double.TryParse(Console.ReadLine(), out double height))
            {
                Console.WriteLine("Invalid Height");
                return;
            }

            Console.Write("Enter Goal: ");
            string goal = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(goal))
            {
                Console.WriteLine("Invalid Goal");
                return;
            }

            AddYogaMember(memberId, age, weight, height, goal);
        }

        // Handles BMI calculation from user input
        public void CalculateBMIUI()
        {
            Console.Write("Enter Member Id: ");
            if (!int.TryParse(Console.ReadLine(), out int memberId))
            {
                Console.WriteLine("Invalid Member Id");
                return;
            }

            double bmi = CalculateBMI(memberId);
            if (bmi == 0)
            {
                Console.WriteLine($"MemberId {memberId} is not present");
            }
            else
            {
                Console.WriteLine("BMI: " + bmi);
            }
        }

        // Handles yoga fee calculation from user input
        public void CalculateYogaFeeUI()
        {
            Console.Write("Enter Member Id: ");
            if (!int.TryParse(Console.ReadLine(), out int memberId))
            {
                Console.WriteLine("Invalid Member Id");
                return;
            }

            int fee = CalculateYogaFee(memberId);
            if (fee == 0)
            {
                Console.WriteLine($"MemberId {memberId} is not present");
            }
            else
            {
                Console.WriteLine("Yoga Fee: " + fee);
            }
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            Program p = new Program();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("1. Add Yoga Member");
                Console.WriteLine("2. Calculate BMI");
                Console.WriteLine("3. Calculate Yoga Fee");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        p.AddYogaMember();
                        break;
                    case 2:
                        p.CalculateBMIUI();
                        break;
                    case 3:
                        p.CalculateYogaFeeUI();
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        #endregion
    }
}
