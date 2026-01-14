using System;
using System.Collections.Generic;
using System.Text;

namespace PayRollAndSalaryProcessing
{
    /// <summary>
    /// Represents a payslip containing salary details
    /// for a processed employee.
    /// </summary>
    public class PaySlip
    {
        #region Properties

        // Gets or sets the employee id
        public int EmployeeId { get; set; }

        // Gets or sets the employee name
        public string EmployeeName { get; set; }

        // Gets or sets the employee type
        public string Type { get; set; }

        // Gets or sets the gross salary
        public decimal GrossPay { get; set; }

        // Gets or sets the total deductions
        public decimal Deductions { get; set; }

        // Gets or sets the net salary
        public decimal NetPay { get; set; }

        // Gets or sets the salary processed date
        public DateTime ProcessedDate { get; set; }

        #endregion

        #region Constructors

        // Initializes a new PaySlip instance
        public PaySlip(int id, string name, string type, decimal gross, decimal ded, decimal net)
        {
            EmployeeId = id;
            EmployeeName = name;
            Type = type;
            GrossPay = gross;
            Deductions = ded;
            NetPay = net;
            ProcessedDate = DateTime.Now;
        }

        #endregion

        #region Public Methods

        // Returns formatted payslip details
        public override string ToString()
        {
            return $"ID: {EmployeeId} | Name: {EmployeeName} ({Type}) | Net: {NetPay}";
        }

        #endregion
    }
}
