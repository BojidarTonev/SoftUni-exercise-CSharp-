using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;

namespace StudentSystem.Data.Configurations
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(e => e.HomeworkId);

            builder.Property(e => e.Content)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(h => h.SubmissionTime)
                .IsRequired();

            builder.HasOne(e => e.Course)
                .WithMany(e => e.Homewroks)
                .HasForeignKey(e => e.CourseId);

            builder.HasOne(e => e.Course)
                .WithMany(e => e.Homewroks)
                .HasForeignKey(e => e.CourseId);
        }
    }
}
