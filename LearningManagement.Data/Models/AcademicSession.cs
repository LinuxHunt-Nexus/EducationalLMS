namespace LearningManagement.Data.Models;

public class AcademicSession
{
    public int AcademicSessionId { get; set; }
    public int InstitutionId { get; set; }
    public string SessionName { get; set; } = null!;
    public string? SessionDescription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedAtUtc { get; set; }

    public Institution Institution { get; set; } = null!;

    public virtual ICollection<StudentInClass> StudentInClasses { get; set; } = new HashSet<StudentInClass>();

    // MAHADI
    // Additional properties
    public bool IsActive { get; set; }
    public string? AcademicCalendar { get; set; }
    public virtual ICollection<InstitutionClass> OfferedClasses { get; set; } = new HashSet<InstitutionClass>();  // List of classes offered during the academic session.
    public virtual ICollection<InstitutionCourse> OfferedCourses { get; set; } = new HashSet<InstitutionCourse>();  // List of courses offered during the academic session.
    public string? SessionDirector { get; set; }
    public DateTime? SessionTime { get; set; }
    public int? TotalStudentsEnrolled { get; set; }
    public decimal? AverageStudentAttendance { get; set; }
    public decimal? AverageStudentPerformance { get; set; }
    public string? Achievements { get; set; }
    public string? ChallengesFaced { get; set; }
    public string? FutureGoals { get; set; }
}