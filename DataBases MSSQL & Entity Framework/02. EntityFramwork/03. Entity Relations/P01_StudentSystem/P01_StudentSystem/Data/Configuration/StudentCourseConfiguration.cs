using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configuration
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(e => new
            {
                e.CourseId,
                e.StudentId
            });

            builder.HasOne(e => e.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.StudentId);

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(e => e.CourseId);
        }
    }
}
