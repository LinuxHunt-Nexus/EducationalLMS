using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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


    // MAHADI
    // Additional properties
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FoundedDate { get; set; }
    public string? Founder { get; set; }
    public string? MissionStatement { get; set; }
    public string? VisionStatement { get; set; }
    public string? Accreditation { get; set; }
    public string? Affiliation { get; set; }
    public int? TotalStudents { get; set; }
    public int? TotalTeachers { get; set; }
    public int? TotalCourses { get; set; }
    public string? CampusFacilities { get; set; }
    public string? SocialMediaLinks { get; set; }
    public string? AdmissionProcedure { get; set; }
    public string? PrincipalName { get; set; }
    public string? PrincipalEmail { get; set; }
    public string? PrincipalPhone { get; set; }
}