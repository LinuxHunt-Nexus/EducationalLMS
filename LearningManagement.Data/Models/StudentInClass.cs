namespace LearningManagement.Data.Models;

public class StudentInClass
{
    public int StudentInClassId { get; set; }

    public int InstitutionId { get; set; }
    public Institution Institution { get; set; } = null!;

    public int AcademicSessionId { get; set; }
    public AcademicSession AcademicSession { get; set; } = null!;
    
    public int InstitutionStudentId { get; set; }
    public InstitutionStudent InstitutionStudent { get; set; } = null!;

    public int InstitutionClassId { get; set; }
    public InstitutionClass InstitutionClass { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }


    // MAHADI
    // Additional properties
    //public bool IsActive { get; set; }
    //public bool IsEnrolled { get; set; }
    //public string? EnrollmentStatusNotes { get; set; }
    //public bool Attendances { get; set; }
    //public int? PositionInClass { get; set; }
    //public string? AcademicPerformanceNotes { get; set; }


    public virtual ICollection<TeacherWiseStudentCourse> TeacherWiseStudentCourses { get; set; } = new HashSet<TeacherWiseStudentCourse>();
}