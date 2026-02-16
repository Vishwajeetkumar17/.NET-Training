using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
    // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Course Code: ");
                            string? code = Console.ReadLine();

                            Console.Write("Enter Course Name: ");
                            string? name = Console.ReadLine();

                            Console.Write("Enter Credits: ");
                            int credits = int.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Enter Max Capacity (default 50): ");
                            string? capInput = Console.ReadLine();
                            int capacity = string.IsNullOrWhiteSpace(capInput) ? 50 : int.Parse(capInput);

                            Console.Write("Enter Prerequisites (comma-separated, or Enter for none): ");
                            string? prereq = Console.ReadLine();
                            List<string> prereqList = string.IsNullOrWhiteSpace(prereq)
                                ? new List<string>()
                                : prereq.Split(',').Select(p => p.Trim()).ToList();

                            system.AddCourse(code!, name!, credits, capacity, prereqList);
                            Console.WriteLine($"Course {code} added successfully.");
                            break;

                        case "2":
                            Console.Write("Enter Student ID: ");
                            string? id = Console.ReadLine();

                            Console.Write("Enter Name: ");
                            string? sname = Console.ReadLine();

                            Console.Write("Enter Major: ");
                            string? major = Console.ReadLine();

                            Console.Write("Enter Max Credits (default 18): ");
                            string? mc = Console.ReadLine();
                            int maxCredits = string.IsNullOrWhiteSpace(mc) ? 18 : int.Parse(mc);

                            Console.Write("Enter Completed Courses (comma-separated, or Enter for none): ");
                            string? comp = Console.ReadLine();
                            List<string> completed = string.IsNullOrWhiteSpace(comp)
                                ? new List<string>()
                                : comp.Split(',').Select(p => p.Trim()).ToList();

                            system.AddStudent(id!, sname!, major!, maxCredits, completed);
                            Console.WriteLine($"Student {id} added successfully.");
                            break;

                        case "3":
                            Console.Write("Enter Student ID: ");
                            string? sid = Console.ReadLine();

                            Console.Write("Enter Course Code: ");
                            string? cc = Console.ReadLine();

                            system.RegisterStudentForCourse(sid!, cc!);
                            break;

                        case "4":
                            Console.Write("Enter Student ID: ");
                            string? dsid = Console.ReadLine();

                            Console.Write("Enter Course Code: ");
                            string? dcc = Console.ReadLine();

                            system.DropStudentFromCourse(dsid!, dcc!);
                            break;

                        case "5":
                            system.DisplayAllCourses();
                            break;

                        case "6":
                            Console.Write("Enter Student ID: ");
                            string? sch = Console.ReadLine();
                            system.DisplayStudentSchedule(sch!);
                            break;

                        case "7":
                            system.DisplaySystemSummary();
                            break;

                        case "8":
                            exit = true;
                            break;
                    }
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}