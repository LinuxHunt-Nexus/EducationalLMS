namespace LearningManagement.Data.Models;

public class TeacherWiseCourse
{
    public int TeacherWiseCourseId { get; set; }

    public int InstitutionId { get; set; }
    public Institution Institution { get; set; } = null!;

    public int InstitutionTeacherId { get; set; }
    public InstitutionTeacher InstitutionTeacher { get; set; } = null!;

    public int InstitutionCourseId { get; set; }
    public InstitutionCourse InstitutionCourse { get; set; } = null!;

    public int InstitutionClassId { get; set; }
    public InstitutionClass InstitutionClass { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    public virtual ICollection<TeacherWiseCourseContent> Contents { get; set; } = new HashSet<TeacherWiseCourseContent>();
    public virtual ICollection<TeacherWiseStudentCourse> TeacherWiseStudentCourses { get; set; } = new HashSet<TeacherWiseStudentCourse>();
}