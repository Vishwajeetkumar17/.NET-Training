using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeQuestionDay40
{
    internal class ParameterizedQueries
    {
        static void Main()
        {
            string cs = @"Data Source=VISHWAJEET-RAJ;Initial Catalog=ItTechGenieTrainingDB;Integrated Security=True;TrustServerCertificate=True;";


            string city = "Chennai";

            // Fill students DataTable from DB
            DataTable students = new DataTable();
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("SELECT StudentId, FullName, City, Marks, IsActive FROM Students", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                con.Open();
                da.Fill(students);
            }

            // Parameterized query example
            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("SELECT StudentId, FullName, City, Marks FROM Students WHERE City = @City", con))
            {
                cmd.Parameters.AddWithValue("@City", city);
                con.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["FullName"]);
                }
            }
        }
    }
}
