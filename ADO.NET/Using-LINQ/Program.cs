using Microsoft.Data.SqlClient;

namespace PracticeQuestionDay40
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cs = @"Data Source=VISHWAJEET-RAJ;Initial Catalog=ItTechGenieTrainingDB;Integrated Security=True;TrustServerCertificate=True;";

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand("SELECT StudentId, FullName, City, Marks FROM Students WHERE IsActive = 1", con);

            con.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string city = reader.GetString(2);
                int marks = reader.GetInt32(3);

                Console.WriteLine($"{id} | {name} | {city} | {marks}");
            }
        }
    }
}
