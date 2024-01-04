using LearningManagement.Data.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagement.Data.Models;

public class InstitutionTeacher
{
    public int InstitutionTeacherId { get; set; }
    public int InstitutionId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public string Gender { get; set; } = null!;
    public string? Religion { get; set; }
    public string? BloodGroup { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? JoiningDate { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public Institution Institution { get; set; } = null!;

    public string? ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }


    // MAHADI
    // Additional properties
    public string? NID { get; set; }//=> NID
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }

    public float? TeachingRating { get; set; }
    //public int? StudentFeedbackCount { get; set; }
    public string? MedicalConditions { get; set; }
    public bool HasHealthInsurance { get; set; }
    //public string? AdditionalNotes { get; set; }


    // Additional properties
    public string? TeacherAddress { get; set; }
    [Display(Name = "Degree Name")]   //"Degree Name, Year, Result"
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

    [Display(Name = "Institution Name")]
    public string? InstitutionSet
    {
        get => InstitutionName != null ? string.Join(", ", InstitutionName) : null;
        set => InstitutionName = value?.Split(", ").ToList();
    }
    [NotMapped]
    public List<string>? InstitutionName { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsActive { get; set; }
    public string? University { get; set; }
    public int? GraduationYear { get; set; }
    public string? PreviousInstitutions { get; set; }
    [Display(Name = "Organization Name")]
    public string? OrganizationSet
    {
        get => Organization != null ? string.Join(", ", Organization) : null;
        set => Organization = value?.Split(", ").ToList();
    }
    [NotMapped]
    public List<string>? Organization { get; set; }

    [Display(Name = "Designation")]
    public string? DesignationSet
    {
        get => Designation != null ? string.Join(", ", Designation) : null;
        set => Designation = value?.Split(", ").ToList();
    }
    [NotMapped]
    public List<string>? Designation { get; set; }
    [Display(Name = "Form To")]
    public string? FormToYearSet
    {
        get => FormToYear != null ? string.Join(", ", FormToYear) : null;
        set => FormToYear = value?.Split(", ").ToList();
    }
    [NotMapped]
    public List<string>? FormToYear { get; set; }







    public virtual ICollection<TeacherWiseCourse> TeacherWiseCourses { get; set; } = new HashSet<TeacherWiseCourse>();
}