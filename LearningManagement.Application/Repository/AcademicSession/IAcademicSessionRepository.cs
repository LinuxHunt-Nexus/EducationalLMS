using FluentResults;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data.Models;

namespace LearningManagement.Application.Repository;

public interface IAcademicSessionRepository: IBaseRepository<AcademicSession>
{
    Task<Result> AcademicSessionAddAsync(int institutionId, AcademicSessionModel model);
    Task<Result<List<AcademicSessionModel>>> AcademicSessionListAsync(int institutionId);
    Task<Result<AcademicSessionModel>> AcademicSessionDetailsAsync(int institutionId, int academicSessionId);
    Task<bool> IsAcademicSessionNameExistAsync(int institutionId, string name);
}