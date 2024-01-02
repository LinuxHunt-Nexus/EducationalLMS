using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class AcademicSessionConfiguration : IEntityTypeConfiguration<AcademicSession>
{
    public void Configure(EntityTypeBuilder<AcademicSession> builder)
    {
        builder.ToTable("AcademicSession");
        builder.HasKey(e => e.AcademicSessionId);
        builder.Property(e => e.SessionName).IsRequired().HasMaxLength(256);
        builder.Property(e => e.SessionDescription).HasMaxLength(500);
        builder.Property(e => e.StartDate).HasColumnType("date");
        builder.Property(e => e.EndDate).HasColumnType("date");
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");

        builder.HasOne(e=> e.Institution)
            .WithMany(e=> e.AcademicSessions)
            .HasForeignKey(e=> e.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);


    }
}