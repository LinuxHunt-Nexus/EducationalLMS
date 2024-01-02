using FluentResults;
using LearningManagement.Data.ViewModels;

namespace LearningManagement.Application.Services;

public interface IAuthService
{
    Task<Result> SignUpAsync(SignUpModel model);
    Task<Result> AddTeacherWithSignUpAsync(TeacherModel model);
    Task<Result> AddStudentWithSignUpAsync(StudentModel model);
    Task<Result<AdminViewModel>> InstitutionAdminInfoAsync();
    Task<Result<AdminViewModel>> UpdateInstitutionAdminInfoAsync(AdminViewModel model);
}