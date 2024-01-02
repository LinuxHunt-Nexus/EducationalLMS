using FluentResults;
using LearningManagement.Application.Repository;
using LearningManagement.Data;
using LearningManagement.Data.Models;
using LearningManagement.Data.ViewModels;
using Microsoft.AspNetCore.Http;

namespace LearningManagement.Application.Services;

public class TeacherService :ITeacherService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IApplicationUserRepository _applicationUserRepository;

    public TeacherService(IHttpContextAccessor httpContextAccessor, ITeacherRepository teacherRepository, IApplicationUserRepository applicationUserRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _teacherRepository = teacherRepository;
        _applicationUserRepository = applicationUserRepository;
    }

    public async Task<Result<List<TeacherModel>>> TeacherListAsync()
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _teacherRepository.TeacherListAsync(institutionId.Value);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<TeacherCourseViewModel>>> TeacherAssignCourseListAsync()
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _teacherRepository.TeacherAssignCourseListAsync(institutionId.Value);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<TeacherModel>> TeacherDetailsAsync(int teacherId)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _teacherRepository.TeacherDetailsAsync(institutionId.Value, teacherId);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> TeacherAssignCourseAsync(TeacherAssignCourseModel model)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _teacherRepository.TeacherAssignCourseAsync(institutionId.Value, model);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }
}