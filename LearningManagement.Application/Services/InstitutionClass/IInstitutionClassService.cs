using FluentResults;
using LearningManagement.Data.ViewModels;

namespace LearningManagement.Application.Services;

public interface IInstitutionClassService
{
    Task<Result> ClassAddAsync(InstitutionClassModel model);
    Task<Result<List<InstitutionClassModel>>> ClassListAsync();
    Task<Result<InstitutionClassModel>> ClassDetailsAsync(int institutionClassId);
}