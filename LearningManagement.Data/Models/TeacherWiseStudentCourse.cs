namespace LearningManagement.Data.Models;

public class TeacherWiseStudentCourse
{
    public int TeacherWiseStudentCourseId { get; set; }

    public int InstitutionId { get; set; }
    public Institution Institution { get; set; } = null!;
   
    public int TeacherWiseCourseId { get; set; }
    public TeacherWiseCourse TeacherWiseCourse { get; set; } = null!;
   
    public int StudentInClassId { get; set; }
    public StudentInClass StudentInClass { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

}