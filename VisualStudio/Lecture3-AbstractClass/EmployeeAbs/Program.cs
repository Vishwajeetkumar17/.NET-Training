namespace EmployeeAbs
{

    /// <summary>
    /// Represents an employee and provides a base for employee-related operations.
    /// </summary>
    /// <remarks>This is an abstract base class intended to be inherited by specific employee types. Derived
    /// classes should implement tax calculation and other employee-specific logic as needed.</remarks>
    public abstract class Employee
    {
        public abstract double CalcTax();
        public double Salary { get; set; }
    }

    /// <summary>
    /// Represents an employee based in India with country-specific tax calculation logic.
    /// </summary>
    /// <remarks>This class overrides tax calculation behavior to reflect Indian tax rules. Use this type when
    /// working with employees whose tax treatment should follow Indian regulations.</remarks>

    public class IndianEmp : Employee
    {
        public override double CalcTax()
        {
            return Salary * 0.30;
        }
    }

    /// <summary>
    /// Represents an employee based in the United States with tax calculation logic specific to U.S. tax regulations.
    /// </summary>

    public class USAEmp : Employee
    {
        public override double CalcTax()
        {
            return Salary * 0.40;
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Employee emp1 = new IndianEmp { Salary = 100000.0 };
            Employee emp2 = new USAEmp { Salary = 100000.0 };
            double indianTax = emp1.CalcTax();
            double usaTax = emp2.CalcTax();
            System.Console.WriteLine($"Indian Employee Tax on 100000: {indianTax}");
            System.Console.WriteLine($"USA Employee Tax on 100000: {usaTax}");
        }
    }



}
