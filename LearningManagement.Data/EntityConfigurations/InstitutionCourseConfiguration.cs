using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class InstitutionCourseConfiguration : IEntityTypeConfiguration<InstitutionCourse>
{
    public void Configure(EntityTypeBuilder<InstitutionCourse> builder)
    {
        builder.ToTable("InstitutionCourse");
        builder.HasKey(x => x.InstitutionCourseId);
        builder.Property(x => x.CourseName).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Descriptions).HasMaxLength(500);
        builder.Property(x => x.Prerequisites).HasMaxLength(500);
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");

        builder.HasOne(e => e.Institution)
            .WithMany(e => e.InstitutionCourses)
            .HasForeignKey(e => e.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}