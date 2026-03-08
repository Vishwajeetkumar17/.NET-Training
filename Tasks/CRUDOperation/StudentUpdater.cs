using Microsoft.Data.SqlClient;

namespace CRUDOperation
{
    public static class StudentUpdater
    {
        public static void Update(string cs)
        {
            try
            {
                int id;
                Console.Write("Enter Student Id to update: ");
                while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                {
                    Console.Write("Enter a valid positive integer for Student Id: ");
                }

                // Fetch current values
                string selectSql = "SELECT FullName, Department, JoinYear FROM dbo.Student WHERE StuId=@id";
                using var con = new SqlConnection(cs);
                using var selectCmd = new SqlCommand(selectSql, con);
                selectCmd.Parameters.AddWithValue("@id", id);
                con.Open();
                string? currentName = null, currentDept = null;
                int? currentJoinYear = null;
                using (var reader = selectCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        currentName = reader.GetString(0);
                        currentDept = reader.GetString(1);
                        currentJoinYear = reader.GetInt32(2);
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                        return;
                    }
                }
                con.Close();

                Console.WriteLine($"Current Name: {currentName}");
                Console.WriteLine($"Current Dept: {currentDept}");
                Console.WriteLine($"Current Join Year: {currentJoinYear}");

                // Ask which fields to update
                Console.Write("Update Name? (y/n): ");
                bool updateName = Console.ReadLine()?.Trim().ToLower() == "y";
                string? newName = currentName;
                if (updateName)
                {
                    Console.Write("Enter new Name: ");
                    newName = Console.ReadLine() ?? currentName;
                    while (string.IsNullOrWhiteSpace(newName))
                    {
                        Console.Write("Name cannot be empty. Enter new Name: ");
                        newName = Console.ReadLine() ?? currentName;
                    }
                }

                Console.Write("Update Dept? (y/n): ");
                bool updateDept = Console.ReadLine()?.Trim().ToLower() == "y";
                string? newDept = currentDept;
                if (updateDept)
                {
                    Console.Write("Enter new Dept: ");
                    newDept = Console.ReadLine() ?? currentDept;
                    while (string.IsNullOrWhiteSpace(newDept))
                    {
                        Console.Write("Dept cannot be empty. Enter new Dept: ");
                        newDept = Console.ReadLine() ?? currentDept;
                    }
                }

                Console.Write("Update Join Year? (y/n): ");
                bool updateJoinYear = Console.ReadLine()?.Trim().ToLower() == "y";
                int newJoinYear = currentJoinYear ?? 0;
                if (updateJoinYear)
                {
                    Console.Write("Enter new Join Year: ");
                    while (!int.TryParse(Console.ReadLine(), out newJoinYear) || newJoinYear < 1900 || newJoinYear > DateTime.Now.Year)
                    {
                        Console.Write($"Enter a valid year (1900-{DateTime.Now.Year}): ");
                    }
                }

                // Build update SQL dynamically
                var updates = new List<string>();
                if (updateName) updates.Add("FullName=@name");
                if (updateDept) updates.Add("Department=@dept");
                if (updateJoinYear) updates.Add("JoinYear=@joinYear");
                if (updates.Count == 0)
                {
                    Console.WriteLine("No fields selected for update.");
                    return;
                }
                string updateSql = $"UPDATE dbo.Student SET {string.Join(", ", updates)} WHERE StuId=@id";
                using var updateCmd = new SqlCommand(updateSql, con);
                updateCmd.Parameters.AddWithValue("@id", id);
                if (updateName) updateCmd.Parameters.AddWithValue("@name", newName);
                if (updateDept) updateCmd.Parameters.AddWithValue("@dept", newDept);
                if (updateJoinYear) updateCmd.Parameters.AddWithValue("@joinYear", newJoinYear);
                con.Open();
                int rows = updateCmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine(rows == 1 ? "Updated successfully." : "Update failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
