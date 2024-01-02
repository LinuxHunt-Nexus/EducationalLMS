namespace LearningManagement.Data.Models;

public class TeacherWiseCourseContent
{
    public int TeacherWiseCourseContentId { get; set; }
    public int TeacherWiseCourseId { get; set; }
    public TeacherWiseCourse TeacherWiseCourse { get; set; } = null!;
    public string ContentName { get; set; } = null!;
    public string? Details { get; set; }
    public string? Link { get; set; }
    public string? UploadedFileName { get; set; }
    public DateTime CreatedAtUtc { get; set; }

}