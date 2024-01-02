using LearningManagement.Data.ViewModels;

namespace LearningManagement.Data.Models;

public class InstitutionClass
{
    public int InstitutionClassId { get; set; }
    public string ClassName { get; set; } = null!;
    public DateTime CreatedAtUtc { get; set; }
    public int InstitutionId { get; set; }
    public Institution Institution { get; set; } = null!;
    

    // MAHADI
    // Additional properties
    //public string ClassCode { get; set; }
    //public int MaxCapacity { get; set; }
    //public string Schedule { get; set; }
    //public string? ClassRoomNumber { get; set; }
    //public string? BuildingName { get; set; }
    //public string? ClassNotes { get; set; }
    //public int? AcademicSessionId { get; set; }
    //public AcademicSession? AcademicSession { get; set; }

    public virtual ICollection<StudentInClass> StudentInClasses { get; set; } = new HashSet<StudentInClass>();
    public virtual ICollection<TeacherWiseCourse> TeacherWiseCourses { get; set; } = new HashSet<TeacherWiseCourse>();
}