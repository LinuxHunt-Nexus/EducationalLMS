namespace LearningManagement.Data.ViewModels;

public class InstitutionCourseModel
{
    public int InstitutionCourseId { get; set; }
    public string CourseName { get; set; } = null!;
    public string? Descriptions { get; set; }
    public string? Prerequisites { get; set; }
}