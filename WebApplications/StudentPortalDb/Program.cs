using Microsoft.EntityFrameworkCore;
using StudentPortalDb.Models;
using StudentPortalDb.Repositories;
using StudentPortalDb.Services;

namespace StudentPortalDb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<StudentPortalDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            // Register repository and service
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            var app = builder.Build();

            // Initialize database and fix invalid timestamps
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<StudentPortalDbContext>();
                    context.Database.EnsureCreated();

                    // Fix students with 0001-01-01 CreatedAt timestamps
                    var invalidStudents = context.Students
                        .Where(s => s.CreatedAt.Year == 1)
                        .ToList();

                    if (invalidStudents.Count > 0)
                    {
                        var now = DateTime.UtcNow.AddMinutes(330);
                        foreach (var student in invalidStudents)
                        {
                            student.CreatedAt = now;
                        }
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while initializing the database.");
                }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Students}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
