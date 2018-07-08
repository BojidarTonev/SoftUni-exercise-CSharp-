using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configuration
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(e => e.ResourceId);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(e => e.Url)
                .IsUnicode(false);

            builder.HasOne(e => e.Course)
                .WithMany(e => e.Resources)
                .HasForeignKey(e => e.CourseId);
        }
    }
}
