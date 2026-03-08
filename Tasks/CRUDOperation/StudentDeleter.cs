using Microsoft.Data.SqlClient;

namespace CRUDOperation
{
    public static class StudentDeleter
    {
        public static void Delete(string cs)
        {
            string sql = @"DELETE FROM dbo.Student WHERE StuId=@id";
            try
            {
                int id;
                Console.Write("StuId to delete: ");
                while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                {
                    Console.Write("Enter a valid positive integer for StuId: ");
                }
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine(rows == 1 ? "Deleted successfully." : "Not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
