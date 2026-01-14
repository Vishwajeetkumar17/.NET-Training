using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PayRollAndSalaryProcessing
{
    // Delegate triggered after salary is processed
    public delegate void SalaryProcessedHandler(PaySlip slip);

    /// <summary>
    /// Handles employee payroll processing, maintains payroll history,
    /// and generates payroll summary reports.
    /// </summary>
    public class PayrollProcessor
    {
        #region Fields

        // Stores the list of employees
        private static List<Employee> _employees = new List<Employee>();

        // Maintains payroll history mapped by employee id
        private Dictionary<int, PaySlip> _payrollHistory = new Dictionary<int, PaySlip>();

        // Delegate handler invoked after salary processing
        public SalaryProcessedHandler OnSalaryProcessed;

        #endregion

        #region Static Data Loader

        // Loads sample employees statically (Use Case 1)
        public static void AddData(PayrollProcessor processor)
        {
            processor.AddEmployee(new FullTimeEmployee(110, "Amit", "amit@corp.com", "IT", 50000, 5000));
            processor.AddEmployee(new FullTimeEmployee(210, "Neha", "neha@corp.com", "HR", 60000, 6000));
            processor.AddEmployee(new ContractEmployee(310, "Rahul", "rahul@corp.com", "Ops", 400, 20));
            processor.AddEmployee(new ContractEmployee(410, "Sneha", "sneha@corp.com", "Ops", 450, 22));
        }

        #endregion

        #region Public Methods

        // Adds an employee to the payroll system
        public void AddEmployee(Employee emp)
        {
            _employees.Add(emp);
        }

        // Executes payroll processing for all employees
        public void RunPayroll()
        {
            Console.WriteLine("--- Starting Payroll Process ---");

            foreach (var emp in _employees)
            {
                try
                {
                    PaySlip slip = emp.CalculateSalary();

                    if (_payrollHistory.ContainsKey(emp.Id))
                        _payrollHistory[emp.Id] = slip;
                    else
                        _payrollHistory.Add(emp.Id, slip);

                    OnSalaryProcessed?.Invoke(slip);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing employee {emp.Name}: {ex.Message}");
                }
            }
        }

        // Prints a summary report of processed payroll data
        public void PrintSummary()
        {
            Console.WriteLine("\n--- Payroll Summary Report ---");
            Console.WriteLine($"Total Employees Processed: {_payrollHistory.Count}");

            decimal totalPayout = _payrollHistory.Values.Sum(p => p.NetPay);
            Console.WriteLine($"Total Payout: {totalPayout}");

            var groups = _payrollHistory.Values.GroupBy(p => p.Type);
            foreach (var group in groups)
            {
                Console.WriteLine(
                    $"Type: {group.Key}, Count: {group.Count()}, Subtotal: {group.Sum(x => x.NetPay)}"
                );
            }
        }

        #endregion
    }
}
