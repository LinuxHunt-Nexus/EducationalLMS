using FluentResults;
using LearningManagement.Data;
using LearningManagement.Data.ViewModels;

namespace LearningManagement.Application.Services;

public interface IInstitutionService
{
    Task<Result<InstitutionViewModel>> GetInstitutionInfoAsync();
    Task<Result<InstitutionViewModel>> GetInstitutionInfoByIdAsync(int id);
    Task<Result<List<InstitutionViewModel>>> InstitutionListAsync();
    Task<Result<InstitutionViewModel>> UpdateInstitutionInfoAsync(InstitutionViewModel model);
    Task<Result<InstitutionViewModel>> CreateInstitutionInfoAsync(InstitutionViewModel model);
    Task<Result<InstitutionViewModel>> UpdateInstitutionInfoByAdminAsync(InstitutionViewModel model);
    Task<Result<InstitutionViewModel>> EditInstitutionInfoAsync(int institutionId, InstitutionViewModel model);
    Task<Result<InstitutionViewModel>> DeleteInstitutionInfoAsync(int institutionId);
}