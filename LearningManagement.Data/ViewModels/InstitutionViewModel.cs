using Microsoft.AspNetCore.Http;

namespace LearningManagement.Data.ViewModels;

public class InstitutionViewModel
{
    public int InstitutionId { get; set; }
    public string? InstitutionName { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? InstitutionLogoName { get; set; }
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? BrandingTagLine { get; set; }
    public string? Address { get; set; }
}