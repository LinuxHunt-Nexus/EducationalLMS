using LearningManagement.Data.Models;

namespace LearningManagement.Data.ViewModels;

public class TeacherAssignCourseModel
{
    public int InstitutionTeacherId { get; set; }
  
    public int InstitutionCourseId { get; set; }

    public int InstitutionClassId { get; set; }
}