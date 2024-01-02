using System.ComponentModel.DataAnnotations;

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
    [Display(Name = "Degree Name, Year, Result")]
    public string? EduQualification { get; set; }
    public string Subjects { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsActive { get; set; }
    public string? University { get; set; }
    public int? GraduationYear { get; set; }
    public string? PreviousInstitutions { get; set; }
    public string? YearsOfExperience { get; set; }







    public virtual ICollection<TeacherWiseCourse> TeacherWiseCourses { get; set; } = new HashSet<TeacherWiseCourse>();
}