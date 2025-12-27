using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace PayRollBoard
{
    public class Program
    {

        public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();

        public void RegisterEmployee(EmployeeRecord record)
        {
            PayrollBoard.Add(record);
        }

        public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var emp in records)
            {
                int count = 0;
                foreach (var hours in emp.WeeklyHours)
                {
                    if (hours >= hoursThreshold)
                    {
                        count++;
                    }
                }

                if (count > 0)
                {
                    result[emp.EmployeeName] = count;
                }
            }

            return result;
        }

        public double CalculateAverageMonthlyPay()
        {
            if (PayrollBoard.Count == 0)
                return 0;

            double total = 0;
            foreach (var emp in PayrollBoard)
            {
                total += emp.GetMonthlyPay();
            }

            return total / PayrollBoard.Count;
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Register Employee");
                Console.WriteLine("2. Show Overtime Summary");
                Console.WriteLine("3. Calculate Average Monthly Pay");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.WriteLine("Enter your choice:");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Select Employee Type (1-Full Time, 2-Contract):");
                    int type = int.Parse(Console.ReadLine());

                    Console.WriteLine();
                    Console.WriteLine("Enter Employee Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("Enter Hourly Rate:");
                    double rate = double.Parse(Console.ReadLine());

                    double[] hours = new double[4];
                    Console.WriteLine();
                    Console.WriteLine("Enter weekly hours (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                    {
                        hours[i] = double.Parse(Console.ReadLine());
                    }

                    if (type == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter Monthly Bonus:");
                        double bonus = double.Parse(Console.ReadLine());

                        FullTimeEmployee fte = new FullTimeEmployee
                        {
                            EmployeeName = name,
                            HourlyRate = rate,
                            MonthlyBonus = bonus,
                            WeeklyHours = hours
                        };

                        program.RegisterEmployee(fte);
                    }
                    else
                    {
                        ContractEmployee ce = new ContractEmployee
                        {
                            EmployeeName = name,
                            HourlyRate = rate,
                            WeeklyHours = hours
                        };

                        program.RegisterEmployee(ce);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Employee registered successfully");
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter hours threshold:");
                    double threshold = double.Parse(Console.ReadLine());

                    var result = program.GetOvertimeWeekCounts(PayrollBoard, threshold);

                    Console.WriteLine();
                    if (result.Count == 0)
                    {
                        Console.WriteLine("No overtime recorded this month");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value);
                        }
                    }
                }
                else if (choice == 3)
                {
                    double avg = program.CalculateAverageMonthlyPay();
                    Console.WriteLine();
                    Console.WriteLine("Overall average monthly pay: " + avg);
                }
                else if (choice == 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Logging off — Payroll processed successfully!");
                    break;
                }
            }

        }
    }
}
