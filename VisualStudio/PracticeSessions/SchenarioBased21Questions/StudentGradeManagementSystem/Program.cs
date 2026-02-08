using System;
using System.Collections.Generic;

namespace StudentGradeManagementSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string GradeLevel { get; set; }
        public Dictionary<string, double> Subjects { get; set; }

        public Student()
        {
            Subjects = new Dictionary<string, double>();
        }
    }

    public class SchoolManager
    {
        private readonly List<Student> students = new List<Student>();
        private int id = 1;

        public void AddStudent(string name, string gradeLevel)
        {
            Student student = new Student
            {
                StudentId = id++,
                Name = name,
                GradeLevel = gradeLevel
            };

            students.Add(student);
        }

        public void AddGrade(int studentId, string subject, double grade)
        {
            foreach (Student student in students)
            {
                if (student.StudentId == studentId)
                {
                    student.Subjects[subject] = grade;
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }

        public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
        {
            SortedDictionary<string, List<Student>> groupStudents =
                new SortedDictionary<string, List<Student>>();

            foreach (Student student in students)
            {
                if (!groupStudents.ContainsKey(student.GradeLevel))
                {
                    groupStudents[student.GradeLevel] = new List<Student>();
                }
                groupStudents[student.GradeLevel].Add(student);
            }

            return groupStudents;
        }

        public double CalculateStudentAverage(int studentId)
        {
            foreach (Student student in students)
            {
                if (student.StudentId == studentId)
                {
                    double total = 0;
                    int count = 0;

                    foreach (double grade in student.Subjects.Values)
                    {
                        total += grade;
                        count++;
                    }

                    return count == 0 ? 0 : total / count;
                }
            }
            return 0;
        }

        public Dictionary<string, double> CalculateSubjectAverages()
        {
            Dictionary<string, double> totalMarks = new Dictionary<string, double>();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (Student student in students)
            {
                foreach (var subject in student.Subjects)
                {
                    if (!totalMarks.ContainsKey(subject.Key))
                    {
                        totalMarks[subject.Key] = 0;
                        counts[subject.Key] = 0;
                    }

                    totalMarks[subject.Key] += subject.Value;
                    counts[subject.Key]++;
                }
            }

            Dictionary<string, double> averages = new Dictionary<string, double>();

            foreach (var subject in totalMarks.Keys)
            {
                averages[subject] = totalMarks[subject] / counts[subject];
            }

            return averages;
        }

        public List<Student> GetTopPerformers(int count)
        {
            List<Student> eligible = new List<Student>();

            foreach (Student student in students)
            {
                if (student.Subjects.Count > 0)
                {
                    eligible.Add(student);
                }
            }

            eligible.Sort((a, b) =>
            {
                double avgA = CalculateStudentAverage(a.StudentId);
                double avgB = CalculateStudentAverage(b.StudentId);
                return avgB.CompareTo(avgA);
            });

            List<Student> result = new List<Student>();

            for (int i = 0; i < count && i < eligible.Count; i++)
            {
                result.Add(eligible[i]);
            } 

            return result;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            SchoolManager manager = new SchoolManager();

            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grade");
                Console.WriteLine("3. Group Students by Grade Level");
                Console.WriteLine("4. Calculate Student Average");
                Console.WriteLine("5. Subject-wise Averages");
                Console.WriteLine("6. Top Performers");
                Console.WriteLine("7. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Grade Level (9th/10th/11th/12th): ");
                    string grade = Console.ReadLine();

                    manager.AddStudent(name, grade);
                    Console.WriteLine("Student added.\n");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Student ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Subject: ");
                    string subject = Console.ReadLine();

                    Console.Write("Enter Grade (0-100): ");
                    double grade = double.Parse(Console.ReadLine());

                    manager.AddGrade(id, subject, grade);
                    Console.WriteLine("Grade added.\n");
                }
                else if (choice == 3)
                {
                    var groups = manager.GroupStudentsByGradeLevel();

                    foreach (var group in groups)
                    {
                        Console.WriteLine($"Grade Level: {group.Key}");
                        foreach (Student s in group.Value)
                        {
                            Console.WriteLine($"ID: {s.StudentId}, Name: {s.Name}");
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Student ID: ");
                    int id = int.Parse(Console.ReadLine());

                    double avg = manager.CalculateStudentAverage(id);
                    Console.WriteLine($"Average Grade: {avg}\n");
                }
                else if (choice == 5)
                {
                    var averages = manager.CalculateSubjectAverages();

                    foreach (var item in averages)
                    {
                        Console.WriteLine($"{item.Key} : {item.Value}");
                    }
                    Console.WriteLine();
                }
                else if (choice == 6)
                {
                    Console.Write("Enter number of top students: ");
                    int count = int.Parse(Console.ReadLine());

                    var top = manager.GetTopPerformers(count);

                    if (top.Count == 0)
                    {
                        Console.WriteLine("No students with grades found.\n");
                    }
                    else
                    {
                        foreach (Student s in top)
                        {
                            Console.WriteLine(
                                $"ID: {s.StudentId}, Name: {s.Name}, Avg: {manager.CalculateStudentAverage(s.StudentId)}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 7)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.\n");
                }
            }
        }
    }
}
