using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class InstitutionAdminConfiguration : IEntityTypeConfiguration<InstitutionAdmin>
{
    public void Configure(EntityTypeBuilder<InstitutionAdmin> builder)
    {
        builder.ToTable("InstitutionAdmin");
        builder.HasKey(x => x.InstitutionAdminId);
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.FullName).HasComputedColumnSql("[FirstName] + ' ' + [LastName]", stored: true);
        builder.Property(x => x.ApplicationUserId).HasMaxLength(450);
        builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");

        builder.HasOne(e => e.Institution)
            .WithMany(e => e.InstitutionAdmins)
            .HasForeignKey(e => e.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ApplicationUser)
            .WithOne(e => e.InstitutionAdmin)
            .HasForeignKey<InstitutionAdmin>(e => e.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}