using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class TeacherWiseCourseContentConfiguration : IEntityTypeConfiguration<TeacherWiseCourseContent>
{
    public void Configure(EntityTypeBuilder<TeacherWiseCourseContent> builder)
    {
        builder.ToTable("TeacherWiseCourseContent");
        builder.HasKey(x => x.TeacherWiseCourseContentId);
        builder.Property(x => x.ContentName).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Details).HasMaxLength(500);
        builder.Property(x => x.Link).HasMaxLength(128);
        builder.Property(x => x.UploadedFileName).HasMaxLength(128);
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");

        builder.HasOne(e => e.TeacherWiseCourse)
            .WithMany(e => e.Contents)
            .HasForeignKey(e => e.TeacherWiseCourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}