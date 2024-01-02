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
}