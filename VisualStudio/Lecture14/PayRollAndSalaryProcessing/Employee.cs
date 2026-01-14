using System;
using System.Collections.Generic;
using System.Text;

namespace PayRollAndSalaryProcessing
{
    /// <summary>
    /// Defines common employee details and salary
    /// calculation contract for all employee types.
    /// </summary>
    public abstract class Employee
    {
        #region Fields

        // Stores employee id
        private int _id;

        // Stores employee name
        private string _name;

        // Stores employee email
        private string _email;

        // Stores employee department
        private string _department;

        // Stores employee joining date
        private DateTime _joinDate;

        // Indicates whether employee is active
        private bool _isActive;

        #endregion

        #region Properties

        // Gets or sets employee id
        public int Id { get { return _id; } set { _id = value; } }

        // Gets or sets employee name
        public string Name { get { return _name; } set { _name = value; } }

        // Gets or sets employee email
        public string Email { get { return _email; } set { _email = value; } }

        // Gets the employee type
        public string EmployeeType { get; protected set; }

        #endregion

        #region Constructors

        // Initializes common employee details
        public Employee(int id, string name, string email, string dept)
        {
            _id = id;
            _name = name;
            _email = email;
            _department = dept;
            _joinDate = DateTime.Now;
            _isActive = true;
        }

        #endregion

        #region Abstract Methods

        // Calculates salary and returns payslip
        public abstract PaySlip CalculateSalary();

        #endregion
    }

    /// <summary>
    /// Represents a full-time employee and
    /// calculates salary with bonus and tax.
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        #region Properties

        // Gets or sets the basic salary
        public decimal BasicSalary { get; set; }

        // Gets or sets the bonus amount
        public decimal Bonus { get; set; }

        #endregion

        #region Constructors

        // Initializes full-time employee details
        public FullTimeEmployee(int id, string name, string email, string dept, decimal basic, decimal bonus)
            : base(id, name, email, dept)
        {
            BasicSalary = basic;
            Bonus = bonus;
            EmployeeType = "Full-Time";
        }

        #endregion

        #region Public Methods

        // Calculates salary for full-time employee
        public override PaySlip CalculateSalary()
        {
            decimal gross = BasicSalary + Bonus;
            decimal tax = gross * 0.10m;
            decimal net = gross - tax;

            return new PaySlip(Id, Name, EmployeeType, gross, tax, net);
        }

        #endregion
    }

    /// <summary>
    /// Represents a contract employee and
    /// calculates salary based on hours worked.
    /// </summary>
    public class ContractEmployee : Employee
    {
        #region Properties

        // Gets or sets the hourly rate
        public decimal HourlyRate { get; set; }

        // Gets or sets hours worked
        public int HoursWorked { get; set; }

        #endregion

        #region Constructors

        // Initializes contract employee details
        public ContractEmployee(int id, string name, string email, string dept, decimal rate, int hours)
            : base(id, name, email, dept)
        {
            HourlyRate = rate;
            HoursWorked = hours;
            EmployeeType = "Contract";
        }

        #endregion

        #region Public Methods

        // Calculates salary for contract employee
        public override PaySlip CalculateSalary()
        {
            if (HoursWorked < 0) throw new ArgumentException("Hours cannot be negative");

            decimal gross = HourlyRate * HoursWorked;
            decimal tax = gross * 0.05m;
            decimal net = gross - tax;

            return new PaySlip(Id, Name, EmployeeType, gross, tax, net);
        }

        #endregion
    }
}
