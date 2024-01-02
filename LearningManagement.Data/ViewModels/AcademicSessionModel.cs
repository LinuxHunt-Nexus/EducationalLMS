namespace LearningManagement.Data.ViewModels;

public class AcademicSessionModel
{
    public int AcademicSessionId { get; set; }
    public string SessionName { get; set; } = null!;
    public string? SessionDescription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}