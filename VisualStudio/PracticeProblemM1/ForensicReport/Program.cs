using System;
using System.Collections.Generic;
namespace ReportGenerator
{
    class ForensicReport
    {
        public Dictionary<string, DateOnly> reportMap = new Dictionary<string, DateOnly>();
        public void AddReportDetails(string reportingOfficerName, DateOnly reportFiledDate)
        {
            reportMap[reportingOfficerName] = reportFiledDate;
        }
        public List<string> GetOfficersWhoFiledReportsOnDate(DateOnly reportFiledDate)
        {
            List<string> result = new List<string>();
            foreach (var x in reportMap)
            {
                if (x.Value == reportFiledDate)
                    result.Add(x.Key);
            }
            return result;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            ForensicReport FR = new ForensicReport();
            Console.WriteLine("Enter number of reports to be added");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Forensic reports (Reporting Officer: Report Filed Date)");
            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                string[] parts = str.Split(':');
                FR.AddReportDetails(parts[0], DateOnly.Parse(parts[1]));
            }
            Console.WriteLine("Enter the filed date to identify the reporting officers");
            DateOnly XDate = DateOnly.Parse(Console.ReadLine());
            List<string> ans = FR.GetOfficersWhoFiledReportsOnDate(XDate);
            if (ans.Count == 0)
                Console.WriteLine("No reporting officer filed the report");
            else
            {
                Console.WriteLine($"Reports filed on the {XDate} are by");
                foreach (var person in ans)
                    Console.WriteLine(person);
            }
        }
    }
}