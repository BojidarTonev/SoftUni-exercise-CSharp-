using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;

namespace StudentSystem.Data.Configurations
{
    public class ResourseConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(e => e.ResourceId);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            builder.Property(e => e.Url)
                .IsRequired()
                .IsUnicode(false);

            builder.HasOne(e => e.Course)
                .WithMany(e => e.Resources)
                .HasForeignKey(e => e.CoursedId);
        }
    }
}
