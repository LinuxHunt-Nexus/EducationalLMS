using LearningManagement.Data.Enums;
using LearningManagement.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Data.Seeder;

public static class UserSeeder
{
    public static Dictionary<string, string> Ids { get; set; } = new()
        {
            { UserType.AppAdmin.ToString(), "fb76a482-3d73-4e28-9155-581a1a2cbea4" },
        };

    public static void SeedRoleData(this ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            Ids.Select(i =>
                new IdentityRole
                {
                    Id = i.Value,
                    Name = i.Key,
                    NormalizedName = i.Key.ToUpper(),
                    ConcurrencyStamp = i.Value
                }).ToArray()
        );
    }
    public static void SeedSuperAdminData(this ModelBuilder builder)
    {
        var authorityId = "A0456563-F978-4135-B563-97F23EA02FDA";
        // any guid, but nothing is against to use the same one

        var user = new ApplicationUser
        {
            Id = authorityId,
            UserName = UserType.AppAdmin.ToString(),
            NormalizedUserName = UserType.AppAdmin.ToString().ToUpper(),
            Email = "Admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            LockoutEnabled = true,
            ConcurrencyStamp = authorityId, 
            UserType = UserType.AppAdmin
        };

        var passwordHasher = new PasswordHasher<ApplicationUser>();
        user.PasswordHash = passwordHasher.HashPassword(user, "Admin_123");

        builder.Entity<ApplicationUser>().HasData(user);

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = Ids[UserType.AppAdmin.ToString()],
            UserId = authorityId
        });
    }
}