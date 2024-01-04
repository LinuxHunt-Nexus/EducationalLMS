using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagement.Data.ViewModels;

public class TeacherModel
{
    public int InstitutionTeacherId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string Gender { get; set; } = null!;
    public string? Religion { get; set; }
    public string? BloodGroup { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? JoiningDate { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    // MAHADI
    // Additional properties
    public string? NID { get; set; }//=> NID
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    
    public float? TeachingRating { get; set; }
    //public int? StudentFeedbackCount { get; set; }
    public string? MedicalConditions { get; set; }
    [Display(Name = "Health Insurance")]
    public bool HasHealthInsurance { get; set; }
    //public string? AdditionalNotes { get; set; }


    // Additional properties
    public string? TeacherAddress { get; set; }
    [Display(Name = "Degree Name")]
    public string? EducationQualification
    {
        get => EduQualification != null ? string.Join(", ", EduQualification) : null;
        set => EduQualification = value?.Split(", ").ToList();
    }
    [NotMapped]
    //[Display(Name = "Degree Name")]
    public List<string>? EduQualification { get; set; }

    [Display(Name = "ExamPass Year")]
    public string? ExamminationPassYear
    {
        get => ExamPassYear != null ? string.Join(", ", ExamPassYear) : null;
        set => ExamPassYear = value?.Split(", ").ToList();
    }

    [NotMapped]
    //[Display(Name = "Degree Year")]
    public List<string>? ExamPassYear { get; set; }

    [Display(Name = "Degree Result")]
    public string? DegreePassResult
    {
        get => DegreeResult != null ? string.Join(", ", DegreeResult) : null;
        set => DegreeResult = value?.Split(", ").ToList();
    }
    [NotMapped]
    //[Display(Name = "Degree Result")]
    public List<string>? DegreeResult { get; set; }
    public string Subjects { get; set; }
    [Display(Name = "Is Admin")]
    public bool IsAdmin { get; set; }
    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }
    public string? University { get; set; }
    public int? GraduationYear { get; set; }
    public string? PreviousInstitutions { get; set; }
    public string? YearsOfExperience { get; set; }

}