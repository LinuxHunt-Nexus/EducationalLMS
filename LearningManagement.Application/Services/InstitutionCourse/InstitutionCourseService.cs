using FluentResults;
using LearningManagement.Application.Repository;
using LearningManagement.Data.ViewModels;
using Microsoft.AspNetCore.Http;

namespace LearningManagement.Application.Services;

public class InstitutionCourseService:IInstitutionCourseService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IInstitutionCourseRepository _institutionCourseRepository;
    private readonly IApplicationUserRepository _applicationUserRepository;
    public InstitutionCourseService(IInstitutionCourseRepository institutionCourseRepository, IHttpContextAccessor httpContextAccessor, IApplicationUserRepository applicationUserRepository)
    {
        _institutionCourseRepository = institutionCourseRepository;
        _httpContextAccessor = httpContextAccessor;
        _applicationUserRepository = applicationUserRepository;
    }

    public async Task<Result> CourseAddAsync(InstitutionCourseModel model)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _institutionCourseRepository.CourseAddAsync(institutionId.Value, model);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<InstitutionCourseModel>>> CourseListAsync()
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _institutionCourseRepository.CourseListAsync(institutionId.Value);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<InstitutionCourseModel>> CourseDetailsAsync(int institutionCourseId)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _institutionCourseRepository.CourseDetailsAsync(institutionId.Value, institutionCourseId);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }
}