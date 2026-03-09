using LoginAndRoleBasedAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAndRoleBasedAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<StudentRecord> StudentRecords { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Role).HasConversion<string>();
            });

            modelBuilder.Entity<StudentRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(e => e.EnrollmentNumber).IsUnique();
                entity.Property(e => e.EnrollmentNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Course).WithMany().HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Staff).WithMany().HasForeignKey(e => e.StaffId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Marks).HasPrecision(5, 2);
                entity.Property(e => e.Grade).IsRequired().HasMaxLength(2);
            });

            // Seed courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Mathematics", Credits = 4, Description = "Fundamental mathematics course" },
                new Course { Id = 2, Name = "Physics", Credits = 3, Description = "Basic physics concepts" },
                new Course { Id = 3, Name = "Computer Science", Credits = 4, Description = "Introduction to CS" }
            );
        }
    }
}
