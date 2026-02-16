using System;
using System.Collections.Generic;

namespace StudentGPARankingSystem02
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentUtility utility = new StudentUtility();

            while (true)
            {
                Console.WriteLine("1 -> Display Ranking");
                Console.WriteLine("2 -> Update GPA");
                Console.WriteLine("3 -> Add Student");
                Console.WriteLine("4 -> Exit");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            utility.DisplayRanking();
                            break;

                        case 2:
                            Console.WriteLine("Enter Student ID:");
                            string id = Console.ReadLine();

                            Console.WriteLine("Enter New GPA:");
                            double newGpa = double.Parse(Console.ReadLine());

                            utility.UpdateGPA(id, newGpa);
                            Console.WriteLine("GPA Updated Successfully");
                            break;

                        case 3:
                            Console.WriteLine("Enter StudentID Name GPA:");
                            string[] input = Console.ReadLine().Split(' ');

                            string sid = input[0];
                            string name = input[1];
                            double gpa = double.Parse(input[2]);

                            Student student = new Student(sid, name, gpa);
                            utility.AddStudent(student);

                            Console.WriteLine("Student Added Successfully");
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

