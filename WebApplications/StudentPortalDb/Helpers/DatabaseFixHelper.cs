using Microsoft.EntityFrameworkCore;
using StudentPortalDb.Models;

// IMPORTANT: Run this in Program.cs Main method after app.Build() 
// to fix students with 0001-01-01 timestamps

public static class DatabaseFixHelper
{
    public static async Task FixStudentCreatedAtTimestamps(StudentPortalDbContext context)
    {
        try
        {
            // Find all students with default/invalid CreatedAt (0001-01-01)
            var invalidStudents = await context.Students
                .Where(s => s.CreatedAt.Year == 1)
                .ToListAsync();

            if (invalidStudents.Count > 0)
            {
                var now = DateTime.UtcNow;
                foreach (var student in invalidStudents)
                {
                    student.CreatedAt = now;
                }

                await context.SaveChangesAsync();
                Console.WriteLine($"Fixed {invalidStudents.Count} student records with invalid CreatedAt timestamps.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fixing student timestamps: {ex.Message}");
        }
    }
}
