using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;

namespace StudentSystem.Data.Configurations
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

            builder.Property(c => c.StartDate)
                .IsRequired();

            builder.Property(c => c.EndDate)
                .IsRequired();

            builder.Property(c => c.Price)
                .IsRequired();
        }
    }
}
