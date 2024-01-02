using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
{
    public void Configure(EntityTypeBuilder<Institution> builder)
    {
        builder.ToTable("Institution");
        builder.HasKey(x => x.InstitutionId);
        builder.Property(x => x.InstitutionName).IsRequired().HasMaxLength(128);
        builder.Property(x => x.InstitutionLogoName).HasMaxLength(128);
        builder.Property(x => x.ContactNumber).HasMaxLength(50);
        builder.Property(x => x.Email).HasMaxLength(50);
        builder.Property(x => x.Website).HasMaxLength(50);
        builder.Property(x => x.BrandingTagLine).HasMaxLength(256);
        builder.Property(x => x.Address).HasMaxLength(512);
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");


    }
}