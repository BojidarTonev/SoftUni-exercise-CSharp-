using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configuration
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(e => e.HomeworkId);

            builder.Property(e => e.Content)
                .IsUnicode(false);

            builder.HasOne(e => e.Student)
                .WithMany(s => s.Homeworks)
                .HasForeignKey(c => c.StudentId);

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Homeworks)
                .HasForeignKey(e => e.CourseId);
        }
    }
}
