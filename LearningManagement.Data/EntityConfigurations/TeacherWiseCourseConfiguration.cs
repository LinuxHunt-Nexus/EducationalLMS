using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class TeacherWiseCourseConfiguration : IEntityTypeConfiguration<TeacherWiseCourse>
{
    public void Configure(EntityTypeBuilder<TeacherWiseCourse> builder)
    {
        builder.ToTable("TeacherWiseCourse");

        builder.HasKey(t => t.TeacherWiseCourseId);
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");

        builder.HasOne(e => e.Institution)
            .WithMany(e => e.TeacherWiseCourses)
            .HasForeignKey(e => e.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.InstitutionTeacher)
            .WithMany(e => e.TeacherWiseCourses)
            .HasForeignKey(e => e.InstitutionTeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.InstitutionCourse)
            .WithMany(e => e.TeacherWiseCourses)
            .HasForeignKey(e => e.InstitutionCourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.InstitutionClass)
            .WithMany(e => e.TeacherWiseCourses)
            .HasForeignKey(e => e.InstitutionClassId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}