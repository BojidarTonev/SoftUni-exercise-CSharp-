using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Configuration;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }

        public StudentSystemContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuring.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());

            modelBuilder.ApplyConfiguration(new HomeworkConfiguration());

            modelBuilder.ApplyConfiguration(new ResourceConfiguration());

            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
        }
    }
}
