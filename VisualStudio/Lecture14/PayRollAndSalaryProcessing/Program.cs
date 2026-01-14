using System;

namespace PayRollAndSalaryProcessing
{
    /// <summary>
    /// Acts as the entry point for executing the payroll process
    /// and handling salary processed notifications.
    /// </summary>
    class Program
    {
        #region Notification Methods

        // Notifies HR after salary is processed
        static void NotifyHR(PaySlip slip)
        {
            Console.WriteLine($"[HR Notification] Record updated for {slip.EmployeeName}. Net: {slip.NetPay}");
        }

        // Notifies Finance after salary is processed
        static void NotifyFinance(PaySlip slip)
        {
            Console.WriteLine($"[Finance Notification] Fund transfer initiated for Acc#{slip.EmployeeId}. Amount: {slip.NetPay}");
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            PayrollProcessor processor = new PayrollProcessor();

            PayrollProcessor.AddData(processor);

            processor.OnSalaryProcessed += NotifyHR;
            processor.OnSalaryProcessed += NotifyFinance;

            processor.AddEmployee(new FullTimeEmployee(101, "A", "a@corp.com", "IT", 50000, 5000));
            processor.AddEmployee(new FullTimeEmployee(102, "B", "b@corp.com", "HR", 45000, 2000));
            processor.AddEmployee(new ContractEmployee(201, "C", "c@corp.com", "Ops", 50, 160));
            processor.AddEmployee(new ContractEmployee(202, "D", "d@corp.com", "Ops", 60, 100));

            processor.RunPayroll();
            processor.PrintSummary();

            Console.ReadLine();
        }

        #endregion
    }
}
