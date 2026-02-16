using Microsoft.Data.SqlClient;

namespace First
{
    class Program
    {
        static void Main()
        {
            string cs = "Data Source=VISHWAJEET-RAJ;Initial Catalog=TrainingDB;Integrated Security=True;TrustServerCertificate=True;";
            string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees ORDER BY EmployeeId";

            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string dept = reader.GetString(2);
                        decimal salary = reader.GetDecimal(3);

                        Console.WriteLine($"{id} | {name} | {dept} | {salary}");
                    }
                }

                con.Close();
            }
        }
    }
}
