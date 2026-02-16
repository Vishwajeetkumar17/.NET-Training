using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace PracticeQuestionDay40
{
    internal class DisconnectedArchi
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
                da.Fill(students); // ✅ Data copied into memory
            }

            // ✅ Connection is closed here, but data is available
            Console.WriteLine("Rows loaded: " + students.Rows.Count);

            foreach (DataRow row in students.Rows)
            {
                Console.WriteLine($"{row["StudentId"]} | {row["FullName"]} | {row["City"]} | {row["Marks"]}");
            }
        }
    }
}