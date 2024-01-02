using FluentResults;
using LearningManagement.Data.ViewModels;

namespace LearningManagement.Application.Services;

public interface ITeacherService
{
    Task<Result<List<TeacherModel>>> TeacherListAsync();
    Task<Result<List<TeacherCourseViewModel>>> TeacherAssignCourseListAsync();
    Task<Result<TeacherModel>> TeacherDetailsAsync(int teacherId);
    Task<Result> TeacherAssignCourseAsync(TeacherAssignCourseModel model);
}