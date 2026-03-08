using Microsoft.Data.SqlClient;

namespace CRUDOperation
{
    public static class StudentReader
    {
        public static void Read(string cs)
        {
            string sql = "SELECT StuId, FullName, Department, JoinYear FROM dbo.Student ORDER BY StuId";
            try
            {
                using (var con = new SqlConnection(cs))
                using (var cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\nID | Name | Dept | JoinYear");
                        Console.WriteLine("-------------------------------");
                        bool hasRows = false;
                        while (reader.Read())
                        {
                            hasRows = true;
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string dept = reader.GetString(2);
                            int joinYear = reader.GetInt32(3);
                            Console.WriteLine($"{id} | {name} | {dept} | {joinYear}");
                        }
                        if (!hasRows)
                        {
                            Console.WriteLine("No records found.");
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
