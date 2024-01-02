using LearningManagement.Data.Models;

namespace LearningManagement.Data.ViewModels;

public class TeacherAssignCourseModel
{
    public int InstitutionTeacherId { get; set; }
  
    public int InstitutionCourseId { get; set; }

    public int InstitutionClassId { get; set; }


    // MAHADI
    // Additional properties
    public DateTime AssignmentDate { get; set; }
    public string AssignedBy { get; set; }
    public bool IsPrimary { get; set; }
    public int TeachingHours { get; set; }
    public string? Comments { get; set; }
}