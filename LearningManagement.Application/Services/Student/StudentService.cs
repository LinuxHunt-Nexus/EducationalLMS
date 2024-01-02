using FluentResults;
using LearningManagement.Application.Repository;
using LearningManagement.Data.ViewModels;
using Microsoft.AspNetCore.Http;

namespace LearningManagement.Application.Services;

public class StudentService :IStudentService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IStudentRepository _studentRepository;
    private readonly IApplicationUserRepository _applicationUserRepository;

    public StudentService(IHttpContextAccessor httpContextAccessor, IStudentRepository studentRepository, IApplicationUserRepository applicationUserRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _studentRepository = studentRepository;
        _applicationUserRepository = applicationUserRepository;
    }

    public async Task<Result<List<StudentViewModel>>> StudentListAsync()
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _studentRepository.StudentListAsync(institutionId.Value);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<StudentModel>> StudentDetailsAsync(int studentId)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _studentRepository.StudentDetailsAsync(institutionId.Value, studentId);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }
}