namespace PayRollBoard
{
    public abstract class EmployeeRecord
    {
        public string EmployeeName { get; set; }
        public double[] WeeklyHours { get; set; }

        public abstract double GetMonthlyPay();
    }

    public class FullTimeEmployee : EmployeeRecord
    {
        public double HourlyRate { get; set; }
        public double MonthlyBonus { get; set; }

        public override double GetMonthlyPay()
        {
            return WeeklyHours.Sum() * HourlyRate + MonthlyBonus;
        }
    }

    public class ContractEmployee : EmployeeRecord
    {
        public double HourlyRate { get; set; }
        public override double GetMonthlyPay()
        {
            
            return WeeklyHours.Sum() * HourlyRate;
        }
    }
}
