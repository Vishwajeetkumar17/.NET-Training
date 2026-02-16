using Microsoft.Data.SqlClient;

namespace First
{
    public class Delete
    {
        public static void Main()
        {
            string cs = "Data Source=VISHWAJEET-RAJ;Initial Catalog=TrainingDB;Integrated Security=True;TrustServerCertificate=True;";
            string sql = @"DELETE FROM dbo.Employees WHERE EmployeeId=@id";

            Console.Write("EmployeeId to delete: "); int id = int.Parse(Console.ReadLine() ?? "0");

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            Console.WriteLine(rows == 1 ? "🗑️ Deleted" : "⚠️ Not found");
        }
    }
}
