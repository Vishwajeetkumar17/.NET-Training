using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace PracticeQuestionDay40
{
    internal class CodeByLinq
    {
        static void Main()
        {
            string cs = @"Data Source=VISHWAJEET-RAJ;Initial Catalog=ItTechGenieTrainingDB;Integrated Security=True;TrustServerCertificate=True;";

            DataTable students = new DataTable();
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("SELECT StudentId, FullName, City, Marks, IsActive FROM Students", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                con.Open();
                da.Fill(students);
            }

            var rows = students.AsEnumerable();


            // Example: list active students names
            Console.WriteLine("\n=== LINQ: Active Students Names ===");
            var activeNames = rows
                .Where(r => r.Field<bool>("IsActive") == true)
                .Select(r => r.Field<string>("FullName"))
                .ToList();

            if (activeNames.Count == 0)
            {
                Console.WriteLine("No active students found.");
            }
            else
            {
                Console.WriteLine($"Total active students: {activeNames.Count}");
                activeNames.ForEach(Console.WriteLine);
            }



            // LINQ: Where + Select (Filter + Projection)
            Console.WriteLine("\n=== LINQ: Toppers (Marks >= 80) ===");
            var toppers = students.AsEnumerable()
                .Where(r => r.Field<int>("Marks") >= 80)
                .Select(r => new
                {
                    Id = r.Field<int>("StudentId"),
                    Name = r.Field<string>("FullName"),
                    Marks = r.Field<int>("Marks")
                })
                .ToList();

            if (toppers.Count == 0)
            {
                Console.WriteLine("No toppers found (Marks >= 80).");
            }
            else
            {
                Console.WriteLine($"Total toppers: {toppers.Count}");
                foreach (var s in toppers)
                    Console.WriteLine($"{s.Id} | {s.Name} | {s.Marks}");
            }


            // LINQ: OrderBy + ThenBy (Sorting)
            Console.WriteLine("\n=== LINQ: Sorted by Marks Desc, then Name ===");
            var sorted = students.AsEnumerable()
                .OrderByDescending(r => r.Field<int>("Marks"))
                .ThenBy(r => r.Field<string>("FullName"))
                .Select(r => new
                {
                    Name = r.Field<string>("FullName"),
                    Marks = r.Field<int>("Marks")
                })
                .ToList();

            if (sorted.Count == 0)
            {
                Console.WriteLine("No students to sort.");
            }
            else
            {
                Console.WriteLine($"Total students sorted: {sorted.Count}");
                foreach (var s in sorted)
                    Console.WriteLine($"{s.Name} - {s.Marks}");
            }



            // LINQ: GroupBy (Category / Bucket)
            Console.WriteLine("\n=== LINQ: Grouped by City ===");
            var byCity = students.AsEnumerable()
                .GroupBy(r => r.Field<string>("City"))
                .Select(g => new
                {
                    City = g.Key,
                    Count = g.Count(),
                    AvgMarks = (int)g.Average(x => x.Field<int>("Marks"))
                })
                .OrderByDescending(x => x.AvgMarks)
                .ToList();

            if (byCity.Count == 0)
            {
                Console.WriteLine("No city groups found.");
            }
            else
            {
                Console.WriteLine($"Total cities: {byCity.Count}");
                foreach (var g in byCity)
                    Console.WriteLine($"{g.City} | Count={g.Count} | AvgMarks={g.AvgMarks}");
            }
        }
    }
}
