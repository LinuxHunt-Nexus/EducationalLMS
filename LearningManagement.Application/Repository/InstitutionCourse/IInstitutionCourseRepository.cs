using FluentResults;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data.Models;

namespace LearningManagement.Application.Repository;

public interface IInstitutionCourseRepository:IBaseRepository<InstitutionCourse>
{
    Task<Result> CourseAddAsync(int institutionId, InstitutionCourseModel model);
    Task<Result<List<InstitutionCourseModel>>> CourseListAsync(int institutionId);
    Task<Result<InstitutionCourseModel>> CourseDetailsAsync(int institutionId, int institutionCourseId);
    Task<bool> IsCourseNameExistAsync(int institutionId, string name);
}