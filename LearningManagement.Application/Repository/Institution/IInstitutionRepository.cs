using FluentResults;
using LearningManagement.Data;
using LearningManagement.Data.ViewModels;

namespace LearningManagement.Application.Repository;

public interface IInstitutionRepository :IBaseRepository<Institution>
{
    Task<Result<InstitutionViewModel>> GetInstitutionInfoAsync(int institutionId);
    Task<Result<List<InstitutionViewModel>>> InstitutionListAsync();
    Task<Result<InstitutionViewModel>> UpdateInstitutionInfoAsync(int institutionId, InstitutionViewModel model);
    Task<Result<Institution>> CreateInstitutionInfoAsync(InstitutionViewModel model);
}