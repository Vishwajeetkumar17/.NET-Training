using System;

namespace EmployeeCompetition
{
    class Program
    {

        /// <summary>
        /// Created Eployee class with properties EmpId and Name
        /// </summary>
        public class Employee
        {
            public int EmpId { get; set; }
            public string Name { get; set; }

            public Employee()
            {
                EmpId = 0;
                Name = string.Empty;
            }
        }

        /// <summary>
        /// Created Competition class with properties CompId, Title, Price, EmpList and Winners
        /// </summary>
        public class Competition
        {
            public int CompId { get; set; }
            public string Title { get; set; }

            public string Price { get; set; }


            public List<int> EmpList = new List<int>();

            public List<int> Winners = new List<int>();
            public Competition()
            {
                CompId = 0;
                Title = string.Empty;
                Price = string.Empty;
            }

            public void DisplayDetails()
            {
                Console.WriteLine($"Competition ID: {CompId}");
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Price: {Price}");
            }

            public void AddEmployee(int empId)
            {
                EmpList.Add(empId);
            }

            public void AddWinner(int winnerId)
            {
                Winners.Add(winnerId);
            }
        }

        static void Main(string[] args)
        {
            Employee emp1 = new Employee { EmpId = 101, Name = "A" };
            Employee emp2 = new Employee { EmpId = 102, Name = "B" };
            Employee emp3 = new Employee { EmpId = 103, Name = "C" };
            Employee emp4 = new Employee { EmpId = 104, Name = "D" };
            Employee emp5 = new Employee { EmpId = 105, Name = "E" };

            Competition comp = new Competition
            {
                CompId = 1,
                Title = "Annual Coding Challenge",
                Price = "$5000"
            };

            Competition comp1 = new Competition
            {
                CompId = 2,
                Title = "Hackathon",
                Price = "$3000"
            };
            comp.AddEmployee(emp1.EmpId);
            comp.AddEmployee(emp2.EmpId);
            comp.AddEmployee(emp3.EmpId);
            comp1.AddEmployee(emp3.EmpId);
            comp1.AddEmployee(emp4.EmpId);
            comp1.AddEmployee(emp5.EmpId);


            comp.AddWinner(emp1.EmpId);
            comp.AddWinner(emp2.EmpId);
            comp1.AddWinner(emp4.EmpId);
            comp1.AddWinner(emp5.EmpId);
            comp1.AddWinner(emp3.EmpId);

            comp.DisplayDetails();
            Console.WriteLine("Participants:");
            foreach (var empId in comp.EmpList)
            {
                Console.WriteLine($"Employee ID: {empId}");
            }
            Console.WriteLine();

            comp1.DisplayDetails();
            Console.WriteLine("Participants:");
            foreach (var empId in comp1.EmpList)
            {
                Console.WriteLine($"Employee ID: {empId}");
            }
            Console.WriteLine();

            Console.WriteLine("Winners from Annual Coding Challenge :");
            foreach (var winner in comp.Winners)
            {
                Console.WriteLine($"Winner EmpId: {winner}");
            }
            Console.WriteLine($"Total Winners from {comp.Title} = {comp.Winners.Count}");
            Console.WriteLine();

            Console.WriteLine("Winners from Hackathon :");
            foreach (var winner in comp1.Winners)
            {
                Console.WriteLine($"Winner EmpId: {winner}");
            }
            Console.WriteLine($"Total Winners from {comp1.Title} = {comp1.Winners.Count}");
        }
    }
}
