using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(e => e.CourseId);

            builder.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            builder.Property(e => e.Description)
                .IsUnicode()
                .IsRequired(false);

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.Property(e => e.EndDate)
                .IsRequired();

            builder.Property(e => e.Price)
                .IsRequired();
        }
    }
}
