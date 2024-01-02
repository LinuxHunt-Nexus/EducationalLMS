using System.Net.Http;
using FluentResults;
using LearningManagement.Application.Repository;
using LearningManagement.Data.ViewModels;
using Microsoft.AspNetCore.Http;

namespace LearningManagement.Application.Services;

public class AcademicSessionService: IAcademicSessionService
{
     private readonly IHttpContextAccessor _httpContextAccessor;
     private readonly IAcademicSessionRepository _academicSessionRepository;
     private readonly IApplicationUserRepository _applicationUserRepository;

     public AcademicSessionService(IHttpContextAccessor httpContextAccessor, IAcademicSessionRepository academicSessionRepository, IApplicationUserRepository applicationUserRepository)
     {
         _httpContextAccessor = httpContextAccessor;
         _academicSessionRepository = academicSessionRepository;
         _applicationUserRepository = applicationUserRepository;
     }

     public async Task<Result> AcademicSessionAddAsync(AcademicSessionModel model)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;
           
            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _academicSessionRepository.AcademicSessionAddAsync(institutionId.Value, model);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

     public async Task<Result<List<AcademicSessionModel>>> AcademicSessionListAsync()
     {
         try
         {
             var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

             if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

             var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

             if (institutionId == null) return Result.Fail($"User not found");

             return await _academicSessionRepository.AcademicSessionListAsync(institutionId.Value);
         }
         catch (Exception e)
         {
             return Result.Fail(e.InnerException?.Message ?? e.Message);
         }
     }

     public async Task<Result<AcademicSessionModel>> AcademicSessionDetailsAsync(int academicSessionId)
     {
         try
         {
             var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

             if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

             var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

             if (institutionId == null) return Result.Fail($"User not found");

             return await _academicSessionRepository.AcademicSessionDetailsAsync(institutionId.Value, academicSessionId);
         }
         catch (Exception e)
         {
             return Result.Fail(e.InnerException?.Message ?? e.Message);
         }
    }
}