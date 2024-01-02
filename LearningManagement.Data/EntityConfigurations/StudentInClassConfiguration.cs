using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class StudentInClassConfiguration : IEntityTypeConfiguration<StudentInClass>
{
    public void Configure(EntityTypeBuilder<StudentInClass> builder)
    {
        builder.ToTable("StudentInClass");
        builder.HasKey(t => t.StudentInClassId);
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");

        builder.HasOne(e => e.Institution)
            .WithMany(e => e.StudentInClasses)
            .HasForeignKey(e => e.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AcademicSession)
            .WithMany(e => e.StudentInClasses)
            .HasForeignKey(e => e.AcademicSessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.InstitutionStudent)
            .WithMany(e => e.StudentInClasses)
            .HasForeignKey(e => e.InstitutionStudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.InstitutionClass)
            .WithMany(e => e.StudentInClasses)
            .HasForeignKey(e => e.InstitutionClassId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}