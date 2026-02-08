namespace OnlineSession
{
    public class EmployeeDate16J
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        //public Employee(string id, string name, decimal salary)
        //{
        //    Id = id;
        //    Name = name;
        //    Salary = salary;

        //    Console.WriteLine($"Id : {Id}, Name : {Name}, Salary : {Salary}");
        //}

        public static void Main(string[] args)
        {
            EmployeeDate16J emp = new EmployeeDate16J { Id = "E101", Name = "Vishwajeet", Salary = 10000m };
            Console.WriteLine(emp.Id);
            Console.WriteLine(emp.Name);
            Console.WriteLine(emp.Salary);
        }
    }

    public class Person : IComparable<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            return other.Id.CompareTo(this.Id);
        }

        public static void Main()
        {
            List<Person> people = new List<Person>
            {
            new Person { Id = 101, Name = "A", Age = 12 },
            new Person { Id = 102, Name = "B", Age = 23 },
            new Person { Id = 103, Name = "C", Age = 34 }
            };
            people.Sort();
            Person secondHighest = people[1];
            Console.WriteLine("Second Highest Id: " + secondHighest.Id);
            Console.WriteLine("Name: " + secondHighest.Name);
            Console.WriteLine("Age: " + secondHighest.Age);
        }
    }
}
