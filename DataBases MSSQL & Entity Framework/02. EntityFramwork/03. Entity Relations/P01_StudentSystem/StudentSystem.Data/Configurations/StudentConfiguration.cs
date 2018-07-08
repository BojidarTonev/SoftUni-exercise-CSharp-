using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;

namespace StudentSystem.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(e => e.StudentId);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder.Property(e => e.PhoneNumber)
                .IsRequired(false)
                .HasColumnType("CHAR(10)")
                .IsUnicode(false);
        }
    }
}
