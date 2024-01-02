using FluentResults;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data.Models;

namespace LearningManagement.Application.Repository;

public interface IInstitutionClassRepository: IBaseRepository<InstitutionClass>
{
    Task<Result> ClassAddAsync(int institutionId, InstitutionClassModel model);
    Task<Result<List<InstitutionClassModel>>> ClassListAsync(int institutionId);
    Task<Result<InstitutionClassModel>> ClassDetailsAsync(int institutionId, int institutionClassId);
    Task<bool> IsClassNameExistAsync(int institutionId, string name);
}