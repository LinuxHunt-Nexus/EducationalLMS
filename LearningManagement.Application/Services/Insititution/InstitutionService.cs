﻿using FluentResults;
using LearningManagement.Application.Repository;
using LearningManagement.Data;
using LearningManagement.Data.Enums;
using LearningManagement.Data.Models;
using LearningManagement.Data.ViewModels;
using LearningManagement.Infrastructure.ImageStorageHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LearningManagement.Application.Services;

public class InstitutionService : IInstitutionService
{
    private readonly IInstitutionRepository _institutionRepository;

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IApplicationUserRepository _applicationUserRepository;
    private readonly IFileStorageHelper _fileStorageHelper;

    public InstitutionService(IHttpContextAccessor httpContextAccessor, IApplicationUserRepository applicationUserRepository, IFileStorageHelper fileStorageHelper, IInstitutionRepository institutionRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _applicationUserRepository = applicationUserRepository;
        _fileStorageHelper = fileStorageHelper;
        _institutionRepository = institutionRepository;
    }


    public async Task<Result<InstitutionViewModel>> CreateInstitutionInfoAsync(InstitutionViewModel model)
    {
        try
        {
            var createInstitution = await _institutionRepository.CreateInstitutionInfoAsync(model);
            return new Result<InstitutionViewModel>();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<Result<InstitutionViewModel>> DeleteInstitutionInfoAsync(int institutionId)
    {
        try
        {
            // Fetch institution details from the repository
            var existingInstitution = await _institutionRepository.DeleteInstitutionInfoAsync(institutionId);

            // Check if the institution exists
            if (existingInstitution == null)
            {
                return Result.Fail("Institution not found.");
            }

            // Delete the institution
            var deleted = await _institutionRepository.DeleteInstitutionInfoAsync(institutionId);

            if (!deleted.IsFailed)
            {
                return Result.Fail("Failed to delete institution.");
            }

            // Return the deleted institution's view model
            return new Result<InstitutionViewModel>();
        }
        catch (Exception ex)
        {
            // Log or handle the exception appropriately
            return Result.Fail("An error occurred while deleting the institution.");
        }
    }

    public async Task<Result<InstitutionViewModel>> EditInstitutionInfoAsync(int institutionId, InstitutionViewModel model)
    {
        try
        {
            //var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            //if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            //var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync

            //if (institutionId == null) return Result.Fail($"User not found");

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var imageFileName = await _fileStorageHelper.SaveImageAsync(model.ImageFile);
                model.InstitutionLogoName = imageFileName;
            }

            return await _institutionRepository.EditInstitutionInfoAsync(institutionId, model);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<InstitutionViewModel>> GetInstitutionInfoAsync()
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            return await _institutionRepository.GetInstitutionInfoAsync(institutionId.Value);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<InstitutionViewModel>> GetInstitutionInfoByIdAsync(int id)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            return await _institutionRepository.GetInstitutionInfoAsync(id);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<InstitutionViewModel>>> InstitutionListAsync()
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            return await _institutionRepository.InstitutionListAsync();
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<InstitutionViewModel>> UpdateInstitutionInfoAsync(InstitutionViewModel model)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");

            var institutionId = await _applicationUserRepository.GetInstitutionByUserNameAsync(appUser);

            if (institutionId == null) return Result.Fail($"User not found");

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var imageFileName = await _fileStorageHelper.SaveImageAsync(model.ImageFile);
                model.InstitutionLogoName = imageFileName;
            }

            return await _institutionRepository.UpdateInstitutionInfoAsync(institutionId.Value, model);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<InstitutionViewModel>> UpdateInstitutionInfoByAdminAsync(InstitutionViewModel model)
    {
        try
        {
            var appUser = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(appUser)) return Result.Fail($"User not found");
            
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var imageFileName = await _fileStorageHelper.SaveImageAsync(model.ImageFile);
                model.InstitutionLogoName = imageFileName;
            }

            return await _institutionRepository.UpdateInstitutionInfoAsync(model.InstitutionId, model);
        }
        catch (Exception e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }
}