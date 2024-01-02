namespace LearningManagement.Data.ViewModels;

public class TeacherCourseViewModel
{
    public int InstitutionTeacherId { get; set; }
    public string FullName { get; set; } = null!;
    public string CourseName { get; set; } = null!;
    public string ClassName { get; set; } = null!;
    public string? ImageFileName { get; set; }
}