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

    // MAHADI
    // Additional properties
    //public bool IsActive { get; set; }
    //public string? Founder { get; set; }
    //public string? Accreditation { get; set; }
    //public int? ContactPersonId { get; set; }
    //public ContactPerson ContactPerson { get; set; }


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
}