namespace LearningManagement.Data.Models;

public class InstitutionAdmin
{
    public int InstitutionAdminId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateTime CreatedAtUtc { get; set; }
    
    public int InstitutionId { get; set; }
    public Institution Institution { get; set; } = null!;

    public string? ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }


    //MAHADI
    // Additional properties
    //public string? Email { get; set; }
    //public string? Phone { get; set; }
    //public string? Address { get; set; }

    //// Security and Access
    //public bool IsSuperAdmin { get; set; }
    ////public List<string> AssignedRoles { get; set; } = new List<string>();
    //public bool ReceiveNotifications { get; set; }
    //public string? Department { get; set; }
    //public string? Position { get; set; }
    //public string? LinkedInProfile { get; set; }
    //public string? TwitterHandle { get; set; }
    //public string? AdditionalNotes { get; set; }

}