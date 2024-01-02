using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class InstitutionClassConfiguration : IEntityTypeConfiguration<InstitutionClass>
{
    public void Configure(EntityTypeBuilder<InstitutionClass> builder)
    {
        builder.ToTable("InstitutionClass");
        builder.HasKey(x => x.InstitutionClassId);
        builder.Property(x => x.ClassName).IsRequired().HasMaxLength(128);
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");

        builder.HasOne(e => e.Institution)
            .WithMany(e => e.InstitutionClasses)
            .HasForeignKey(e => e.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);



    }
}