using FluentResults;
using LearningManagement.Data.ViewModels;

namespace LearningManagement.Application.Services;

public interface IAcademicSessionService
{
    Task<Result> AcademicSessionAddAsync(AcademicSessionModel model);
    Task<Result<List<AcademicSessionModel>>> AcademicSessionListAsync();
    Task<Result<AcademicSessionModel>> AcademicSessionDetailsAsync(int academicSessionId);
}