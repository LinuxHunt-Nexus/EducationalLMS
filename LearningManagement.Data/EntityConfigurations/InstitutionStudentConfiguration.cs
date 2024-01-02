using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class InstitutionStudentConfiguration : IEntityTypeConfiguration<InstitutionStudent>
{
    public void Configure(EntityTypeBuilder<InstitutionStudent> builder)
    {
        builder.ToTable("InstitutionStudent");
        builder.HasKey(x => x.InstitutionStudentId);
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.FullName).HasComputedColumnSql("[FirstName] + ' ' + [LastName]", stored: true);
        builder.Property(x => x.ApplicationUserId).HasMaxLength(450);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
        builder.Property(x => x.FatherName).IsRequired().HasMaxLength(128);
        builder.Property(x => x.MotherName).IsRequired().HasMaxLength(128);
        builder.Property(x => x.ImageFileName).HasMaxLength(128);
        builder.Property(x => x.Gender).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Religion).HasMaxLength(50);
        builder.Property(x => x.BloodGroup).HasMaxLength(50);
        builder.Property(x => x.AdmissionNumber).HasMaxLength(50);


        builder.Property(e => e.BirthDate).HasColumnType("date");
        builder.Property(e => e.AdmissionDate).HasColumnType("datetime");
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");

        builder.HasOne(e => e.Institution)
            .WithMany(e => e.InstitutionStudents)
            .HasForeignKey(e => e.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ApplicationUser)
            .WithOne(e => e.InstitutionStudent)
            .HasForeignKey<InstitutionStudent>(e => e.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}