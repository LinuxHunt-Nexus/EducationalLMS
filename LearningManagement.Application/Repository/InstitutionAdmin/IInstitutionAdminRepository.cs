using FluentResults;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data.Models;

namespace LearningManagement.Application.Repository;

public interface IInstitutionAdminRepository:IBaseRepository<InstitutionAdmin>
{
    Task<Result> InstitutionAdminAddAsync(InstitutionAdminCreateModel model);
    Task<Result<AdminViewModel>> InstitutionAdminInfoAsync(string userName);
    Task<Result<AdminViewModel>> UpdateInstitutionAdminInfoAsync(string userName, AdminViewModel model);
}