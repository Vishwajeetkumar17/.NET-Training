using Microsoft.Data.SqlClient;

namespace CRUDOperation
{
    public static class StudentInserter
    {
        public static void Insert(string cs)
        {
            string sqlInsert = @"INSERT INTO dbo.Student(FullName, Department, JoinYear) VALUES (@name, @dept, @joinYear)";
            try
            {
                Console.Write("Name: ");
                string name = Console.ReadLine() ?? "";
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.Write("Name cannot be empty. Enter Name: ");
                    name = Console.ReadLine() ?? "";
                }

                Console.Write("Dept: ");
                string dept = Console.ReadLine() ?? "";
                while (string.IsNullOrWhiteSpace(dept))
                {
                    Console.Write("Dept cannot be empty. Enter Dept: ");
                    dept = Console.ReadLine() ?? "";
                }

                int joinYear;
                Console.Write("Join Year: ");
                while (!int.TryParse(Console.ReadLine(), out joinYear) || joinYear < 1900 || joinYear > DateTime.Now.Year)
                {
                    Console.Write($"Enter a valid year (1900-{DateTime.Now.Year}): ");
                }

                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@dept", dept);
                cmd.Parameters.AddWithValue("@joinYear", joinYear);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine(rows == 1 ? "Inserted successfully." : "Not inserted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
