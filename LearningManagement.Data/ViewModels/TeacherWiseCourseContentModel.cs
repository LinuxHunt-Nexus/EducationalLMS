using LearningManagement.Data.Models;

namespace LearningManagement.Data.ViewModels;

public class TeacherWiseCourseContentModel
{
    public int TeacherWiseCourseContentId { get; set; }
    public int TeacherWiseCourseId { get; set; }
    public string ContentName { get; set; } = null!;
    public string? Details { get; set; }
    public string? Link { get; set; }
    public string? UploadedFileName { get; set; }
}