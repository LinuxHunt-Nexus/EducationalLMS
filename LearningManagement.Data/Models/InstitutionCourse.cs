namespace LearningManagement.Data.Models;

public class InstitutionCourse
{
    public int InstitutionCourseId { get; set; }
    public int InstitutionId { get; set; }
    public string CourseName { get; set; } = null!;
    public string? Descriptions { get; set; }
    public string? Prerequisites { get; set; }
    public DateTime CreatedAtUtc { get; set; }

    public Institution Institution { get; set; } = null!;

    public virtual ICollection<TeacherWiseCourse> TeacherWiseCourses { get; set; } = new HashSet<TeacherWiseCourse>();
}