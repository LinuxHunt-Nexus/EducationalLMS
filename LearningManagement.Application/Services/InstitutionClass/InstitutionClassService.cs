using FluentResults;
using LearningManagement.Application.Repository;
using LearningManagement.Data.ViewModels;
using Microsoft.AspNetCore.Http;

namespace LearningManagement.Application.Services;

public class InstitutionClassService:IInstitutionClassService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly  IInstitutionClassRepository _institutionClassRepository;
    private readonly IApplicationUserRepository _applicationUserRepository;
    public InstitutionClassService(IInstitutionClassRepository institutionClassRepository, IHttpContextAccessor httpContextAccessor, IApplicationUserRepository applicationUserRepository)
    {
        _institutionClassRepository = institutionClassRepository;
        _httpContextAccessor = httpContextAccessor;
        _applicationUserRepository = applicationUserRepository;
    }

    public async Task<Result> ClassAddAsync(InstitutionClassModel model)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _institutionClassRepository.ClassAddAsync(institutionId.Value, model);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<InstitutionClassModel>>> ClassListAsync()
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _institutionClassRepository.ClassListAsync(institutionId.Value);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<InstitutionClassModel>> ClassDetailsAsync(int institutionClassId)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _institutionClassRepository.ClassDetailsAsync(institutionId.Value, institutionClassId);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }
}