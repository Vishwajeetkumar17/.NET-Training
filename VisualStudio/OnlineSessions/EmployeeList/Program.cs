namespace EmployeeList
{
    internal class Program
    {
        public static List<Employee> employees = new List<Employee>
        {
            new Employee() {EmployeeID = 1001,FirstName = "Malcolm",LastName = "Daruwalla",Title = "Manager",DOB = DateTime.Parse("1984-01-02"),DOJ = DateTime.Parse("2011-08-09"),City = "Mumbai"},
            new Employee() {EmployeeID = 1002,FirstName = "Asdin",LastName = "Dhalla",Title = "AsstManager",DOB = DateTime.Parse("1984-08-20"),DOJ = DateTime.Parse("2012-7-7"),City = "Mumbai"},
            new Employee() {EmployeeID = 1003,FirstName = "Madhavi",LastName = "Oza",Title = "Consultant",DOB = DateTime.Parse("1987-11-14"),DOJ = DateTime.Parse("2105-12-04"),City = "Pune"},
            new Employee() {EmployeeID = 1004,FirstName = "Saba",LastName = "Shaikh",Title = "SE",DOB = DateTime.Parse("6/3/1990"),DOJ = DateTime.Parse("2/2/2016"),City = "Pune"},
            new Employee() {EmployeeID = 1005,FirstName = "Nazia",LastName = "Shaikh",Title = "SE",DOB = DateTime.Parse("3/8/1991"),DOJ = DateTime.Parse("2/2/2016"),City = "Mumbai"},
            new Employee() {EmployeeID = 1006,FirstName = "Suresh",LastName = "Pathak",Title = "Consultant",DOB = DateTime.Parse("11/7/1989"),DOJ = DateTime.Parse("8/8/2014"),City = "Chennai"},
            new Employee() {EmployeeID = 1007,FirstName = "Vijay",LastName = "Natrajan",Title = "Consultant",DOB = DateTime.Parse("12/2/1989"),DOJ = DateTime.Parse("6/1/2015"),City = "Mumbai"},
            new Employee() {EmployeeID = 1008,FirstName = "Rahul",LastName = "Dubey",Title = "Associate",DOB = DateTime.Parse("11/11/1993"),DOJ = DateTime.Parse("11/6/2014"),City = "Chennai"},
            new Employee() {EmployeeID = 1009,FirstName = "Amit",LastName = "Mistry",Title = "Associate",DOB = DateTime.Parse("8/12/1992"),DOJ = DateTime.Parse("12/3/2014"),City = "Chennai"},
            new Employee() {EmployeeID = 1010,FirstName = "Sumit",LastName = "Shah",Title = "Manager",DOB = DateTime.Parse("4/12/1991"),DOJ = DateTime.Parse("1/2/2016"),City = "Pune"},

        };
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            
            Console.WriteLine("All Employees Datails: ");
            var allEmployees = employees.ToList();
            foreach (var e in allEmployees)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName} {e.Title} {e.DOB.ToShortDateString()} {e.DOJ.ToShortDateString()} {e.City}");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Not Mumbai Employees Datails: ");
            var notMumbaiEmployees = employees.Where(e => e.City != "Mumbai").ToList();
            foreach (var e in notMumbaiEmployees)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName} {e.Title} {e.City}");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Assistant Managers Datails: ");
            var asstManagers = employees.Where(e => e.Title == "AsstManager").ToList();
            foreach (var e in asstManagers)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName} {e.Title}");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Last Name starts with 'S' Datails: ");
            var lastNameStartsWithS = employees.Where(e => e.LastName.StartsWith("S")).ToList();
            foreach (var e in lastNameStartsWithS)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName}");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Joined before 2015 Employees Datails: ");
            var joinedBefore2015 = employees.Where(e => e.DOJ < new DateTime(2015, 1, 1)).ToList();
            foreach (var e in joinedBefore2015)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName} {e.DOJ.ToShortDateString()}");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Date of birth After 1/1/1990");
            var birthAfterDate = employees.Where(e => e.DOB > new DateTime(1990, 1, 1)).ToList();
            foreach(var e in birthAfterDate)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName} {e.DOB.ToShortDateString()}");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("All Employees with Designation Consultant and Associate");
            var desIsConAndAss = employees.Where(e => e.Title == "Consultant" || e.Title == "Associate").ToList();
            foreach(var e in desIsConAndAss)
            {
                Console.WriteLine($"{e.EmployeeID} {e.FirstName} {e.LastName} {e.Title}");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Total number of Employees: ");
            var totalEmployees = employees.Count();
            Console.WriteLine(totalEmployees);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Total number of Employees belonging to Chennai");
            var totalEmpFromChennai = employees.Count(e => e.City == "Chennai");
            Console.WriteLine(totalEmpFromChennai);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Highest Employee Id from List");
            var highestEmpId = employees.Max(e => e.EmployeeID);
            Console.WriteLine(highestEmpId);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Total number of Employees Joined after 1/1/2015");
            var totalEmpJoinedAfter = employees.Where(e => e.DOJ > new DateTime(2015, 1, 1)).Count();
            Console.WriteLine(totalEmpJoinedAfter);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Total Employees whose Designation is not Associate");
            var desNotAssociate = employees.Where(e => e.Title != "Associate").Count();
            Console.WriteLine(desNotAssociate);
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Total number of Employees based on city");
            var empBasedOnCity = employees.GroupBy(e => e.City).Select(g => new { City = g.Key, Count = g.Count() });
            foreach(var e in empBasedOnCity)
            {
                Console.WriteLine($"{e.City} - {e.Count}");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("\nEmployee Count by City and Title");
            var CountByCityAndTitle = employees.GroupBy(e => new { e.City, e.Title }).Select(g => new { g.Key.City, g.Key.Title, Count = g.Count() }).ToList();
            CountByCityAndTitle.ForEach(c => Console.WriteLine($"City: {c.City}\t Title: {c.Title}\t Count: {c.Count}"));

            Console.WriteLine("----------------------------------------------------------------------");
            var YoungestDOB = employees.Max(e => e.DOB);
            var YoungestCount = employees.Count(e => e.DOB == YoungestDOB);
            Console.WriteLine($"\nYoungest Employee Count: {YoungestCount}");
        }
    }
}
