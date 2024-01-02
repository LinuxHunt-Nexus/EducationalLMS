using FluentResults;
using LearningManagement.Data.ViewModels;

namespace LearningManagement.Application.Services;

public interface IInstitutionCourseService
{
    Task<Result> CourseAddAsync(InstitutionCourseModel model);
    Task<Result<List<InstitutionCourseModel>>> CourseListAsync();
    Task<Result<InstitutionCourseModel>> CourseDetailsAsync(int institutionCourseId);
}