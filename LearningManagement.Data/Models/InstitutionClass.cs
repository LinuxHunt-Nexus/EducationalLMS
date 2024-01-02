namespace LearningManagement.Data.Models;

public class InstitutionClass
{
    public int InstitutionClassId { get; set; }
    public string ClassName { get; set; } = null!;
    public DateTime CreatedAtUtc { get; set; }
    
    public int InstitutionId { get; set; }
    public Institution Institution { get; set; } = null!;
    public virtual ICollection<StudentInClass> StudentInClasses { get; set; } = new HashSet<StudentInClass>();
    public virtual ICollection<TeacherWiseCourse> TeacherWiseCourses { get; set; } = new HashSet<TeacherWiseCourse>();
}