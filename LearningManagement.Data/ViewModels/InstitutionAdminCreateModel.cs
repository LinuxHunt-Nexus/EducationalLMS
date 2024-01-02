using LearningManagement.Data;

namespace LearningManagement.Data.ViewModels;

public class InstitutionAdminCreateModel
{
    public int InstitutionAdminId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int InstitutionId { get; set; }
    public string ApplicationUserId { get; set; } = null!;
}