using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningManagement.Data.EntityConfigurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(e => e.UserType)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();
        builder.Property(e => e.RefreshToken).HasMaxLength(128);

        builder.HasOne(x => x.Institution)
            .WithMany(x => x.ApplicationUsers)
            .HasForeignKey(x => x.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}