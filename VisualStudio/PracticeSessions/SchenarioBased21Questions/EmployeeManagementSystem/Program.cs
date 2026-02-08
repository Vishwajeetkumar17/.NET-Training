namespace EmployeeManagementSystem
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime JoiningDate { get; set; }
    }
    public class HRManager
    {
        private readonly List<Employee> employees = new List<Employee>();
        private static readonly Random random = new Random();

        private DateTime GetRandomJoiningDate()
        {
            int startYear = 2018;
            int endYear = DateTime.Now.Year - 1;

            int year = random.Next(startYear, endYear + 1);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);

            return new DateTime(year, month, day);
        }

        public void AddEmployee(string name, string dept, double salary)
        {
            int key = Program.AllEmployees.Count + 1;

            Employee employee = new Employee
            {
                EmployeeId = key,
                Name = name,
                Department = dept,
                Salary = salary,
                JoiningDate = GetRandomJoiningDate()
            };

            employees.Add(employee);
            Program.AllEmployees.Add(key, new List<Employee> { employee });
        }
        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            SortedDictionary<string, List<Employee>> groupEmployee = new SortedDictionary<string, List<Employee>>();
            foreach (var employeeGroup in Program.AllEmployees.Values)
            {
                foreach(var employee in employeeGroup)
                {
                    if (!groupEmployee.ContainsKey(employee.Department))
                    {
                        groupEmployee[employee.Department] = new List<Employee>();
                    }
                    groupEmployee[employee.Department].Add(employee);
                }
            }
            return groupEmployee;
        }
        public double CalculateDepartmentSalary(string department)
        {
            double salary = employees.Where(d => d.Department == department).Sum(e => e.Salary);
            return salary;
        }
        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            List<Employee> emp = employees.Where(e => e.JoiningDate > date).ToList();
            return emp;
        }
    }
    public class Program
    {
        public static SortedDictionary<int, List<Employee>> AllEmployees = new SortedDictionary<int, List<Employee>>();
        static void Main(string[] args)
        {
            HRManager manager = new HRManager();

            while (true)
            {
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Group Employees by Department");
                Console.WriteLine("3. Calculate Department Salary");
                Console.WriteLine("4. Get Employees Joined After Date");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Department: ");
                    string dept = Console.ReadLine();

                    Console.Write("Enter Salary: ");
                    double salary = double.Parse(Console.ReadLine());

                    manager.AddEmployee(name, dept, salary);
                    Console.WriteLine("Employee added successfully.\n");
                }
                else if (choice == 2)
                {
                    var grouped = manager.GroupEmployeesByDepartment();

                    foreach (var dept in grouped)
                    {
                        Console.WriteLine($"Department: {dept.Key}");
                        foreach (Employee emp in dept.Value)
                        {
                            Console.WriteLine(
                                $"ID: E00{emp.EmployeeId}, Name: {emp.Name}, Salary: {emp.Salary}, Joined: {emp.JoiningDate:dd-MM-yyyy}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Department Name: ");
                    string department = Console.ReadLine();

                    double totalSalary = manager.CalculateDepartmentSalary(department);
                    Console.WriteLine($"Total Salary for {department}: {totalSalary}\n");
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Date (yyyy-mm-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    var employees = manager.GetEmployeesJoinedAfter(date);

                    if (employees.Count == 0)
                    {
                        Console.WriteLine("No employees found.\n");
                    }
                    else
                    {
                        foreach (Employee emp in employees)
                        {
                            Console.WriteLine(
                                $"ID: {emp.EmployeeId}, Name: {emp.Name}, Department: {emp.Department}, Joined: {emp.JoiningDate:dd-MM-yyyy}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Exiting application.");
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
