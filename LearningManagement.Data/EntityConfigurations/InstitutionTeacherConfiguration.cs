using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class InstitutionTeacherConfiguration : IEntityTypeConfiguration<InstitutionTeacher>
{
    public void Configure(EntityTypeBuilder<InstitutionTeacher> builder)
    {

        builder.ToTable("InstitutionTeacher");
        builder.HasKey(x => x.InstitutionTeacherId);
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.FullName).HasComputedColumnSql("[FirstName] + ' ' + [LastName]", stored: true);
        builder.Property(x => x.ApplicationUserId).HasMaxLength(450);
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
        
        builder.Property(x => x.ImageFileName).HasMaxLength(128);
        builder.Property(x => x.Gender).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Religion).HasMaxLength(50);
        builder.Property(x => x.BloodGroup).HasMaxLength(50);

        builder.Property(e => e.BirthDate).HasColumnType("date");
        builder.Property(e => e.JoiningDate).HasColumnType("date");
        builder.HasOne(e => e.Institution)
            .WithMany(e => e.InstitutionTeachers)
            .HasForeignKey(e => e.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ApplicationUser)
            .WithOne(e => e.InstitutionTeacher)
            .HasForeignKey<InstitutionTeacher>(e => e.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}