using Microsoft.Data.SqlClient;

namespace First
{
    public class Update
    {
        static void Main()
        {

            string cs = "Data Source=VISHWAJEET-RAJ;Initial Catalog=TrainingDB;Integrated Security=True;TrustServerCertificate=True;";
            string sql = @"UPDATE dbo.Employees SET FullName=@name Department=@dept Salary=@salary WHERE EmployeeId=@id";

            Console.Write("Employee Id: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Employee Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Employee Dept: ");
            string dept = Console.ReadLine() ?? "";
            Console.Write("New Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@dept", dept);
            cmd.Parameters.AddWithValue("@salary", salary);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            con.Close();

            Console.WriteLine($"Updated rows: {rows}");
        }
    }
}
