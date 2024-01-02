using FluentResults;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data.Models;

namespace LearningManagement.Application.Repository;

public interface ITeacherRepository:IBaseRepository<InstitutionTeacher>
{
    Task<Result> TeacherAddAsync(int institutionId,string applicationUserId, TeacherModel model);
    Task<Result> TeacherAssignCourseAsync(int institutionId, TeacherAssignCourseModel model);
    Task<Result<List<TeacherModel>>> TeacherListAsync(int institutionId);
    Task<Result<List<TeacherCourseViewModel>>> TeacherAssignCourseListAsync(int institutionId);
    Task<Result<TeacherModel>> TeacherDetailsAsync(int institutionId, int teacherId);
    Task<bool> IsTeacherEmailExistAsync(int institutionId, string email);
}