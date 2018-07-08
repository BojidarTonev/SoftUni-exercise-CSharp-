using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configuration
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
                .IsUnicode(false)
                .IsRequired(false)
                .HasColumnType("CHAR(10)");

            builder.Property(e => e.RegisteredOn)
                .IsRequired();

            builder.Property(e => e.BirthDay)
                .IsRequired(false);
        }
    }
}
