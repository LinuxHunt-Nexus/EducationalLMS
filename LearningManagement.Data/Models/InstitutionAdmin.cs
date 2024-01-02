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

}