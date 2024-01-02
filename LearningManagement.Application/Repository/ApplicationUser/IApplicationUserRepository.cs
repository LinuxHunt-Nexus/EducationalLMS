using LearningManagement.Data.Models;

namespace LearningManagement.Application.Repository;

public interface IApplicationUserRepository:IBaseRepository<ApplicationUser>
{
    Task<int?> GetInstitutionByUserNameAsync(string userName);

    Task<string?> GetApplicationUserIdByUserNameAsync(string userName);
}