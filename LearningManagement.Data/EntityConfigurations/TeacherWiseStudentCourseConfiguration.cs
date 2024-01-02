using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class TeacherWiseStudentCourseConfiguration : IEntityTypeConfiguration<TeacherWiseStudentCourse>
{
    public void Configure(EntityTypeBuilder<TeacherWiseStudentCourse> builder)
    {
        builder.ToTable("TeacherWiseStudentCourse");
        builder.HasKey(x => x.TeacherWiseStudentCourseId);
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");

        builder.HasOne(e => e.Institution)
            .WithMany(e => e.TeacherWiseStudentCourses)
            .HasForeignKey(e => e.InstitutionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.TeacherWiseCourse)
            .WithMany(e => e.TeacherWiseStudentCourses)
            .HasForeignKey(e => e.TeacherWiseCourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.StudentInClass)
            .WithMany(e => e.TeacherWiseStudentCourses)
            .HasForeignKey(e => e.StudentInClassId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}