using LearningManagement.Data.Models;

namespace LearningManagement.Data;

public class Institution
{
    public int InstitutionId { get; set; }
    public string? InstitutionName { get; set; }
    public string? InstitutionLogoName { get; set; }
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? BrandingTagLine { get; set; }
    public string? Address { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public virtual ICollection<AcademicSession> AcademicSessions { get; set; } = new HashSet<AcademicSession>();
    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; } = new HashSet<ApplicationUser>();
    public virtual ICollection<InstitutionAdmin> InstitutionAdmins { get; set; } = new HashSet<InstitutionAdmin>();
    public virtual ICollection<InstitutionTeacher> InstitutionTeachers { get; set; } = new HashSet<InstitutionTeacher>();
    public virtual ICollection<InstitutionStudent> InstitutionStudents { get; set; } = new HashSet<InstitutionStudent>();
    public virtual ICollection<InstitutionClass> InstitutionClasses { get; set; } = new HashSet<InstitutionClass>();
    public virtual ICollection<InstitutionCourse> InstitutionCourses { get; set; } = new HashSet<InstitutionCourse>();
    public virtual ICollection<StudentInClass>  StudentInClasses { get; set; } = new HashSet<StudentInClass>();
    public virtual ICollection<TeacherWiseCourse>  TeacherWiseCourses { get; set; } = new HashSet<TeacherWiseCourse>();
    public virtual ICollection<TeacherWiseStudentCourse>  TeacherWiseStudentCourses { get; set; } = new HashSet<TeacherWiseStudentCourse>();

    // MAHADI
    // Additional properties
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